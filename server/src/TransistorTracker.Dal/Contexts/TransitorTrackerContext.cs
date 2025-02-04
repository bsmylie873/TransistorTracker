using Microsoft.EntityFrameworkCore;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;

namespace TransistorTracker.Dal.Contexts;

public class TransitorTrackerContext : BaseContext, ITransitorTrackerDatabase
{
    public TransitorTrackerContext(DbContextOptions option) : base(option)
    {
    }

    public TransitorTrackerContext(string connectionString) : base(connectionString)
    {
    }
    
    public virtual DbSet<Device> Devices { get; set; }
    
    public virtual DbSet<DevicesCategory> DevicesCategories { get; set; }

    public virtual DbSet<HardwareCondition> HardwareConditions { get; set; }

    public virtual DbSet<HardwareStatus> HardwareStatuses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Part> Parts { get; set; }
    
    public virtual DbSet<PartsCategory> PartsCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }
    
    public virtual DbSet<SoftwareCategory> SoftwareCategories { get; set; }
    
    public virtual DbSet<SoftwareCompatibility> SoftwareCompatibilities { get; set; }
    
    public virtual DbSet<SoftwareCompatibilityLevel> SoftwareCompatibilityLevels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }
}