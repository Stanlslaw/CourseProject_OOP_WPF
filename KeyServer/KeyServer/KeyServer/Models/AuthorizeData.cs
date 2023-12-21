using System;

namespace PDDTestBelarus.Models;

[Serializable]
public class AuthorizeData
{
    public string uuid { get; set; }
    public string hash { get; set; } = null;
}