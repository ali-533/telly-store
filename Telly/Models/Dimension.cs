using System;
using System.Collections.Generic;

namespace Telly.Models;

public partial class Dimension
{
    public int DimensionId { get; set; }

    public int Size { get; set; }

    public virtual ICollection<Tv> Tvs { get; set; } = new List<Tv>();
}
