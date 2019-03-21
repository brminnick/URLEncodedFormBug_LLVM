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
        const string _answerKey = "answer";
        const string _answer = "Catastrophe";

        readonly static Lazy<HttpClient> _clientHolder = new Lazy<HttpClient>(() => new HttpClient());

        readonly static Lazy<IPundayWebsiteAPI> _pundayWebsiteClientHolder = new Lazy<IPundayWebsiteAPI>(() =>
            RestService.For<IPundayWebsiteAPI>(new HttpClient { BaseAddress = new Uri(_url) }));

        static IPundayWebsiteAPI PundayWebsiteClient => _pundayWebsiteClientHolder.Value;
        static HttpClient Client => _clientHolder.Value;

        public static async Task<(bool isAnswerCorrect, bool isInternetConnectionAvailable)> PostRequestWithFormUrlEncodedContent_Refit()
        {
            var isAnswerCorrect = false;
            var isInternetConnectionAvailable = false;

            string htmlContent = "";

            using (var response = await PundayWebsiteClient.SubmitAnswer(_punNumber, new Dictionary<string, string> { { _answerKey, _answer } }).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    htmlContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    isInternetConnectionAvailable = true;
                }
            }

            isAnswerCorrect |= htmlContent.Contains("Correct!");

            return (isAnswerCorrect, isInternetConnectionAvailable);
        }

        public static async Task<(bool isAnswerCorrect, bool isInternetConnectionAvailable)> PostRequestWithFormUrlEncodedContent()
        {
            var url = $"{_url}{_punNumber}";

            var isAnswerCorrect = false;
            var isInternetConnectionAvailable = false;

            var answerList = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(_answerKey, _answer) };

            using (var httpContent = new FormUrlEncodedContent(answerList))
            {
                var htmlContent = string.Empty;

                using (var response = await Client.PostAsync(url, httpContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        htmlContent = await response.Content.ReadAsStringAsync();
                        isInternetConnectionAvailable = true;
                    }
                }

                isAnswerCorrect |= htmlContent.Contains("Correct!");
            }

            return (isAnswerCorrect, isInternetConnectionAvailable);
        }
    }
}