using System;
using System.Collections.Generic;

namespace Telly.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }

    public string? BrandLogo { get; set; }

    public virtual ICollection<Tvaccessory> Tvaccessories { get; set; } = new List<Tvaccessory>();

    public virtual ICollection<Tv> Tvs { get; set; } = new List<Tv>();
}
