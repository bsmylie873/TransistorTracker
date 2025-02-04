using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransistorTracker.Dal.Models;

[Table("software")]
public partial class Software
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("avatar")]
    [StringLength(255)]
    public string? Avatar { get; set; }

    [Column("version")]
    [StringLength(50)]
    public string? Version { get; set; }

    [Column("release_date")]
    public DateOnly? ReleaseDate { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Softwares")]
    public virtual SoftwareCategory? Category { get; set; }

    [InverseProperty("Software")]
    public virtual ICollection<SoftwareCompatibility> SoftwareCompatibilities { get; set; } = new List<SoftwareCompatibility>();
}
