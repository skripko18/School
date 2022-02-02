using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Admin
{
    public interface IAdminRepository : IDisposable
    {
        Task<int> AddDirection(DirectionDb direction);

        Task<bool> IsDirectionAvailable(string direction);

        Task<IEnumerable<DirectionDb>> GetDirections();
        Task<IEnumerable<CourseDb>> GetCourses();

        Task<int> ApproveCourse(int id);
        Task<int> RejectCourse(int id);
        Task<string> Block(string id);
        Task<string> Unblock(string id);
    }
}
