
using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using System.Data.SQLite;
using Blog_Server;
using System.Net.Http;
using System.Threading.Tasks;
namespace BlogClient 
{ 

    class Program
    {
        static async Task Main(string[] args)
        {
            
            for (int i=4; i<15; i++)
            { 
            
            HttpClient client = new HttpClient();

                string numi = i.ToString();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/"+numi);

            string responseBody = await response.Content.ReadAsStringAsync();


            HttpResponse httpResponse = new HttpResponse(); // запись полученных данных с сервера в файл FileBlog.tx

            httpResponse.ApplyingDatabaseMetod(responseBody);

            }

        }
           

            


            
           



           


        }
    }

