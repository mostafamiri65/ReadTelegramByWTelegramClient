using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class TempKeyWord
{
    public long Id { get; set; }

    public string? KeyWordsTitle { get; set; }

    public string? KeyWordsDtlTitle { get; set; }

    public string? KeyWordsMainTitle { get; set; }
}
