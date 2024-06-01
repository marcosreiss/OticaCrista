using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistOtica.Data.Mapping;
using SistOtica.Models.Client;
using SistOtica.Models.Product;
using SistOtica.Models.Sale;
using SistOtica.Models.Service;

namespace OticaCrista.Infra.DataBase
{
    public class OticaCristaContext : DbContext
    {
        public OticaCristaContext(DbContextOptions<OticaCristaContext> options)
            : base(options)
        {
        }

        //Client
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ClientContact> Contacts { get; set; }
        public DbSet<ClientReferences> References { get; set; }

        //Product and Service
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<ServiceModel> Services { get; set; }

        //Sale
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<SaleProtocolModel> SaleProtocols { get; set; }
        public DbSet<PrescriptionModel> Prescriptions { get; set; }
        public DbSet<FrameModel> Frames { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClientMap(modelBuilder.Entity<ClientModel>());
            new ProductMap(modelBuilder.Entity<ProductModel>());
            new SaleMap(modelBuilder.Entity<SaleModel>());

            modelBuilder.Entity<ClientModel>(client=>
            {
                client.Property(x => x.BornDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime=> DateOnly.FromDateTime(dateTime))
        {
        }
    }

    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (d1, d2) => d1.DayNumber == d2.DayNumber,
            d => d.GetHashCode())
        {
        }
    }
}
