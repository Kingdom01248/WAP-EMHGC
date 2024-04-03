using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Forecast
{
    public int ForecastId { get; set; }

    public string? Name { get; set; }

    public string ForecastAsia { get; set; } = null!;

    public string ForecastEnso { get; set; } = null!;

    public string ForecastTemp { get; set; } = null!;

    public string ForecastWind { get; set; } = null!;

    public string ForecastSea { get; set; } = null!;

    public string Note { get; set; } = null!;

    public int Status { get; set; }

    public int DataId { get; set; }

    public virtual Datum Data { get; set; } = null!;
}
