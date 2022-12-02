using System.Text;
using System.Net.Http.Headers;

namespace TriggerAzureWebHook
{
    internal class Program
    {
        /// <summary>
        /// Use case: You have a Web Job or other Azure service which can be activated by triggering your Azure Webhook. 
        /// You want to perform this task in a c# function using .Net 6 or higher and using commands which haven’t been deprecated.
        /// This is an example. Please note the Webjob being called here no longer exists and you will get a 404 error.
        /// When you go live with your code I don't recomend hard coding credentials as per this example.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // This information was provided by the Azure dashboard after you deployed your WebJob
            // Note that the full address has been broken into the hook and the trigger after the /api/ section.
            string webhook = "https://webworktest01.scm.azurewebsites.net/api/";
            string trigger = "triggeredwebjobs/WebWork/run";
            string user = "$WebWorkTest01";
            string password = "YbY9yfvkX815olcThynsxbAlgpvsVdEGwmqufzwobkobFoZ19M5dcN3jixG8";

            // This is the bit you want in your function to trigger the webjob
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));
                    client.BaseAddress = new Uri(webhook);
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    using (HttpResponseMessage response = client.PostAsync(trigger, new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json")).Result)
                    {
                        Console.WriteLine(response.RequestMessage);
                    }
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }

            Console.WriteLine("Press RETURN to exit.");
            Console.ReadLine();
        }
    }
}
