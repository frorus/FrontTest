using FrontTest.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Extensions.SwaggerExamples
{
    public class LoginRequestExample : IExamplesProvider<LoginUserRequest>
    {
        public LoginUserRequest GetExamples()
        {
            return new LoginUserRequest
            {
                Phone = "+79991234567",
                Password = "Пароль123!"
            };
        }
    }
}