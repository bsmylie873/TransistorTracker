using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Auditing;

namespace TransistorTracker.Dal.Models;

[Table("reviews")]
public partial class Review : IModelTracking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("review_text")]
    public string? ReviewText { get; set; }

    [Column("rating")]
    public int Rating { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; init; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("device_id")]
    public int? DeviceId { get; set; }

    [Column("part_id")]
    public int? PartId { get; set; }

    [ForeignKey("DeviceId")]
    [InverseProperty("Reviews")]
    public virtual Device? Device { get; set; }

    [ForeignKey("PartId")]
    [InverseProperty("Reviews")]
    public virtual Part? Part { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User User { get; set; } = null!;
}
