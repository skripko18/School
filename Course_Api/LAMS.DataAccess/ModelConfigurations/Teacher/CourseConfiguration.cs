using LAMS.DataAccess.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Teacher
{
    class CourseConfiguration : EntityTypeConfiguration<CourseDb>
    {
        public CourseConfiguration()
        {
            ToTable("Course");

            HasKey(c => c.Id);

            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            HasRequired(m => m.TeacherDirection)
            .WithMany(t => t.Courses)
            .HasForeignKey(m => m.IdTeacherDirection)
            .WillCascadeOnDelete(false);

            HasRequired(m => m.Direction)
            .WithMany(t => t.Courses)
            .HasForeignKey(m => m.IdDirection)
            .WillCascadeOnDelete(false);


        }
    }
}
