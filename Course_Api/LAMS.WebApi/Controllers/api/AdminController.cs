using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Services.Admin;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService adminService)
        {
            _service = adminService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getdirections")]
        public async Task<IHttpActionResult> GetDirections()
        {

            var direction = await _service.GetDirections();

            return Ok(direction);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("adddirection")]
        public async Task<IHttpActionResult> AddDirection([FromBody] DirectionBLL direction)
        {
            var _id = await _service.AddDirection(direction);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcourses")]
        public async Task<IHttpActionResult> GetCourses()
        {

            var courses = await _service.GetCourses();

            return Ok(courses);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("approvecourse")]
        public async Task<IHttpActionResult> ApproveCourse([FromUri] int id)
        {
            int _id = await _service.ApproveCourse(id);

            return Ok(_id);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("rejectcourse")]
        public async Task<IHttpActionResult> RejectCourse([FromUri] int id)
        {
            int _id = await _service.RejectCourse(id);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("block")]
        public async Task<IHttpActionResult> Block([FromUri] string id)
        {
            string _id = await _service.Block(id);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("unblock")]
        public async Task<IHttpActionResult> Unblock([FromUri] string id)
        {
            string _id = await _service.Unblock(id);

            return Ok(_id);
        }
    }
}