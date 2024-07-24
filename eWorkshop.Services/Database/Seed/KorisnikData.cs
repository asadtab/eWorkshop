using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class KorisnikData
    {
        public static void SeedData(this EntityTypeBuilder<Korisnici> entity)
        {
            entity.HasData(new Korisnici() {Id = 1, Ime = "Asad", Prezime = "Admin", Email = "asad.admin@tab.ba", Status = true,  NormalizedEmail = "ASAD.ADMIN@TAB.BA", NormalizedUserName = "ASAD.ADMIN", UserName = "asad.admin",PasswordHash = "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", SecurityStamp = "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", ConcurrencyStamp = "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", EmailConfirmed = true },
                new Korisnici() { Id = 2, Ime = "Asad", Prezime = "Serviser", Email = "asad.serviser@tab.ba", Status = true, NormalizedEmail = "ASAD.SERVISER@TAB.BA", NormalizedUserName = "ASAD.SERVISER", UserName = "asad.serviser", PasswordHash = "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", SecurityStamp = "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", ConcurrencyStamp = "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", EmailConfirmed = true });
        }
    }
}
