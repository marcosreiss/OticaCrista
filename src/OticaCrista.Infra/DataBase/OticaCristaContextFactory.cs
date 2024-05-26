using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OticaCrista.Infra.DataBase
{
    public class OticaCristaContextFactory : IDesignTimeDbContextFactory<OticaCristaContext>
    {
        public OticaCristaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OticaCristaContext>();
            optionsBuilder.UseMySQL("Server=roundhouse.proxy.rlwy.net; User=root; Password=GTwHDxUKycANtQvesIKsytxrlRVDGFCY;Port=51555; Database=oticacristadb");

            return new OticaCristaContext(optionsBuilder.Options);
        }
    }
}
