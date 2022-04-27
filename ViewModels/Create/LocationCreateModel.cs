﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Create
{
    public class LocationCreateModel : CreateModel
    {
        public string Name { get; set; }
        public byte[] Poster { get; set; }
        public byte[] Binaries { get; set; }
    }
}
