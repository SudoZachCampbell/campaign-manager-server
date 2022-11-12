using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class Base
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
    }
}
