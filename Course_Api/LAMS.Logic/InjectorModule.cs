using AutoMapper;
using FluentValidation;
using LAMS.Logic.Common.Services.Admin;
using LAMS.Logic.Common.Services.Teacher;
using LAMS.Logic.Common.Services.Users;
using LAMS.Logic.Mappings.Admin;
using LAMS.Logic.Mappings.Teacher;
using LAMS.Logic.Mappings.Users;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Services.Teacher;
using LAMS.Logic.Services.Users;
using Ninject.Modules;
using System.Reflection;

namespace LAMS.Logic
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            BindValidators();
            BindMappers();

            BindLogsServices();
        }

        private void BindValidators()
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => Kernel.Bind(result.InterfaceType).To(result.ValidatorType).InTransientScope());
        }

        private void BindMappers()
        {

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<UserService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<RegistrationService>();



            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DirectionProfile>();
                    cfg.AddProfile<CourseProfile>();
                    cfg.AddProfile<CourseProgramProfile>();
                    cfg.AddProfile<MaterialProfile>();
                    cfg.AddProfile<HomeworkProfile>();
                })))
                .WhenInjectedExactlyInto<AdminService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<TeacherDirectionProfile>();
                    cfg.AddProfile<CourseProfile>();
                    cfg.AddProfile<CourseProgramProfile>();
                    cfg.AddProfile<LearnerCourseProfile>();
                    cfg.AddProfile<MaterialProfile>();
                    cfg.AddProfile<HomeworkProfile>();
                })))
                .WhenInjectedExactlyInto<TeacherService>();



        }


        private void BindLogsServices()
        {
            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IUserService>().To<UserService>();
            Bind<IAdminService>().To<AdminService>();
            Bind<ITeacherService>().To<TeacherService>();
        }
    }
}
