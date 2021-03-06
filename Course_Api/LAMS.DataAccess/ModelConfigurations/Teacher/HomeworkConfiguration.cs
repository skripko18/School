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
  public  class HomeworkConfiguration : EntityTypeConfiguration<HomeworkDb>
    {
        public HomeworkConfiguration()
        {
            ToTable("Homework");

            HasKey(c => c.Id);

            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.Course)
            .WithMany(t => t.Homeworks)
            .HasForeignKey(m => m.IdCourse)
            .WillCascadeOnDelete(true);

        }
    }
}
