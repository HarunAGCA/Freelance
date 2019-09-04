using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.TestConsole
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            









            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000/api/");
                //HTTP GET
                
                var responseTask = client.GetAsync("Users/GetBYid?id=2");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<User[]>();
                    readTask.Wait();

                    var students = readTask.Result;

                    foreach (var student in students)
                    {
                        Console.WriteLine(student.Name);
                    }
                }
            }
            Console.Read();
        }
    }
}
