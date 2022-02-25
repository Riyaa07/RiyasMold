using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RiyasMold.Models
{
    public class IceSizeViewModel
    {
        public List<Ice>? Ices { get; set; }
        public SelectList? Sizes { get; set; }
        public string? IceSize { get; set; }
        public string? SearchString { get; set; }
    }
}
