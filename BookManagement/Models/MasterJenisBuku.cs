using System;
using System.Collections.Generic;

namespace BookManagement.Models;

public partial class MasterJenisBuku
{
    public int Id { get; set; }

    public string JenisBuku { get; set; } = null!;

    public virtual ICollection<Buku> Bukus { get; set; } = new List<Buku>();
}
