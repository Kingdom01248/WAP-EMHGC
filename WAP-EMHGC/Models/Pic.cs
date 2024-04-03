using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Pic
{
    public int PicId { get; set; }

    public string? Img { get; set; }

    public string? Title { get; set; }

    public int NewsId { get; set; }

    public int Status { get; set; }

    public virtual News News { get; set; } = null!;
}
