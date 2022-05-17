using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Mapping
{
    public class StateProvinceMapping : EntityTypeConfiguration<StateProvince>
    {
        public StateProvinceMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CountryId).IsRequired();
            Property(t => t.Name).IsRequired();
            Property(t => t.Active).IsRequired();

            //Table  
            ToTable("StateProvinces");

            //Relationship
            HasRequired(t => t.Country).WithMany(c => c.StateProvinces).HasForeignKey(t => t.CountryId).WillCascadeOnDelete(false);
        }
    }
}
