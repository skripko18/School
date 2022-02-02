using LAMS.DataAccess.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Admin
{
   public class DirectionConfiguration : EntityTypeConfiguration<DirectionDb>
    {
        public DirectionConfiguration()
        {
            ToTable("Direction");

            HasKey(c => c.Id);

            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }
    }
}
