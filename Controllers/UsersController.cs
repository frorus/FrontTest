using FrontTest.Contracts;
using FrontTest.Data.Models;
using FrontTest.Extensions.Exceptions;
using FrontTest.Extensions.SwaggerExamples;
using FrontTest.Repositories;
using FrontTest.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Filters;

namespace FrontTest.Controllers
{
    [Route("v1")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _users;

        public UsersController(IUserRepository users)
        {
            _users = users;
        }

        [HttpPost]
        [Route("auth/register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerRequestExample(typeof(RegisterUserRequest), typeof(RegisterRequestExample))]
        [SwaggerResponseExample(201, typeof(OkResponseExample))]
        [SwaggerResponseExample(400, typeof(BadResponseExample))]
        public async Task<ActionResult<AppUser>> Register([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new MyBadRequestException("Данные введены некорректно");
            }

            if (request.Name!.Length >= 20) {
                throw new MyBadRequestException("Число символов в поле должно быть от 1 до 20");
            }

            if (await _users.UserExists(request.Phone!))
            {
                throw new MyBadRequestException("Пользователь уже существует");
            }

            DateTime dob = DateTime.Parse(request.Birth!);
            int userAge = AgeValidation.UserAge(dob);

            if (userAge < 18 && userAge > 0)
            {
                throw new MyBadRequestException("Сервис доступен только для совершеннолетних");
            }
            else if (userAge <= 0)
            {
                throw new MyBadRequestException("Дата рождения введена некорректно");
            }

            AppUser user = new()
            {
                Id = Guid.NewGuid(),
                Phone = request.Phone,
                Password = request.Password,
                Name = request.Name,
                Birth = request.Birth,
                Tg = request.Tg,
                Email = request.Email
            };

            var resp = new AuthUserResponse
            {
                Id = user.Id
            };

            await _users.Create(user);

            return StatusCode(201, resp);
        }

        [HttpPost]
        [Route("auth/login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerRequestExample(typeof(LoginUserRequest), typeof(LoginRequestExample))]
        [SwaggerResponseExample(200, typeof(OkResponseExample))]
        [SwaggerResponseExample(400, typeof(BadResponseExample))]
        [SwaggerResponseExample(404, typeof(BadResponseExample))]
        public async Task<ActionResult<AppUser>> Login([FromBody] LoginUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new MyBadRequestException("Данные введены некорректно");
            }

            if (!await _users.UserExists(request.Phone!))
            {
                throw new MyNotFoundException("Пользователь не найден");
            }

            var user = await _users.GetUserByPhone(request.Phone!);

            if (user.Password != request.Password)
            {
                throw new MyBadRequestException("Пароль введен некорректно");
            }

            var resp = new AuthUserResponse
            {
                Id = user.Id
            };

            return StatusCode(200, resp);
        }


        /// <param name="id" example="705bb81a-9930-438a-a3f2-3438985b2da8"></param>
        [HttpGet]
        [Route("user")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerResponseExample(200, typeof(GetUserOkResponseExample))]
        [SwaggerResponseExample(404, typeof(BadResponseExample))]
        public async Task<ActionResult<AppUser>> GetUser([BindRequired] Guid id)
        {
            var user = await _users.GetUserById(id);

            if (user == null)
            {
                throw new MyNotFoundException("Пользователь не найден");
            }

            var resp = new GetUserResponse
            {
                Id = user.Id,
                Phone = user.Phone,
                Name = user.Name,
                Birth = user.Birth,
                Tg = user.Tg,
                Email = user.Email
            };

            return StatusCode(200, resp);
        }
    }
}
