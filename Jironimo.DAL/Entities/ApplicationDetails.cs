﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.DAL.Entities
{
    public enum PositionImage
    {
        full,
        twoImage,
        left,
        right
    }

    public class ApplicationDetails : Entity<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string? ImagePathTwo { get; set; }
        public PositionImage PositionImage { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
