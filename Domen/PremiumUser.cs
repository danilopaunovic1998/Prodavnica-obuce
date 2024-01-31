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
    public class PremiumUser: IEntity
    {
        [Browsable(false)]
        public int PremiumUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Bonus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} : {Bonus}";
        }

        [Browsable(false)]
        public string TableName => "PremiumUser";
        
        [Browsable(false)]
        public string InsertValues => $"'{FirstName}' , '{LastName}', '{DateOfBirth.ToString("yyyy-MM-dd HH:mm:ss")}' , '{Bonus}'";
        
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        
        [Browsable(false)]
        public string[] JoinCondition => new string[] { };
        
        [Browsable(false)]
        public string[] JoinTable => new string[] { };
        
        [Browsable(false)]
        public string TableAlias => "pu";
        
        [Browsable(false)]
        public string ConditionForSearch { get; set; }
        
        [Browsable(false)]
        public string Change => $"Bonus = '{Bonus}'";
        
        [Browsable(false)]
        public string SelectValues => "*";
        
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> premiumUserList = new List<IEntity>();

            while (reader.Read())
            {
                PremiumUser p = new PremiumUser
                {
                    PremiumUserID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    DateOfBirth = reader.GetDateTime(3),
                    Bonus = reader.GetDouble(4)

                };
                premiumUserList.Add(p);
            }

            if (premiumUserList.Count() > 0)
                return premiumUserList;
            else
                return null;
        }
        
        [Browsable(false)]
        public IEntity ReturnObject(SqlDataReader reader)
        {
            PremiumUser p = null;
            while (reader.Read())
            {
                p = new PremiumUser();
                p.PremiumUserID = reader.GetInt32(0);
                p.FirstName = reader.GetString(1);
                p.LastName = reader.GetString(2);
                p.DateOfBirth = reader.GetDateTime(3);
                p.Bonus = reader.GetDouble(4);
            }
            return p;
        }
    }
}
