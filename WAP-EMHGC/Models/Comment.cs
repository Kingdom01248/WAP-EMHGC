using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? Content { get; set; }

    public int? AccountId { get; set; }

    public int Pic { get; set; }

    public DateTime? DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }

    public int NewsId { get; set; }

    public int Status { get; set; }

    public int AccId { get; set; }

    public virtual Account Acc { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
