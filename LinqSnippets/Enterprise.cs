﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Employes [] Employes { get; set; } = new Employes[0];
    }
}
