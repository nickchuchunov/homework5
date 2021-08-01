
using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using System.Data.SQLite;
using Blog_Server;
using System.Net.Http;
namespace BlogClient 
{ 

    class Program
    {
        static void Main(string[] args)
        {
            // создание базы данных на сервере (метол DatabaseCreate) блога запись (метод DatebaseAdd ) в базу значений UserId INT, Id INT, Title TEXT, Body TEXT, Метод (databaseList) чтения из базы данных с параметрами от Id и до Id.

            HttpRequest httpRequest = new HttpRequest();
            Database database1 = new Database();

            //database1.DatabaseCreate();

            database1.DatebaseAdd(httpRequest.blig1);
            database1.DatebaseAdd(httpRequest.blig2);
            database1.DatebaseAdd(httpRequest.blig3);
            database1.DatebaseAdd(httpRequest.blig4);
            database1.DatebaseAdd(httpRequest.blig5);
            database1.DatebaseAdd(httpRequest.blig6);
            database1.DatebaseAdd(httpRequest.blig7);
            database1.DatebaseAdd(httpRequest.blig8);
            database1.DatebaseAdd(httpRequest.blig9);
            database1.DatebaseAdd(httpRequest.blig10);
            database1.DatebaseAdd(httpRequest.blig11);
            database1.DatebaseAdd(httpRequest.blig12);
            database1.DatebaseAdd(httpRequest.blig13);
            database1.DatebaseAdd(httpRequest.blig14);
            database1.DatebaseAdd(httpRequest.blig15);

            [Route("api/Blog_Server/Database/DatabaseRead/{from=4}/{to=14}")]
            IList<InterfeisDatabase> databaseList = database1.DatabaseRead([FromRoute] int from, [FromRoute] int to);//имитация обращения к методу сервера блога через контроллер

          


            // Обращение из клиента к метаду чтения с базы данных на сервер блога


            
           

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "api/Blog_Server/Database/DatabaseRead/{from=4}/{to=14}"); // создание http запроса к методу на сервере
            var httpclient = new HttpClient();
                var response = httpclient.SendAsync((HttpRequest)httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<HttpRequest>>(responseStream).Result; /// получение данных из сервера.
           



            HttpResponse httpResponse = new HttpResponse(); // запись полученных данных с сервера в файл FileBlog.tx

            httpResponse.ApplyingDatabaseMetod();


        }
    }
}
