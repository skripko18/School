using LAMS.DataAccess.Common.Models.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Teacher
{
   public class TeacherDirectionConfiguration : EntityTypeConfiguration<TeacherDirectionDb>
    {
        public TeacherDirectionConfiguration()
        {
            ToTable("TeacherDirection");

            HasKey(c => c.Id);

            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            HasRequired(m => m.User)
         .WithMany(t => t.TeacherDirections)
         .HasForeignKey(m => m.IdUser)
         .WillCascadeOnDelete(true);
        }
    }
}
