using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class News
{
    public int NewsId { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }

    public int Status { get; set; }

    public int? Pic { get; set; }

    public int? Class { get; set; }

    public int? Category { get; set; }

    public int? Type { get; set; }

    public int? Topic { get; set; }

    public int AccId { get; set; }

    public virtual Account Acc { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Pic> Pics { get; set; } = new List<Pic>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
