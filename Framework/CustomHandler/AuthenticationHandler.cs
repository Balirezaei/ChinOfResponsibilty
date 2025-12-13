using Framework.ChainFramework;

namespace Framework.CustomHandler
{
    public class AuthenticationHandler : Handler<ApiRequest>
    {
        public override void Handle(ApiRequest request)
        {
            if (string.IsNullOrEmpty(request.UserToken))
            {
                request.Response = "401 Unauthorized";
                return;
            }

            Next(request);
        }
    }
}
