using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.Logic.Common.Models.Teacher;

namespace LAMS.Logic.Tests.Moqs
{
    public class AdminRepositoryMoq:IAdminRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddDirection(DirectionDb direction)
        {
            return direction.Id;
        }

        public async Task<bool> IsDirectionAvailable(string direction)
        {
            return true;
        }

        public async Task<IEnumerable<DirectionDb>> GetDirections()
        {
            return new List<DirectionDb>()
            {
                new DirectionDb()
                {
                    Id=1,
                    Direction = "Direction1"
                },
                new DirectionDb()
                {
                    Id=2,
                    Direction = "Direction2"
                },
                new DirectionDb()
                {
                    Id=3,
                    Direction = "Direction3"
                }
            };
        }

        public async Task<IEnumerable<CourseDb>> GetCourses()
        {
            return new List<CourseDb>()
            {
                new CourseDb()
                {
                    Id = 1,
                    Name = "Name1"
                },
                new CourseDb()
                {
                    Id = 2,
                    Name = "Name2"
                },
                new CourseDb()
                {
                    Id = 3,
                    Name = "Name3"
                }
            };
        }

        public async Task<int> ApproveCourse(int id)
        {
            return 1;
        }

        public async Task<int> RejectCourse(int id)
        {
            return 0;
        }

        public Task<string> Block(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Unblock(string id)
        {
            throw new NotImplementedException();
        }
    }
}
