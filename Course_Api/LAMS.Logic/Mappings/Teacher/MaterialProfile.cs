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
    class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialBLL, MaterialDb>().ReverseMap();
            CreateMap<MaterialDb, MaterialBLL>();
        }

    }
}
