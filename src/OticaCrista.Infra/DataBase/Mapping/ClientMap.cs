using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistOtica.Models.Client;

namespace SistOtica.Data.Mapping
{
    public class ClientMap
    {
        public ClientMap(EntityTypeBuilder<ClientModel> tb) 
        { 
            tb.HasKey(x => x.Id);
            tb.HasMany(x => x.PhoneNumber)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            tb.HasMany(x => x.References)
                .WithOne(x => x.Client)
                .HasForeignKey(x =>x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
