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
    public class StoreEmployee : IEntity
    {
        public int StoreEmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"'{FirstName}' '{LastName}'";
        }

        [Browsable(false)]
        public string TableName => "StoreEmployee";
        
        [Browsable(false)]
        public string InsertValues => throw new NotImplementedException();
        
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { };
        
        [Browsable(false)]
        public string TableAlias => "se";

        [Browsable(false)]
        public string ConditionForSearch { get { return $"Username = '{Username}' and Password = '{Password}'"; } set { } }
        
        [Browsable(false)]
        public string Change => throw new NotImplementedException();
        
        [Browsable(false)]
        public string SelectValues => "*";

        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            StoreEmployee s = null;
            while (reader.Read())
            {
                s = new StoreEmployee()
                {
                    StoreEmployeeID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Username = reader.GetString(3),
                    Password = reader.GetString(4)
                };
                
                
            }
            return s;
        }
    }
}
