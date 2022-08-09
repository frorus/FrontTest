using FrontTest.Contracts;
using FrontTest.Data.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FrontTest.Extensions
{
    public class SchemaExamples : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = GetExampleOrNull(context.Type);
        }

        private static IOpenApiAny? GetExampleOrNull(Type type)
        {
            switch (type.Name)
            {
                case "RegisterUserRequest":
                    return new OpenApiObject
                    {
                        ["phone"] = new OpenApiString("+79101234567"),
                        ["login"] = new OpenApiString("логин"),
                        ["password"] = new OpenApiString("Пароль123!"),
                        ["name"] = new OpenApiString("Имя"),
                        ["birth"] = new OpenApiString("2000-01-31"),
                        ["tg"] = new OpenApiString("@Username"),
                        ["email"] = new OpenApiString("email@example.com")
                    };
                case "LoginUserRequest":
                    return new OpenApiObject
                    {
                        ["phone"] = new OpenApiString("+79101234567"),
                        ["password"] = new OpenApiString("Пароль123!")
                    };
                default:
                    return null;
            }
        }
    }
}
