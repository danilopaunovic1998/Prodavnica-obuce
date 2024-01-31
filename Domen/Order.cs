using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Order : IEntity
    {
        [Browsable(false)]
        public int OrderID { get; set; }
        public bool isPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        //I Paid Date
        public DateTime PaidDate { get; set; }
        public double Amount { get; set; }
        //isPremiumUser bi ja izbacio
        //public bool IsPremiumUser { get; set; }
        [Browsable(false)]
        public StoreEmployee StoreEmployee { get; set; }
        public PremiumUser PremiumUser { get; set; }
        [Browsable(false)]
        public List<OrderItem> OrderItems { get; set; }

        [Browsable(false)]
        public string TableName => "Orders";
        
        [Browsable(false)]
        public string InsertValues => $"'{isPaid}', '{CreatedDate}', '{PaidDate}', '{Amount}', '{StoreEmployee.StoreEmployeeID}', '{PremiumUser.PremiumUserID}'";
        
        [Browsable(false)]
        public string IdName => "OrderID";
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { "on (o.StoreEmployeeID = se.StoreEmployeeID)", "on (o.PremiumUserID = pu.PremiumUserID)" };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { "join StoreEmployee se ", "join PremiumUser pu " };
        
        [Browsable(false)]
        public string TableAlias => "o";
        
        [Browsable(false)]
        public string ConditionForSearch { get; set; }
        
        [Browsable(false)]
        public string Change => throw new NotImplementedException();
        
        [Browsable(false)]
        public string SelectValues => "o.OrderID oid, o.Paid paid, o.CreatedDate cdt, o.PaidDate pdt, o.Amount am, pu.PremiumUserID pid, pu.FirstName pfn, pu.LastName pln, pu.Bonus pbn";

        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<Order> ordersList = new List<Order>();
            while (reader.Read())
            {
                Order o = new Order
                {
                    OrderID = (int)reader["oid"],
                    isPaid = (bool)reader["paid"],
                    CreatedDate = (DateTime)reader["cdt"],
                    PaidDate = (DateTime)reader["pdt"],
                    Amount = (double)reader["am"],
                    PremiumUser = new PremiumUser
                    {
                        PremiumUserID = (int)reader["pid"],
                        FirstName = (string)reader["pfn"],
                        LastName = (string)reader["pln"],
                        Bonus = (double)reader["pbn"]
                       
                    },
                };
                ordersList.Add(o);
               
            }

            if (ordersList.Count() > 0)
                return new List<IEntity>(ordersList.Cast<IEntity>());
            else
                return null;
        }
        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            Order o = null;
            while (reader.Read())
            {
                o = new Order();
                o.OrderID = (int)reader["oid"];
                o.isPaid = (bool)reader["paid"];
                o.CreatedDate = (DateTime)reader["cdt"];
                o.Amount = (double)reader["am"];

                o.PremiumUser = new PremiumUser
                {
                    PremiumUserID = (int)reader["pid"],
                    FirstName = (string)reader["pfn"],
                    LastName = (string)reader["pln"],
                    Bonus = (double)reader["pbn"]

                };
            }
            return o;
        }
    }
}