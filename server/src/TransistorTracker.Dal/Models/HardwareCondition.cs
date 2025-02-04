using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransitorTracker.Dal.Models;

[Table("hardware_conditions")]
public partial class HardwareCondition
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [InverseProperty("Condition")]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    [InverseProperty("Condition")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
