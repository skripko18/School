using AutoMapper;
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.Logic.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Mappings.Admin
{
    public class DirectionProfile : Profile
    {
        public DirectionProfile()
        {
            CreateMap<DirectionBLL, DirectionDb>().ReverseMap();
            CreateMap<DirectionDb, DirectionBLL>();
        }
    }
}
