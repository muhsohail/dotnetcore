using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.WebApi.Handlers
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("Handshake"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "You must supply an API key header called Handshake")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
