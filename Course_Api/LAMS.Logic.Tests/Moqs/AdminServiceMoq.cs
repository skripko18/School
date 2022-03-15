using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Teacher;
using LAMS.Logic.Common.Services.Admin;

namespace LAMS.Logic.Tests.Moqs
{
   public class AdminServiceMoq:IAdminService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddDirection(DirectionBLL direction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DirectionBLL>> GetDirections()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseBLL>> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Task<int> ApproveCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RejectCourse(int id)
        {
            throw new NotImplementedException();
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
