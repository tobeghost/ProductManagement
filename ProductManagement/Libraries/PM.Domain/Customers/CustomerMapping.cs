using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Customers
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.Username).IsRequired();
            Property(t => t.Password).IsRequired();
            Property(t => t.IsAdministrator).IsRequired();
            Property(t => t.Active).IsRequired();

            //Table  
            ToTable("Customers");
        }
    }
}
