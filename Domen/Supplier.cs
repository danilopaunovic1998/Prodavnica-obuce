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
    public class Supplier : IEntity
    {
        [Browsable(false)]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string NameOfSaleEmployee { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{CompanyName} : {NameOfSaleEmployee}";
        }

        [Browsable(false)]
        public string TableName => "Supplier";
       
        [Browsable(false)]
        public string InsertValues => $"'{CompanyName}', '{NameOfSaleEmployee}', '{Description}'";
        
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { };

        [Browsable(false)]
        public string TableAlias => "s";
        
        [Browsable(false)]
        public string ConditionForSearch { get; set; }
        
        [Browsable(false)]
        public string Change => throw new NotImplementedException();
        
        [Browsable(false)]
        public string SelectValues => "*";

        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> supplerList = new List<IEntity>();
            while (reader.Read())
            {
                Supplier s = new Supplier
                {
                    SupplierID = reader.GetInt32(0),
                    CompanyName = reader.GetString(1),
                    NameOfSaleEmployee = reader.GetString(2),
                    Description = reader.GetString(3)

                };
                
                supplerList.Add(s);
            }
            if (supplerList.Count() > 0)
                return supplerList;
            else
                return null;
        }
   
    
       
        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            Supplier s = null;
            while (reader.Read())
            {
                s = new Supplier()
                {
                    SupplierID = reader.GetInt32(0),
                    CompanyName = reader.GetString(1),
                    NameOfSaleEmployee = reader.GetString(2),
                    Description = reader.GetString(3)

                };
            }
            return s;
        }
    }
}
