using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class SendMobTyp
{
    public byte Code { get; set; }

    public string Title { get; set; } = null!;
}
