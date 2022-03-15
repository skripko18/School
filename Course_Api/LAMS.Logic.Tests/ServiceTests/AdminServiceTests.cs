using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Admin;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Tests.Moqs;
using NUnit.Framework;

namespace LAMS.Logic.Tests.ServiceTests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private IAdminRepository _repo;
        private IAdminService _service;
        private IMapper _mapper;

        public AdminServiceTests()
        {
            _repo = new AdminRepositoryMoq();

            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<DirectionBLL, DirectionDb>();
                config.CreateMap<DirectionDb, DirectionBLL>();
            });

            mappingConfig.CompileMappings();
            
            _mapper = mappingConfig.CreateMapper();

            _service = new AdminService(_repo, _mapper);
        }

        [Test]
        public async Task AddDirectionReturnsId()// что возвращает сервис
        {
            // Arrange
            DirectionBLL direction = new DirectionBLL()// создается обьект класса direction bll
            {
                Id = 1,
                Direction = "Direction1"
            };

            // Act
            var result = await _service.AddDirection(direction);

            // Assert
            Assert.AreEqual(direction.Id,result);
        }

        [Test]
        public async Task GetDirectionsReturnsDirectionBLLs()
        {
            // Arrange
            List<DirectionDb> directionDbs = new List<DirectionDb>()
            {
                new DirectionDb()
                {
                    Id = 1,
                    Direction = "Direction1"
                },
                new DirectionDb()
                {
                    Id = 2,
                    Direction = "Direction2"
                },
                new DirectionDb()
                {
                    Id = 3,
                    Direction = "Direction3"
                }
            };

            // Act
            var result = await _service.GetDirections();

            // Assert
            Assert.AreEqual(result.FirstOrDefault().Id, _mapper.Map<DirectionBLL>(directionDbs.FirstOrDefault()).Id);

        }

        [Test]
        public async Task GetCoursesReturnsCourseBLLs()
        {
            // Arrange
            List<CourseBLL> directionDbs = new List<CourseBLL>()
            {
                new CourseBLL()
                {
                    Id = 1,
                    Name = "Name1"
                },
                new CourseBLL()
                {
                    Id = 2,
                    Name = "Name2"
                },
                new CourseBLL()
                {
                    Id = 3,
                    Name = "Name3"
                }
            };

            // Act
            var result = await _service.GetCourses();

            // Assert
            Assert.AreEqual(result.FirstOrDefault().Id, directionDbs.FirstOrDefault().Id);

        }

        [Test]
        public async Task ApproveCourseReturnsOne()
        {
            // Act
            var result = await _service.ApproveCourse(1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task RejectCourseReturnsZero()
        {
            // Act
            var result = await _service.RejectCourse(1);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
