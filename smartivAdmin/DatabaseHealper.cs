using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Resources;

namespace smartivAdmin
{
    class DatabaseHelper
    {
      
        public static string defaultConnectionString = "Database=WIMTACH;Data Source=us-cdbr-azure-east-a.cloudapp.net;User Id=b5fd73cb17df05;Password=9a877923";
        MySqlDataReader reader;

        public MySqlConnection getConnection()
        {
            return new MySqlConnection(defaultConnectionString);
        }

        public MySqlCommand getCommand()
        {
            return new MySqlCommand();
        }

        public MySqlDataReader ExecuteCommand(string query, MySqlConnection c, MySqlCommand cmd)
        {
            try
            {

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = c;
                c.Open();
                reader = cmd.ExecuteReader();

            }
            catch (Exception e)
            {

            }
            return reader;
        }

        public MySqlDataAdapter ExecuteCommandForAdapter(string query, MySqlConnection c, MySqlCommand cmd)
        {
            MySqlDataAdapter a =null;
            
            try
            {

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = c;
                a = new MySqlDataAdapter(cmd);


            }
            catch (Exception e)
            {
                throw;
            }
            return a;
        }

        public int ExecuteNonQuery(string query, MySqlConnection c, MySqlCommand cmd)
        {
            int a=0;
            try
            {

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = c;
                c.Open();
                a = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

            }
            return a;

        }

        public int ExecuteNonQueryBatch( List <string> query , MySqlConnection c, MySqlCommand cmd)
        {
            int a = 0;
            try
            {
                        cmd.Connection = c;
                        cmd.CommandType = CommandType.Text;
                        c.Open();
                    foreach (var x in query )
                        { 
                            cmd.CommandText = x;                                  
                            a += cmd.ExecuteNonQuery();
                        }
            }
            catch (Exception e)
            {
                throw e;
            }
            return a;
        }

        public int ExecuteTransaction(string[] query, MySqlConnection c, MySqlCommand cmd)
        {
            MySqlTransaction mytransaction ;
            mytransaction = c.BeginTransaction();
            int a = 0;

            try
            {
                c.Open();
               
                cmd.Connection = c;
                cmd.Transaction = mytransaction;

                for (int i = 0; i < query.Length; i++)
                {
                    cmd.CommandText = query[i];
                    cmd.CommandType = CommandType.Text;

                    a += cmd.ExecuteNonQuery();
                }

                mytransaction.Commit();
          
            }
            catch (Exception e)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (MySqlException mse)
                {
                    throw mse;
                }


                throw e;

            }
           
            return a;

        }


    }

}
