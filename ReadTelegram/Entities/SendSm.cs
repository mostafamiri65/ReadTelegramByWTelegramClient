using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class SendSm
{
    public int Id { get; set; }

    public int? NewsRssReedId { get; set; }

    public string? Mobile { get; set; }

    public string? SendedText { get; set; }

    public string? Detail { get; set; }

    public bool? IsSended { get; set; }

    public DateTime? SendDate { get; set; }

    public long? NotOilNewsForSendingSmsId { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public long? MsgId { get; set; }
}
