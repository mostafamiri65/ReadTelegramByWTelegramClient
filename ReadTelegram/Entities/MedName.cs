using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class MedName
{
    public int Id { get; set; }

    public string? EnName { get; set; }

    public string? FrName { get; set; }
}
