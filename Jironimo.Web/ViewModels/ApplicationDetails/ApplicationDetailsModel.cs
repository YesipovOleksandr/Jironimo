﻿using Jironimo.Common.Models.Aplications;

namespace Jironimo.Web.ViewModels.ApplicationDetails
{
    public class ApplicationDetailsModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string? ImagePathTwo { get; set; }
        public PositionImage PositionImage { get; set; }
    }
}
