﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Models.Routing
{
    public class RoutesSet
    {
        public List<ApiRoute.Rule> Rules { get; set; }
        public string Group { get; set; }
    }
}
