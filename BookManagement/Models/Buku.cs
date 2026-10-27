using System;
using System.Collections.Generic;

namespace BookManagement.Models;

public partial class Buku
{
    public int Id { get; set; }

    public string Judul { get; set; } = null!;

    public string Penulis { get; set; } = null!;

    public int JenisBuku { get; set; }

    public DateTime TanggalRilis { get; set; }

    public int JumlahHalaman { get; set; }

    public virtual MasterJenisBuku JenisBukuNavigation { get; set; } = null!;
}
