using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities;

public partial class role
{
    public int id { get; set; }

    public string code { get; set; } = null!;

    public string name { get; set; } = null!;

    public virtual ICollection<user> users { get; set; } = new List<user>();
}
