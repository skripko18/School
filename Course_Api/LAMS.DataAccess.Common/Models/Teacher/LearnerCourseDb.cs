using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Teacher
{
   public class LearnerCourseDb
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string IdUser { get; set; }
        public virtual UserDb User { get; set; }
        public int IdCourse { get; set; }
        public virtual CourseDb Course { get; set; }
    }
}
