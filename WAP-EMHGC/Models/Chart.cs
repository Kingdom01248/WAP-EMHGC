using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Chart
{
    public int ChartId { get; set; }

    public string? Name { get; set; }

    public string GraphVie { get; set; } = null!;

    public string GraphJtwc { get; set; } = null!;

    public string GraphObj { get; set; } = null!;

    public string GraphTb { get; set; } = null!;

    public string GraphWo { get; set; } = null!;

    public string GraphOrther { get; set; } = null!;

    public int DataId { get; set; }

    public int Status { get; set; }

    public virtual Datum Data { get; set; } = null!;
}
