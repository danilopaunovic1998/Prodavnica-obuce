using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(
                "Data Source=DESKTOP-ABA0AL5;Initial Catalog=ProSoft-Sem-ProdavnicaObuce;Integrated Security=True");
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public int Insert(IEntity objekat) //OK ali ne znam kako se cuva Order, da li da pravim posebnu f-ju?
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"insert into {objekat.TableName} values ({objekat.InsertValues})";

            return command.ExecuteNonQuery();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback() 
        {
            transaction.Rollback();
        }

        public IEntity SelectOne(IEntity objekat)//TO DO !!!!
        {
            IEntity rezultat;
            SqlCommand command = new SqlCommand("", connection, transaction);

            command.CommandText = $"select {objekat.SelectValues} from {objekat.TableName} {objekat.TableAlias} ";


            for (int i = 0; i < objekat.JoinTable.Length; i++)
            {
                command.CommandText += objekat.JoinTable[i];
                command.CommandText += objekat.JoinCondition[i];
            }
            command.CommandText += " where ";
            command.CommandText += objekat.ConditionForSearch;
            
            SqlDataReader reader = command.ExecuteReader();
            rezultat = objekat.ReturnObject(reader);
            reader.Close();
            return rezultat;
        }

       
     


        public int Delete(IEntity objekat) //OK!!!
        {
            SqlCommand command = new SqlCommand
                ($"delete from {objekat.TableName} where {objekat.ConditionForSearch}",
                connection, transaction);
           //Console.WriteLine(command.CommandText) ZA PROVERU AKO ZATREBA
            return command.ExecuteNonQuery();
        }

        public int Update(IEntity objekat) //OK!!!
        {
            SqlCommand command = new SqlCommand
                ($"update {objekat.TableName} set {objekat.Change} where {objekat.ConditionForSearch}",
                connection, transaction);
            //Console.WriteLine(command.CommandText) ZA PROVERU AKO ZATREBA
            return command.ExecuteNonQuery();
        }

        //proveri da li ce da ubacuje condition?
        public List<IEntity> GetAll(IEntity objekat)
        {
            List<IEntity> result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select {objekat.SelectValues} from {objekat.TableName} {objekat.TableAlias} ";

            for (int i = 0; i < objekat.JoinTable.Length; i++)
            {
                command.CommandText += objekat.JoinTable[i];
                command.CommandText += objekat.JoinCondition[i];
            }
            if(!string.IsNullOrEmpty(objekat.ConditionForSearch))
            { command.CommandText += " where "; }
            command.CommandText += objekat.ConditionForSearch;

            SqlDataReader reader = command.ExecuteReader();
            //ovde pozivas funkciju iz interfejsa
            result = objekat.GetEntities(reader);
            reader.Close();
            return result;
        }
        //izmenjeno!
        public int GetId(IEntity objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select max({objekat.IdName}) from {objekat.TableName}";
            object result = command.ExecuteScalar();
            if (result is DBNull)
            {
                return 0;
            }
            else
            {
                return (int)result;
            }
        }
    }
}
