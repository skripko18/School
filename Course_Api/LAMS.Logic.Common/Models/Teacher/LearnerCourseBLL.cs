using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Teacher
{
   public class LearnerCourseBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string IdUser { get; set; }
        public int IdCourse { get; set; }
    }
}
