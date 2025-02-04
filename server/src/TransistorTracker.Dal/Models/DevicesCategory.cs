using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransistorTracker.Dal.Models;

[Table("devices_categories")]
public partial class DevicesCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
