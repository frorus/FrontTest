using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Extensions.SwaggerExamples
{
    public class BadResponseExample : IExamplesProvider<ErrorModel>
    {
        public ErrorModel GetExamples()
        {
            return new ErrorModel
            {
                Код = "Код ошибки",
                Текст = "Текст ошибки"
            };
        }
    }
}