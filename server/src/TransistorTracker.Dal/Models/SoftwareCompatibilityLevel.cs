using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransistorTracker.Dal.Models;

[Table("software_compatibility_levels")]
public partial class SoftwareCompatibilityLevel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [InverseProperty("SoftwareCompatibilityLevel")]
    public virtual ICollection<SoftwareCompatibility> SoftwareCompatibilities { get; set; } = new List<SoftwareCompatibility>();
}
