using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EternaTemplateFullStack.Models
{
    public class Service : BaseEntity
    {
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }
        [StringLength(maximumLength: 250)]
        public string Desc { get; set; }
    }
}
