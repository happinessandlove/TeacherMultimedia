using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
    public class DbEntity : DbContext, IDbContext
    {
        public DbEntity()
            : base("Data Source = (LocalDb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\MultimediaManagement.mdf;Integrated Security = True")
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DeviceUseRecord> DeviceUseRecords { get; set; }

        //Fluent API 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API 代码
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<CottonYarnSalesList>().Property(p => p.WeightAmount).HasPrecision(18, 5);


        }
    }
}