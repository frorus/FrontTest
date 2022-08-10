using FrontTest.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Extensions.SwaggerExamples
{
    public class RegisterRequestExample : IExamplesProvider<RegisterUserRequest>
    {
        public RegisterUserRequest GetExamples()
        {
            return new RegisterUserRequest
            {
                Phone = "+79991234567",
                Password = "Пароль123!",
                Name = "Имя",
                Birth = "2000-01-30",
                Tg = "@Username",
                Email = "email@example.com"
            };
        }
    }
}