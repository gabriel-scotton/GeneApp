using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gene_App
{
    class App
    {
        
        class Account
        {
            private string username;
            private string email;
            private string password;

            public string Username { get => username; set => username = value; }
            public string Email { get => email; set => email = value; }
            public string Password { get => password; set => password = value; }

            public Account(string username, string email, string password)
            {
                this.username = username;
                this.email = email;
                this.password = password;
            }
        }

        static async Task Main()
        {
            

            try
            {
                //Token token = await ApiRequests.RequestToken("https://gene.lacuna.cc/api/users/login");
                Console.WriteLine("a".ToCharArray().Length);




            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
    
}
