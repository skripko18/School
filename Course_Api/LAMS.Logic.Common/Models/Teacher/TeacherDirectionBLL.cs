using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Teacher
{
   public class TeacherDirectionBLL
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public string IdUser { get; set; }

        public string Experience { get; set; }
        public string Workplace { get; set; }
    }
}
