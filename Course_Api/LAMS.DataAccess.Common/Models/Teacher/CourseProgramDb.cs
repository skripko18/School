using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Teacher
{
  public  class CourseProgramDb
    {
        public int Id { get; set; }
        public string Theme { get; set; }

        public int IdCourse { get; set; }
        public virtual CourseDb Course { get; set; }

    }
}
