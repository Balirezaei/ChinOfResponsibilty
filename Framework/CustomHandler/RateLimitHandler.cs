using Framework.ChainFramework;

namespace Framework.CustomHandler
{
    public class RateLimitHandler : Handler<ApiRequest>
    {
        public override void Handle(ApiRequest request)
        {
            if (request.RequestCount > 100)
            {
                request.Response = "429 Too Many Requests";
                return;
            }

            Next(request);
        }
    }
}
