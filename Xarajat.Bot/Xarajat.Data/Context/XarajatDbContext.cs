using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Xarajat.Data.Data;
using Xarajat.Data.Entities;

namespace Xarajat.Data.Context;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions<XarajatDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Outlay> Outlays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        new OutLaysConfiguration().Configure(modelBuilder.Entity<Outlay>());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(XarajatDbContext).Assembly);
    }
}
