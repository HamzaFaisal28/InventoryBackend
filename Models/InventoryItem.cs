#nullable disable
using System;
using System.Collections.Generic;

namespace InventoryBackend.Models;

public partial class InventoryItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public DateTime DateAdded { get; set; }
}
