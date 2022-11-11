using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public interface IBase
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
