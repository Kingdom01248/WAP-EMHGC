using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Topic
{
    public int TopicId { get; set; }

    public string? Name { get; set; }

    public int NewsId { get; set; }

    public int Status { get; set; }

    public int AccId { get; set; }

    public virtual Account Acc { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
