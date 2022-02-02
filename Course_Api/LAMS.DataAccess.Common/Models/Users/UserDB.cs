using LAMS.DataAccess.Common.Models.Teacher;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Users
{
    /// <summary>
    /// DataBase entity of user.
    /// </summary>
    public class UserDb
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
        public string FIO { get; set; }
        public string Status { get; set; }

        public string RoleId { get; set; }
        public virtual RoleDb Role { get; set; }

        public virtual ICollection<TeacherDirectionDb> TeacherDirections { get; set; }
        public virtual ICollection<LearnerCourseDb> LearnerCourses { get; set; }

    }
}
