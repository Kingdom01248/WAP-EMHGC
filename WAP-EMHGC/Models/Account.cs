using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Account
{
    public int AccId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public bool PhoneConfirmed { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? Password { get; set; }

    public bool PasswordAconfirmed { get; set; }

    public DateTime? DateCreate { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime LockoutEndDateUtc { get; set; }

    public bool AccessFailedCountA { get; set; }

    public string? Address { get; set; }

    public int Role { get; set; }

    public string Note { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
