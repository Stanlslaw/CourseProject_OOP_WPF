using System;
using System.Collections.Generic;

namespace KeyServer.Models;

public partial class Key
{
    public string Id { get; set; } = null!;

    public string KeyProp { get; set; } = null!;

    public long IsActive { get; set; }

    public string? AppUuid { get; set; }

    public string? Hash { get; set; }
}
