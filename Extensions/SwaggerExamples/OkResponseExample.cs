using FrontTest.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Extensions.SwaggerExamples
{
    public class OkResponseExample : IExamplesProvider<AuthUserResponse>
    {
        public AuthUserResponse GetExamples()
        {
            return new AuthUserResponse
            {
                Id = Guid.NewGuid()
            };
        }
    }
}