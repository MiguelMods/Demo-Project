using demo.proyect.domain.Entities;
using demo.proyect_persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Context;

public class DemoProjectApplicationContext(DbContextOptions<DemoProjectApplicationContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<AreaEntity> AreaEntities { get; set; }
    public DbSet<PriorityTypeEntity> PriorityTypeEntities { get; set; }
    public DbSet<ProjectDevelopmentTypeEntity> ProjectDevelopmentTypeEntities  { get; set; }
    public DbSet<ProjectTypeEntity> ProjectTypeEntities  { get; set; }
    public DbSet<ProjectEntity> ProjectEntities  { get; set; }
    public DbSet<ActionPlanEntity> ActionPlanEntities { get; set; }
    public DbSet<GoalEntity> GoalEntities { get; set; }
    public DbSet<PerspectiveEntity> PerspectiveEntities { get; set; }
    public DbSet<InitiativeEntity> InitiativeEntities { get; set; }
    public DbSet<PeriodEntity> PeriodEntities { get; set; }
    public DbSet<GoalTypeEntity> GoalTypes { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AreaEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PriorityTypeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectDevelopmentTypeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectTypeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ActionPlanEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GoalEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PerspectiveEntityConfiguration());
        modelBuilder.ApplyConfiguration(new InitiativeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PeriodEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GoalTypeEntityConfiguration());
    }
}
