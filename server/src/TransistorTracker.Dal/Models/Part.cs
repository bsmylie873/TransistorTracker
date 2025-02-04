using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransitorTracker.Dal.Models;

[Table("parts")]
public partial class Part
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

    [Column("description")]
    public string? Description { get; set; }

    [Column("wattage")]
    public int? Wattage { get; set; }

    [Column("colour")]
    [StringLength(50)]
    public string? Colour { get; set; }

    [Column("release_date")]
    public DateOnly? ReleaseDate { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime? CreatedDate { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("device_id")]
    public int? DeviceId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("location_id")]
    public int? LocationId { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [Column("condition_id")]
    public int? ConditionId { get; set; }

    [Column("status_id")]
    public int? StatusId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Parts")]
    public virtual PartsCategory? Category { get; set; }

    [ForeignKey("ConditionId")]
    [InverseProperty("Parts")]
    public virtual HardwareCondition? Condition { get; set; }

    [ForeignKey("DeviceId")]
    [InverseProperty("Parts")]
    public virtual Device? Device { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Parts")]
    public virtual Location? Location { get; set; }

    [InverseProperty("Part")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Part")]
    public virtual ICollection<SoftwareCompatibility> SoftwareCompatibilities { get; set; } = new List<SoftwareCompatibility>();

    [ForeignKey("StatusId")]
    [InverseProperty("Parts")]
    public virtual HardwareStatus? Status { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Parts")]
    public virtual User? User { get; set; }
}
