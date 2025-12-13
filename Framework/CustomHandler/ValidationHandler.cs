using Framework.ChainFramework;

namespace Framework.CustomHandler
{
    public class ValidationHandler : Handler<ApiRequest>
    {
        public override void Handle(ApiRequest request)
        {
            if (!request.IsValid)
            {
                request.Response = "400 Bad Request";
                return;
            }

            Next(request);
        }
    }
}
