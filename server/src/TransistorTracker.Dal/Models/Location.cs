using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Auditing;

namespace TransistorTracker.Dal.Models;

[Table("locations")]
public partial class Location : IModelTracking
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

    [Column("house_number")]
    [StringLength(20)]
    public string? HouseNumber { get; set; }

    [Column("street")]
    [StringLength(255)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(255)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(255)]
    public string? State { get; set; }

    [Column("postal_code")]
    [StringLength(20)]
    public string? PostalCode { get; set; }

    [Column("country")]
    [StringLength(255)]
    public string? Country { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; init; }

    [Column("modified_date")]
    public DateTime? ModifiedDate { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    [InverseProperty("Location")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

    [ForeignKey("UserId")]
    [InverseProperty("Locations")]
    public virtual User User { get; set; } = null!;
}
