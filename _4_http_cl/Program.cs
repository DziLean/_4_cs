using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _4_http_cl
{
    class Program
    {
        static void Main()
        {
	        Task t = new Task(DownloadPageAsync);
	        t.Start();
	        Console.WriteLine("Downloading page...");
	        Console.ReadLine();
        }

        static async void DownloadPageAsync()
        {
	        // ... Target page.
	        string page = "http://localhost:8080/test/";

	            // ... Use HttpClient.
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8080/test/");                   
                    client.DefaultRequestHeaders
                          .Add("Origin","http://localhost:8080");
                    client.DefaultRequestHeaders
                          .Add("Connection","keep-alive");
                    client.DefaultRequestHeaders
                          .Add("Accept","*/*");
                    client.DefaultRequestHeaders
                          .Add("Accept-Encoding","gzip, deflate");
                    client.DefaultRequestHeaders
                          .Add("Accept-Language","en-GB,en-US;q=0.8,en;q=0.6");
                    client.DefaultRequestHeaders
                          .Add("Host","localhost:8080");
                    client.DefaultRequestHeaders
                          .Add("Referer","http://localhost:8080/test");
                    string choose;
                    while (true)
                    {
                        choose = Console.ReadLine();
                        switch (choose)
                        {
                            case "get":
                                client.DefaultRequestHeaders
                         .Add("Type", "GET");
                                using (HttpResponseMessage response = await client.GetAsync(page))
                                using (HttpContent content = response.Content)
                                {
                                    // ... Read the string.
                                    string result = await content.ReadAsStringAsync();

                                    // ... Display the result.
                                    {
                                        Console.WriteLine(result);
                                    }
                                }
                                break;
                            case "post":
                                client.DefaultRequestHeaders
                         .Add("Type", "POST");
                                using (HttpResponseMessage response = await client.PostAsync(page,new StringContent("EmptyBody") ))
                                using (HttpContent content = response.Content)
                                {
                                    
                                    string result = await content.ReadAsStringAsync();

                                    
                                    {
                                        Console.WriteLine(result);
                                    }
                                }
                                break;
                            case "head":
                                client.DefaultRequestHeaders
                         .Add("Type", "HEAD");
                                using (HttpResponseMessage response = await client.GetAsync(page))
                                using (HttpContent content = response.Content)
                                {

                                    string result = await content.ReadAsStringAsync();


                                    {
                                        Console.WriteLine(result);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
        }
    }
}
