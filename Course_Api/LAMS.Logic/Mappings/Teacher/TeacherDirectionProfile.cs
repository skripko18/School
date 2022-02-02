using AutoMapper;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.Logic.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Teacher
{
   public class TeacherDirectionProfile : Profile
    {
        public TeacherDirectionProfile()
        {
            CreateMap<TeacherDirectionBLL, TeacherDirectionDb>().ReverseMap();
            CreateMap<TeacherDirectionDb, TeacherDirectionBLL>();
        }
    }
}
