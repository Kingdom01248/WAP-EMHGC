using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Note
{
    public int NoteId { get; set; }

    public string? Name { get; set; }

    public string NoteAbout { get; set; } = null!;

    public string NoteNews { get; set; } = null!;

    public string NoteObj { get; set; } = null!;

    public string Note1 { get; set; } = null!;

    public int Status { get; set; }

    public int AccId { get; set; }
}
