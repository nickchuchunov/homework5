using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using
System.Threading.Tasks;

namespace BlogClient
{
  public  class HttpResponse
    {
       public HttpResponse() { }

      public async Task<ForDatabase> ApplyingDatabaseMetod(IList<ForDatabase> forDatabases)

        {


             for  (int i=0; i< forDatabases.Count; i++) 
            {
                string Database = forDatabases[i].UserId.ToString();
                string Database1 = forDatabases[i].Id.ToString();
                string Database2 = forDatabases[i].Title;
                string Database3 = forDatabases[i].Body;

                string file = "UserId: " + Database + "Id: " + Database1 + "Title: " + Database2 + "Body " + Database3;
                 File.AppendAllLines("FileBlog.txt", new string[] { file });


            }



            return null;


        }



    }
}
