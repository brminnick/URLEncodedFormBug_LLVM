using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Refit;

namespace RefitLLVMRepro
{
    public static class APIService
    {
        const string _url = "https://mondaypunday.com/";
        const int _punNumber = 321;
        const string _answer = "answer";

        readonly static Lazy<HttpClient> _clientHolder = new Lazy<HttpClient>(() => new HttpClient());

        readonly static Lazy<IPundayWebsiteAPI> _pundayWebsiteClientHolder = new Lazy<IPundayWebsiteAPI>(() =>
            RestService.For<IPundayWebsiteAPI>(new HttpClient { BaseAddress = new Uri(_url) }));

        static IPundayWebsiteAPI PundayWebsiteClient => _pundayWebsiteClientHolder.Value;
        static HttpClient Client => _clientHolder.Value;

        public static async Task<bool> IsPostSuccessful_Refit()
        {
            using (var response = await PundayWebsiteClient.SubmitAnswer(_punNumber, new Dictionary<string, string> { { _answer, _answer } }).ConfigureAwait(false))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> IsPostSuccessful()
        {
            var url = $"{_url}{_punNumber}";

            var answerList = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(_answer, _answer) };

            using (var httpContent = new FormUrlEncodedContent(answerList))
            {
                var htmlContent = string.Empty;

                using (var response = await Client.PostAsync(url, httpContent))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}