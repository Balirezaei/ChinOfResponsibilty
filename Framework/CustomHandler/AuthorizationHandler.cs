using Framework.ChainFramework;

namespace Framework.CustomHandler
{
    public class AuthorizationHandler : Handler<ApiRequest>
    {
        public override void Handle(ApiRequest request)
        {
            if (!request.IsAuthorized)
            {
                request.Response = "403 Forbidden";
                return;
            }

            Next(request);
        }
    }
}
