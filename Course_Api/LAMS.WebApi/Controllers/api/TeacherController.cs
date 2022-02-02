using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Teacher;
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
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService teacherService)
        {
            _service = teacherService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getteacherdirections")]
        public async Task<IHttpActionResult> GetTeacherDirections([FromUri] string id)
        {

            var direction = await _service.GetTeacherDirections(id);

            return Ok(direction);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addteacherdirection")]
        public async Task<IHttpActionResult> AddTeacherDirection([FromBody] TeacherDirectionBLL direction)
        {
            var _id = await _service.AddTeacherDirection(direction);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcourses")]
        public async Task<IHttpActionResult> GetCourses([FromUri] int id)
        {

            var course = await _service.GetCourses(id);

            return Ok(course);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getactivecourses")]
        public async Task<IHttpActionResult> GetActiveCourses()
        {

            var course = await _service.GetActiveCourses();

            return Ok(course);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcourseinfo")]
        public async Task<IHttpActionResult> GetCourseInfo([FromUri] int id)
        {

            var course = await _service.GetCourseInfo(id);

            return Ok(course);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addcourse")]
        public async Task<IHttpActionResult> AddCourse([FromBody] CourseBLL course)
        {
            var _id = await _service.AddCourse(course);

            return Ok(_id);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editcourse")]
        public async Task<IHttpActionResult> EditCourse([FromBody] CourseBLL course)
        {
            int _course = await _service.EditCourse(course);

            return Ok(course);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("finishcreatecourse")]
        public async Task<IHttpActionResult> FinishCrateCourse([FromUri] int id)
        {
            int _id = await _service.FinishCreateCourse(id);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("startcourse")]
        public async Task<IHttpActionResult> StartCourse([FromUri] int id)
        {
            int _id = await _service.StartCourse(id);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("endcourse")]
        public async Task<IHttpActionResult> EndCourse([FromUri] int id)
        {
            int _id = await _service.EndCourse(id);

            return Ok(_id);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delcourse")]
        public async Task<IHttpActionResult> DelCourse([FromUri] int id)
        {

            var course = await _service.DelCourse(id);

            return Ok(course);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getprograms")]
        public async Task<IHttpActionResult> GetProgram([FromUri] int id)
        {

            var program = await _service.GetPrograms(id);

            return Ok(program);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addprogram")]
        public async Task<IHttpActionResult> AddProgram([FromBody] CourseProgramBLL program)
        {
            var _id = await _service.AddProgram(program);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delprogram")]
        public async Task<IHttpActionResult> DelProgram([FromUri] int id)
        {
          
            var program = await _service.DelProgram(id);

            return Ok(program);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("gethomeworks")]
        public async Task<IHttpActionResult> GetHomeworks([FromUri] int id)
        {

            var program = await _service.GetHomeworks(id);

            return Ok(program);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addhomework")]
        public async Task<IHttpActionResult> AddHomework([FromBody] HomeworkBLL homework)
        {
            var _id = await _service.AddHomework(homework);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delhomework")]
        public async Task<IHttpActionResult> DelHomework([FromUri] int id)
        {

            var program = await _service.DelHomework(id);

            return Ok(program);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getmaterials")]
        public async Task<IHttpActionResult> GetMaterials([FromUri] int id)
        {

            var materials = await _service.GetMaterials(id);

            return Ok(materials);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addmaterial")]
        public async Task<IHttpActionResult> AddMaterial([FromBody] MaterialBLL material)
        {
            var _id = await _service.AddMaterial(material);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delmaterial")]
        public async Task<IHttpActionResult> DelMaterial([FromUri] int id)
        {

            var material = await _service.DelMaterial(id);

            return Ok(material);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("ordercourse")]
        public async Task<IHttpActionResult> OrderCourse([FromBody] LearnerCourseBLL course)
        {
            var _id = await _service.OrderCourse(course);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getlearnercourses")]
        public async Task<IHttpActionResult> GetLearnerCourses([FromUri] string id)
        {

            var courses = await _service.GetLearnerCourses(id);

            return Ok(courses);
        }
    }
}