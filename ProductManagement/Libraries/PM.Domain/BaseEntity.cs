using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PM.Domain
{
    public partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets identity for all entity model
        /// </summary>
        public int Id { get; set; }
    }
}
