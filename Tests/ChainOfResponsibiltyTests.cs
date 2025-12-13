using Framework;
using Framework.ChainFramework;
using Framework.CustomHandler;
using Framework.Handler;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace Tests
{
    public class ChainOfResponsibiltyTests
    {

        [Fact]
        public void Request_Without_Token_Should_Return_401_InSingle_Chain()
        {
            var chain = new ChainBuilder<ApiRequest>()
            .With<AuthenticationHandler>()
            .Build(); ;

            var request = new ApiRequest
            {
                UserToken = null
            };

            chain.Handle(request);

            Assert.Equal("401 Unauthorized", request.Response);
        }



        [Fact]
        public void Authorized_Request_With_High_RateLimit_Should_Return_()
        {
            var chain = new ChainBuilder<ApiRequest>()
            .With<AuthenticationHandler>()
            .With<AuthorizationHandler>()
            .With<RateLimitHandler>()
            .Build(); ;

            var request = new ApiRequest
            {
                UserToken = "abc",
                IsAuthorized = true,
                RequestCount=150
            };

            chain.Handle(request);

            Assert.Equal("429 Too Many Requests", request.Response);
        }


        [Fact]
        public void Validated_Request_With_Invalid_Data_Should_Return_400()
        {
            var chain = new ChainBuilder<ApiRequest>()
                .With<AuthenticationHandler>()
                .With<AuthorizationHandler>()
                .With<RateLimitHandler>()
                .With<ValidationHandler>()
                .Build();

            var request = new ApiRequest
            {
                UserToken = "abc",
                IsAuthorized = true,
                RequestCount = 10,
                IsValid = false
            };

            chain.Handle(request);

            Assert.Equal("400 Bad Request", request.Response);
        }
    }
}