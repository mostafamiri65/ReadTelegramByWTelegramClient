using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class NewsLike
{
    public long Id { get; set; }

    public long NewsId { get; set; }

    public long NewsLinkeId { get; set; }

    public int IsDelete { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public long? UserModifiedId { get; set; }

    public string? ModifiedIp { get; set; }
}
