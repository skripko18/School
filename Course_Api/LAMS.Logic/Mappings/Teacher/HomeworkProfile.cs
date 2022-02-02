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
    class HomeworkProfile : Profile
    {
        public HomeworkProfile()
        {
            CreateMap<HomeworkBLL, HomeworkDb>().ReverseMap();
            CreateMap<HomeworkDb, HomeworkBLL>();
        }
    }
}
