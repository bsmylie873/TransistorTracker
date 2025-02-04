using Microsoft.EntityFrameworkCore;
using TransitorTracker.Dal.Interfaces;
using TransitorTracker.Dal.Models;

namespace TransitorTracker.Dal.Contexts;

public class TransitorTrackerContext : BaseContext, ITransitorTrackerDatabase
{
    public TransitorTrackerContext(DbContextOptions option) : base(option)
    {
    }

    public TransitorTrackerContext(string connectionString) : base(connectionString)
    {
    }
    
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<HardwareCondition> HardwareConditions { get; set; }

    public virtual DbSet<HardwareStatus> HardwareStatuses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }
}