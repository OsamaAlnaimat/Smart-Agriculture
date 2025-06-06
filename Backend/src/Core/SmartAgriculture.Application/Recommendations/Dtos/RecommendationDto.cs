﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Recommendations.Dtos
{
    public class RecommendationDto
    {
        public string parameter { get; set; } = default!;
        public string value { get; set; } = default!;
        public string status { get; set; } = default!;
        public string advice { get; set; } = default!;
    }
}
