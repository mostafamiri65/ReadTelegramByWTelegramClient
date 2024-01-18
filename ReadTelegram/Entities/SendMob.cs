using System;
using System.Collections.Generic;

namespace ReadTelegram.Entities;

public partial class SendMob
{
    public int Id { get; set; }

    public string? Mobile { get; set; }

    public bool? IsSend { get; set; }

    public string? Name { get; set; }

    public int? SendMobTypId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public bool? IsAdmin { get; set; }
}
