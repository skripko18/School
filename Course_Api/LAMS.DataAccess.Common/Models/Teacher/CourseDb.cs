using LAMS.DataAccess.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Teacher
{
   public class CourseDb
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdTeacherDirection { get; set; }
        public virtual TeacherDirectionDb TeacherDirection { get; set; }
        public int IdDirection { get; set; }
        public virtual DirectionDb Direction { get; set; }

        public string Skills { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateStart { get; set; }


        public virtual ICollection<CourseProgramDb> CoursePrograms { get; set; }
        public virtual ICollection<HomeworkDb> Homeworks { get; set; }
        public virtual ICollection<MaterialDb> Materials { get; set; }
        public virtual ICollection<LearnerCourseDb> LearnerCourses { get; set; }
    }
}
