using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Refit;

namespace RefitLLVMRepro
{
    [Headers("Accept-Encoding: gzip")]
    public interface IPundayWebsiteAPI
    {
        [Get(@"/{punNumber}")]
        Task<HttpResponseMessage> ScrapeHtml(string punNumber);

        [Get(@"/wp-content/uploads/{imageName}")]
        Task<HttpResponseMessage> GetImage(string imageName);

        [Post(@"/{punNumber}")]
        Task<HttpResponseMessage> SubmitAnswer(int punNumber, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> answer);

        [Get("")]
        Task<HttpResponseMessage> GetWebsiteResponse();
    }
}
