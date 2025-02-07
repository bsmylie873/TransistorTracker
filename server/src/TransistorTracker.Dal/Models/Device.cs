using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Auditing;

namespace TransistorTracker.Dal.Models;

[Table("devices")]
public partial class Device : IModelTracking
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

    [Column("model")]
    [StringLength(255)]
    public string Model { get; set; } = null!;

    [Column("wattage")]
    public int? Wattage { get; set; }

    [Column("colour")]
    [StringLength(50)]
    public string? Colour { get; set; }

    [Column("wireless")]
    public bool? Wireless { get; set; }

    [Column("release_date")]
    public DateOnly? ReleaseDate { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; init; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("location_id")]
    public int? LocationId { get; set; }

    [Column("condition_id")]
    public int ConditionId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Devices")]
    public virtual DevicesCategory Category { get; set; } = null!;

    [ForeignKey("ConditionId")]
    [InverseProperty("Devices")]
    public virtual HardwareCondition Condition { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("Devices")]
    public virtual Location? Location { get; set; }

    [InverseProperty("Device")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

    [InverseProperty("Device")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Device")]
    public virtual ICollection<SoftwareCompatibility> SoftwareCompatibilities { get; set; } = new List<SoftwareCompatibility>();

    [ForeignKey("StatusId")]
    [InverseProperty("Devices")]
    public virtual HardwareStatus Status { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Devices")]
    public virtual User User { get; set; } = null!;
}
