using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Mapping
{
    public class CountryMapping : EntityTypeConfiguration<Country>
    {
        public CountryMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.TwoLetterIsoCode).IsRequired();
            Property(t => t.Status).IsRequired();

            //Table  
            ToTable("Countries");
        }
    }
}
