using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Auditing;

namespace TransistorTracker.Dal.Models;

[Table("users")]
[Microsoft.EntityFrameworkCore.Index("Email", Name = "users_email_key", IsUnique = true)]
[Microsoft.EntityFrameworkCore.Index("Username", Name = "users_username_key", IsUnique = true)]
public partial class User : IModelTracking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string Username { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("avatar")]
    [StringLength(255)]
    public string? Avatar { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("user_type_id")]
    public int UserTypeId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    [InverseProperty("User")]
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    [InverseProperty("User")]
    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("UserTypeId")]
    [InverseProperty("Users")]
    public virtual UserType UserType { get; set; } = null!;
}
