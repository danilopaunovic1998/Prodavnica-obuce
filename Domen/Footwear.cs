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
    public class Footwear : IEntity
    {
        [Browsable(false)]
        public int FootwearID { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public Supplier Supplier { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} : {Price}";
        }

        [Browsable(false)]
        public string TableName => "Footwear";

        [Browsable(false)]
        public string InsertValues => $"'{Supplier.SupplierID}','{Model}', '{Brand}', '{Price}' ";
        
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { "on (f.SupplierID = s.SupplierID) " };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { "join Supplier s " };

        [Browsable(false)]
        public string TableAlias => "f";
        
        [Browsable(false)]
        public string ConditionForSearch { get; set; }
        
        [Browsable(false)]
        public string Change => $"Model = '{Model}', Brand = '{Brand}', Price = '{Price}', SupplierID = '{Supplier.SupplierID}'";

        [Browsable(false)]
        public string SelectValues => "f.FootwearID fid, f.Model fmodel, f.Brand fbrand, f.Price fprice, f.SupplierID sid, s.CompanyName scompanyname, s.NameOfSaleEmployee semployee, s.Description sdes";

        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> footwearList = new List<IEntity>();

            while (reader.Read())
            {
                Footwear f = new Footwear
                {
                    FootwearID = (int)reader["fid"],
                    Model = (string)reader["fmodel"],
                    Brand = (string)reader["fbrand"],
                    Price = (double)reader["fprice"],
                    Supplier = new Supplier
                    {
                        SupplierID = (int)reader["sid"],
                        CompanyName = (string)reader["scompanyname"],
                        NameOfSaleEmployee = (string)reader["semployee"],
                        Description = (string)reader["sdes"]
                    },

                };


                footwearList.Add(f);
            }

            if (footwearList.Count() > 0)
            {
                return footwearList;
            }
            else
            {
                return null;
            }
        }
        
        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            Footwear f = null;
            while (reader.Read())
            {
                f = new Footwear();
                f.FootwearID = (int)reader["fid"];
                f.Model = (string)reader["fmodel"];
                f.Brand = (string)reader["fbrand"];
                f.Price = (double)reader["fprice"];
                f.Supplier = new Supplier
                {
                    SupplierID = (int)reader["sid"],
                    CompanyName = (string)reader["scompanyname"],
                    NameOfSaleEmployee = (string)reader["semployee"],
                    Description = (string)reader["sdes"]
                };

            }
            return f;
        }
    }
}
