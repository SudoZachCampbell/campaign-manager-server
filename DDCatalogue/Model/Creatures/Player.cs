﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Creatures
{
    public class Player : ICreature, IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
