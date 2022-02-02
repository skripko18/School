
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Teacher;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.ModelConfigurations.Admin;
using LAMS.DataAccess.ModelConfigurations.Auth;
using LAMS.DataAccess.ModelConfigurations.Teacher;
using System.Data.Entity;

namespace LAMS.DataAccess.Contexts
{
 
    public class DBContext : DbContext
    {
        public DBContext() : base("Connection") { }
        public DBContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new DirectionConfiguration());
            modelBuilder.Configurations.Add(new TeacherDirectionConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseProgramConfiguration());
            modelBuilder.Configurations.Add(new HomeworkConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new LearnerCourseConfiguration());

        }
        public IDbSet<UserDb> Users { get; set; }

        public IDbSet<RoleDb> Roles { get; set; }
        public IDbSet<DirectionDb> Directions { get; set; }
        public IDbSet<TeacherDirectionDb> TeacherDirections { get; set; }
        public IDbSet<CourseDb> Courses { get; set; }
        public IDbSet<CourseProgramDb> CoursePrograms { get; set; }
        public IDbSet<HomeworkDb> Homeworks { get; set; }
        public IDbSet<MaterialDb> Materials { get; set; }
        public IDbSet<LearnerCourseDb> LearnerCourses { get; set; }
   
    }
}
