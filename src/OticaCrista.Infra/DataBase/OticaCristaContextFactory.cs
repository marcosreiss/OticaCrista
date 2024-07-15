using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OticaCrista.Infra.DataBase
{
    public class OticaCristaContextFactory : IDesignTimeDbContextFactory<OticaCristaContext>
    {
        public OticaCristaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OticaCristaContext>();
            optionsBuilder.UseMySQL("Server=localhost;Port=3307;User=root;Password=M@r1ll10n;Database=oticacristadb");

            return new OticaCristaContext(optionsBuilder.Options);
        }
    }
}
