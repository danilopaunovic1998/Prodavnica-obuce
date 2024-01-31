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
    public class OrderItem : IEntity
    {
        [Browsable(false)]
        public int OrderItemID { get; set; }
        [Browsable(false)]
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public Supplier Supplier { get; set; }
        public Footwear Footwear { get; set; }
        
        [Browsable(false)]
        public string TableName => "OrderItem";
        
        [Browsable(false)]
        public string InsertValues => $"'{Order.OrderID}','{Quantity}', '{Size}', '{Footwear.FootwearID}', '{Supplier.SupplierID}' ";
        
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { "on (f.FootwearID = oi.FootwearID)", "on (s.SupplierID = oi.SupplierID)" };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { "join Footwear f ", "join Supplier s " };


        [Browsable(false)]
        public string TableAlias => "oi";
        
        [Browsable(false)]
        public string ConditionForSearch { get; set; }
        
        [Browsable(false)]
        public string Change => throw new NotImplementedException();
        
        [Browsable(false)]
        public string SelectValues => "f.Model fmd, f.Brand fbnd, f.Price fpr, s.CompanyName scn, s.NameOfSaleEmployee sn, oi.Quantity oiq, oi.Size ois";
        
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> orderItemsList = new List<IEntity>();
            while (reader.Read())
            {
                OrderItem oi = new OrderItem
                {
                    Footwear = new Footwear
                    { 
                        Brand = (string)reader["fbnd"],
                        Model = (string)reader["fmd"],
                        Price = (double)reader["fpr"]
                    },
                    Supplier = new Supplier
                    { 
                        CompanyName = (string)reader["scn"],
                        NameOfSaleEmployee = (string)reader["sn"]
                    },
                    Quantity = (int)reader["oiq"],
                    Size = (int)reader["ois"]
                };

                orderItemsList.Add(oi);
            }
            if (orderItemsList.Count() > 0)
                return orderItemsList;
            else
                return null;
        }
        
        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
