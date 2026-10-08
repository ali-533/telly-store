using System;
using System.Collections.Generic;

namespace Telly.Models;

public partial class Tv
{
    public int Id { get; set; }

    public string? Tvname { get; set; }

    public string? Tvtype { get; set; }

    public string? TvimageQuality { get; set; }

    public int? FrameFrequency { get; set; }

    public double? Price { get; set; }

    public string? TvUrl { get; set; }

    public string? Stars { get; set; }

    public int? BrandId { get; set; }

    public int? DimensionId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Dimension? Dimension { get; set; }
}
