using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Directory
{
    public class CurrencyMapping : EntityTypeConfiguration<Currency>
    {
        public CurrencyMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.CurrencyCode).IsRequired();
            Property(t => t.Rate).IsRequired();
            Property(t => t.NumberDecimal).IsRequired();
            Property(t => t.Status).IsRequired();

            //Table  
            ToTable("Currencies");
        }
    }
}
