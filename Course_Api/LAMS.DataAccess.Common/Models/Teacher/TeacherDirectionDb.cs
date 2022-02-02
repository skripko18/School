using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Teacher
{
    public class TeacherDirectionDb
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public string IdUser { get; set; }
        public virtual UserDb User { get; set; }

        public string Experience { get; set; }
        public string Workplace { get; set; }

        public virtual ICollection<CourseDb> Courses { get; set; }
    }
}
