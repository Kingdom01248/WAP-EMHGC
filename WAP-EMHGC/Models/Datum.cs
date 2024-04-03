using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Datum
{
    public int DataId { get; set; }

    public string? Name { get; set; }

    public int? Chart { get; set; }

    public int? DataStation { get; set; }

    public int? Anly { get; set; }

    public int? Forecast { get; set; }

    public int? Pdf { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Anly> Anlies { get; set; } = new List<Anly>();

    public virtual ICollection<Chart> Charts { get; set; } = new List<Chart>();

    public virtual ICollection<DataStation> DataStations { get; set; } = new List<DataStation>();

    public virtual ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();
}
