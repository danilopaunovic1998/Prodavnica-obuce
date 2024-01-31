using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IEntity
    {
        string TableName { get; }
        string InsertValues { get; }
        string IdName { get; }
        string[] JoinCondition { get; }
        string[] JoinTable { get; }
        string TableAlias { get; }
        string ConditionForSearch { get; set; }
        string Change { get; }
        string SelectValues { get; }
        List<IEntity> GetEntities (SqlDataReader reader);
        IEntity ReturnObject (SqlDataReader reader);
    }
}
