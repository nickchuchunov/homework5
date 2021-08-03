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

      public async Task ApplyingDatabaseMetod(string file)

        {


             
           
                

                
             File.AppendAllLines("FileBlog.txt", new string[] { file });


            



           


        }



    }
}
