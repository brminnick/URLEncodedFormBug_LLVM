using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Refit;

namespace RefitLLVMRepro
{
    public static class APIService
    {
        readonly static Lazy<HttpClient> _clientHolder = new Lazy<HttpClient>(() => new HttpClient());

        readonly static Lazy<IPundayWebsiteAPI> _pundayWebsiteClientHolder = new Lazy<IPundayWebsiteAPI>(() =>
            RestService.For<IPundayWebsiteAPI>(new HttpClient { BaseAddress = new Uri("https://mondaypunday.com") }));

        static IPundayWebsiteAPI PundayWebsiteClient => _pundayWebsiteClientHolder.Value;
        static HttpClient Client => _clientHolder.Value;

        public static async Task<(bool isUserTextCorrect, bool isInternetConnectionAvailable)> IsUserTextCorrect_IsInternetConnectionAvailable(int punNumber, string userAnswer)
        {
            var isUserTextCorrect = false;
            var isInternetConnectionAvailable = false;

            string htmlContent = "";

            using (var response = await PundayWebsiteClient.SubmitAnswer(punNumber, new Dictionary<string, string> { { "answer", userAnswer } }).ConfigureAwait(false))
            {
                //Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Response Status Code", response.StatusCode.ToString(), "Ok"));

                if (response.IsSuccessStatusCode)
                {
                    htmlContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("HTML Content", htmlContent, "Ok"));

                    isInternetConnectionAvailable = true;
                }
            }

            isUserTextCorrect |= htmlContent.Contains("Correct!");

            return (isUserTextCorrect, isInternetConnectionAvailable);
        }

        public static async Task<(bool isUserTextCorrect, bool isInternetConnectionAvailable)> PostAsyncWithFormUrlEncodedContent(int punNumber, string answer)
        {
            var url = $"https://mondaypunday.com/{punNumber}";

            var isUserTextCorrect = false;
            var isInternetConnectionAvailable = false;

            var answerList = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("answer", answer) };

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

                isUserTextCorrect |= htmlContent.Contains("Correct!");
            }

            return (isUserTextCorrect, isInternetConnectionAvailable);
        }
    }
}