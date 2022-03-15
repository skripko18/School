using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Teacher;
using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Teacher;
using LAMS.Logic.Services.Teacher;
using LAMS.Logic.Tests.Moqs;
using Moq;
using NUnit.Framework;

namespace LAMS.Logic.Tests.ServiceTests
{
    [TestFixture]
    public class TeacherServiceTests
    {
        private IMapper _mapper;
        private ITeacherService _service;
        private ITeacherRepository _repo;

        public TeacherServiceTests()
        {
            _repo = new TeacherRepositoryMoq();

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TeacherDirectionBLL, TeacherDirectionDb>();
                config.CreateMap<TeacherDirectionDb, TeacherDirectionBLL>();
                config.CreateMap<CourseDb, CourseBLL>();
                config.CreateMap<CourseBLL, CourseDb>();
                config.CreateMap<CourseProgramBLL, CourseProgramDb>();
                config.CreateMap<CourseProgramDb, CourseProgramBLL>();
                config.CreateMap<HomeworkBLL, HomeworkDb>();
                config.CreateMap<HomeworkDb, HomeworkBLL>();
                config.CreateMap<LearnerCourseBLL, LearnerCourseDb>();
                config.CreateMap<LearnerCourseDb, LearnerCourseBLL>();
                config.CreateMap<MaterialBLL, MaterialDb>();
                config.CreateMap<MaterialDb, MaterialBLL>();
            });

            mappingConfig.CompileMappings();

            _mapper = mappingConfig.CreateMapper();

            _service = new TeacherService(_repo, _mapper);
        }

        [Test]
        public async Task AddTeacherDirectionReturnsOne()
        {
            // Arrange
            TeacherDirectionBLL direction = new TeacherDirectionBLL()
            {
                Id = 1
            };

            // Act
            var result = await _service.AddTeacherDirection(direction);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetTeacherDirectionsReturnsTeacherDirectionBLL()
        {
            // Arrange
            TeacherDirectionBLL direction = new TeacherDirectionBLL()
            {
                Id = 1
            };

            // Act
            var result = await _service.GetTeacherDirections(direction.Id.ToString());

            // Assert
            Assert.AreEqual(direction.Id, result.FirstOrDefault().Id);
        }

        [Test]
        public async Task AddCourseReturnsOne()
        {
            // Arrange
            CourseBLL course = new CourseBLL()//создала фейковый обьект
            {
                Id = 4
            };

            // Act
            var result = await _service.AddCourse(course);//фейковый обьект отправляю в метод для тестирования

            // Assert
            Assert.AreEqual(1111, result);

        }

        [Test]
        public async Task OrderCourseReturnsOne()
        {
            // Arrange
            LearnerCourseBLL course = new LearnerCourseBLL();//создала фейковый обьект

            // Act
            var result = await _service.OrderCourse(course);//фейковый обьект отправляю в метод для тестирования

            // Assert
            Assert.AreEqual(1, result);


        }
        //[Test]
        //public async Task OrderCourseReturnsZero()
        //{
        //    // Arrange
        //    LearnerCourseBLL course = new LearnerCourseBLL();//создала фейковый обьект

        //    var mock = new Mock<ITeacherRepository>();
        //    mock.Setup(x => x.IsOrderCourse(course.IdCourse, course.IdUser).GetAwaiter().GetResult()).Returns(true);
        //    // Act
        //    var result = await _service.OrderCourse(course);//фейковый обьект отправляю в метод для тестирования

        //    // Assert
        //    Assert.AreEqual(1, result);


        //}
    } 
}
