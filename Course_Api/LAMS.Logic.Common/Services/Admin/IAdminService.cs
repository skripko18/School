using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Admin
{
   public interface IAdminService : IDisposable
    {
        Task<int> AddDirection(DirectionBLL direction);
        Task<IEnumerable<DirectionBLL>> GetDirections();

        Task<IEnumerable<CourseBLL>> GetCourses();

        Task<int> ApproveCourse(int id);
        Task<int> RejectCourse(int id);
        Task<string> Block(string id);
        Task<string> Unblock(string id);
    }
}
