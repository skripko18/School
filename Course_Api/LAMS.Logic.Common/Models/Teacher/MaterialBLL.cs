using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Models.Teacher
{
   public class MaterialBLL
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public int IdCourse { get; set; }
    }
}
