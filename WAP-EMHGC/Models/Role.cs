using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Role1 { get; set; }

    public int AccId { get; set; }

    public int Status { get; set; }

    public virtual Account Acc { get; set; } = null!;
}
