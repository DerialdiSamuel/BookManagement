using System;
using System.Collections.Generic;

namespace BookManagement.Models;

public partial class HistoriBuku
{
    public int Id { get; set; }

    public int BukuId { get; set; }

    public string Aksi { get; set; } = null!;

    public string? DataLama { get; set; }

    public string? DataBaru { get; set; }

    public DateTime TanggalPerubahan { get; set; }
}
