using System;

namespace HONIFS.Leads;

public abstract class LeadDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}