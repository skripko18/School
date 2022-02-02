using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Admin
{
   public class DirectionDb
    {
        public int Id { get; set; }

        public string Direction { get; set; }

        public virtual ICollection<CourseDb> Courses { get; set; }
    }
}
