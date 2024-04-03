using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class DataStation
{
    public int DataStationId { get; set; }

    public string? Name { get; set; }

    public string? LocationPlace { get; set; }

    public int? Station { get; set; }

    public int DataId { get; set; }

    public int Status { get; set; }

    public virtual Datum Data { get; set; } = null!;

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
