using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Blog_Server
{

   
    public class Database
    {

       public Database() 
        
        {
        }



     public  void  DatabaseCreate() // создание базы
        {
            string conectionstring = "Data Source = BlogServer.db; Version = 3; Pooling = true; Max Pool Size = 100;";

            using (var database = new SQLiteConnection(conectionstring))

            {
                database.Open();


                using (var command = new SQLiteCommand(conectionstring, database))
                {


                    command.CommandText = @"CREATE TABLE blogserver(UserId INT, Id INT, Title TEXT, Body TEXT)";
                    command.Prepare();
                    command.ExecuteNonQuery();


                }


            }


        }





       public  void DatebaseAdd(InterfeisDatabase interfeis) // запись данных в базу
        {

            string conectionstring = "Data Source = BlogServer.db; Version = 3; Pooling = true; Max Pool Size = 100;";

            using (var database = new SQLiteConnection(conectionstring))

            {
                database.Open();


                using (var command = new SQLiteCommand(conectionstring, database))
                {
                    command.CommandText = @"UPDATE blogserver SET UserId =@UserId, Id=@Id, Title=@Title, Body=@Body";
                    command.Parameters.AddWithValue("@UserId", interfeis.UserId);
                    command.Parameters.AddWithValue("@Id", interfeis.Id);
                    command.Parameters.AddWithValue("@Title", interfeis.Title);
                    command.Parameters.AddWithValue("@Body", interfeis.Body);

                    command.Prepare();
                    command.ExecuteNonQuery();


                }


            }


        }



       public IList <InterfeisDatabase> DatabaseRead(int from, int to) // чтение данных из базы 
        {

            string conectionstring = "Data Source = BlogServer.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            IList<InterfeisDatabase> returnlist = new List<InterfeisDatabase>();

            using (var database = new SQLiteConnection(conectionstring))


            {

                database.Open();


                using (var command = new SQLiteCommand(conectionstring, database))
                {
                    command.CommandText = "SELECT * FROM blogserver WHERE Id> @from AND Id<@to";// 

                   command.Parameters.AddWithValue("@from", from);
                  command.Parameters.AddWithValue("@to", to);
                    command.Prepare();
                    // command.ExecuteNonQuery();
                   
                    using (SQLiteDataReader reader =command.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            returnlist.Add(new InterfeisDatabase { UserId = reader.GetInt32(0), Id = reader.GetInt32(1), Title = reader.GetString(2), Body= reader.GetString(3) });




                        }


                    }
                       



                }






            }

            return returnlist;

        }






    }









 }

