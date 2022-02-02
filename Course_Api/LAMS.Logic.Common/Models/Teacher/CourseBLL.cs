using LAMS.Logic.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Teacher
{
   public class CourseBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdTeacherDirection { get; set; }
        public virtual TeacherDirectionBLL TeacherDirection { get; set; }
        public int IdDirection { get; set; }
        public virtual DirectionBLL Direction { get; set; }

        public string Description { get; set; }
        public string Skills { get; set; }
        public DateTime DateStart { get; set; }
        public string Status { get; set; }

    }
}
