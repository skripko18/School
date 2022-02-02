using FluentValidation;
using LAMS.Logic.Common.Models.Users;
using LAMS.Logic.Common.Services.Users;
using LAMS.WebApi.Models.Users;
using Swagger.Net.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    /// <summary>
    /// API controller управления пользователями.
    /// </summary>
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/userregistration")]
    public class RegistrationController : ApiController
    {
        private readonly IRegistrationService _service;

        /// <summary>
        /// Конструктор контроллера. Связывает фронтэнд и бизнеслогику
        /// </summary>
        /// <param name="userService">Экземпляр user-service.</param>
        /// <param name="logger">NLog Logger.</param>
        public RegistrationController(IRegistrationService registrationService)
        {
            _service = registrationService;
        }

        /// <summary>
        /// Регистрирует нового пользователя с уникальным Login.
        /// </summary>
        /// <param name="model">Модель пользователя, содержащая: Login, UserName and Password.</param>
        /// <returns></returns>
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost, Route("register")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, "Пользователь успешно зарегистрирован.")]
        [SwaggerResponse(HttpStatusCode.Conflict, "Пользователь с таким Login уже существует.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Необрабатываемое исключение во время регисрации нового пользователя.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ошибка валидации.")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterUser model)
        {


            var id = await _service.RegisterAsync(model.Email, model.UserName, model.Password, model.FIO);

            if (id == null)
            {
                // throws 409 conflict
                return Ok(0);
            }
            return Ok(id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addteacher")]
        public async Task<IHttpActionResult> TeacherRegistration([FromBody] User user)
        {
            var _docId = await _service.TeacherRegistration(user);

            return Ok(_docId);
        }


    }
}
