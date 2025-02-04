using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransitorTracker.Dal.Models;

[Table("hardware_statuses")]
public partial class HardwareStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    [InverseProperty("Status")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
