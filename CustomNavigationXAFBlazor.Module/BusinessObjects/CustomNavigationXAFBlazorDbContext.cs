using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace CustomNavigationXAFBlazor.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class CustomNavigationXAFBlazorContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<CustomNavigationXAFBlazorEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new CustomNavigationXAFBlazorEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class CustomNavigationXAFBlazorDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CustomNavigationXAFBlazorEFCoreDbContext> {
	public CustomNavigationXAFBlazorEFCoreDbContext CreateDbContext(string[] args) {
		var optionsBuilder = new DbContextOptionsBuilder<CustomNavigationXAFBlazorEFCoreDbContext>();
		optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CustomNavigationXAFBlazor");
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new CustomNavigationXAFBlazorEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(CustomNavigationXAFBlazorContextInitializer))]
public class CustomNavigationXAFBlazorEFCoreDbContext : DbContext {
	public CustomNavigationXAFBlazorEFCoreDbContext(DbContextOptions<CustomNavigationXAFBlazorEFCoreDbContext> options) : base(options) {
	}
    //public DbSet<ModuleInfo> ModulesInfo { get; set; }
    public DbSet<Dashboard> Dashboards { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<PayRoll> PayRolls { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<Reports> Reports { get; set; }
    public DbSet<Settings> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
    }
}
