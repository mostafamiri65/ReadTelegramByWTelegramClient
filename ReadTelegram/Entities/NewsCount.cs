﻿using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class NewsCount
{
    public Guid Id { get; set; }

    public string? TableName { get; set; }

    public long Count { get; set; }
}
