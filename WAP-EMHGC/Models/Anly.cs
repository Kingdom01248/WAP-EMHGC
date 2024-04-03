using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Anly
{
    public int AnlyId { get; set; }

    public string? Name { get; set; }

    public int DataId { get; set; }

    public int Status { get; set; }

    public virtual Datum Data { get; set; } = null!;
}
