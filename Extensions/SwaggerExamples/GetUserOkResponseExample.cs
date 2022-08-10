using FrontTest.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Extensions.SwaggerExamples
{
    public class GetUserOkResponseExample : IExamplesProvider<GetUserResponse>
    {
        public GetUserResponse GetExamples()
        {
            return new GetUserResponse
            {
                Id = Guid.NewGuid(),
                Phone = "+79991234567",
                Name = "Имя",
                Birth = "2000-01-30",
                Tg = "@Username",
                Email = "email@example.com"
            };
        }
    }
}