using System;
using System.Collections.Generic;

namespace WAP_EMHGC.Models;

public partial class Station
{
    public int StationId { get; set; }

    public int? Idstation { get; set; }

    public string? Name { get; set; }

    public int? TempMin { get; set; }

    public int? Tempmax { get; set; }

    public int? NorTemp { get; set; }

    public int? Feedlike { get; set; }

    public int? WindMax { get; set; }

    public int? GustWind { get; set; }

    public int? Pressuse { get; set; }

    public int? Hummity { get; set; }

    public int? Lat { get; set; }

    public int? Lon { get; set; }

    public int? Wave { get; set; }

    public int? HighSufw { get; set; }

    public int? LowSufw { get; set; }

    public int? Rain { get; set; }

    public int? RainPossi { get; set; }

    public int? DewPoint { get; set; }

    public int? Cloud { get; set; }

    public int? Snow { get; set; }

    public DateTime? TimeUpdate { get; set; }

    public string Note { get; set; } = null!;

    public int DataStationId { get; set; }

    public int Status { get; set; }

    public virtual DataStation DataStation { get; set; } = null!;
}
