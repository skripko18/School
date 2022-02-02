using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Common.Repositories.Teacher;
using LAMS.DataAccess.Common.Repositories.Users;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories.Admin;
using LAMS.DataAccess.Repositories.Teacher;
using LAMS.DataAccess.Repositories.Users;
using Ninject.Modules;

namespace LAMS.DataAccess
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            Bind<DBContext>().ToSelf().InTransientScope();

            BindRepositories();
        }

        private void BindRepositories() { 

            Bind<IUserRepository>().To<UserRepository>();          
            Bind<IAdminRepository>().To<AdminRepository>();        
            Bind<ITeacherRepository>().To<TeacherRepository>();         
        }
    }
}
