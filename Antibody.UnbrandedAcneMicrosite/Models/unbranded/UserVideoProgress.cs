﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Antibody.UnbrandedAcneMicrosite.Models.unbranded
{
    public partial class Uservideoprogress
    {
        public int VideoProgressId { get; set; }
        public string UserGuid { get; set; }
        public int? VideoId { get; set; }
        public decimal ProgressSecond { get; set; }
        public string Misc { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
