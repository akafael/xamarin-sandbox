using System;

using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace project04.Services
{
    public class CEPWebService
    {
        private static string urlBase = "https://viacep.com.br/ws/{0}/json/ ";

        public CEPWebService()
        {
        }

        public async static Task<string> FindCEP(string cep)
        {
            // Http Request
            string url = string.Format(urlBase, cep);
            HttpClient http = new HttpClient();
            //string json = http.GetStringAsync(url).GetAwaiter().GetResult(); // Syncronous 
            string json = await http.GetStringAsync(url);

            // De serialization
            dynamic objectCEP = JsonConvert.DeserializeObject<dynamic>(json);

            // Format msg 
            string result = string.Format("CEP: {0}\n UF: {1}\n Address: {2}\n City: {3}",objectCEP.cep,objectCEP.uf,objectCEP.logradouro,objectCEP.localidade);

            return result;
        }
    }
}
