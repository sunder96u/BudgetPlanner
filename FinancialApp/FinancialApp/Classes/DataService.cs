using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Classes
{
    class DataService
    {
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            var client = new HttpClient();
            string json = "";

            try
            {
                var response = await client.GetAsync(queryString);
                if (response != null)
                {
                    json = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return json;



            //HttpClient client = new HttpClient();
            //var responce = await client.GetAsync(queryString);
          
            //var json = responce.Content.ReadAsStringAsync().Result;
            //Debug.WriteLine("JSON: " + json);              
            //return JsonConvert.DeserializeObject(json);                           
        }
    }
}
