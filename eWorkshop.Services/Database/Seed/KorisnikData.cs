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
            entity.HasData(new Korisnici() {Id = 1, Ime = "User", Prezime = "Admin", Email = "user.admin@tab.ba", Status = true,  NormalizedEmail = "USER.ADMIN@TAB.BA", NormalizedUserName = "USER.ADMIN", UserName = "user.admin",PasswordHash = "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", SecurityStamp = "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", ConcurrencyStamp = "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", EmailConfirmed = true },
                new Korisnici() { Id = 2, Ime = "User", Prezime = "Serviser", Email = "user.serviser@tab.ba", Status = true, NormalizedEmail = "USER.SERVISER@TAB.BA", NormalizedUserName = "USER.SERVISER", UserName = "user.serviser", PasswordHash = "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", SecurityStamp = "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", ConcurrencyStamp = "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", EmailConfirmed = true },
                new Korisnici() { Id = 3, Ime = "User", Prezime = "Pretplatnik", Email = "user.pretplatnik@tab.ba", Status = true, NormalizedEmail = "USER.PRETPLATNIK@TAB.BA", NormalizedUserName = "USER.PRETPLATNIK", UserName = "user.pretplatnik", PasswordHash = "AQAAAAEAACcQAAAAEOrxB0V96lsHoUhOZJRVnByCxcZnI3HJ5qRY1M0D0A/9T/bfpoT8/Sh3ioZZUlfWsA==", SecurityStamp = "PDKUYGIUAOVZBNHYEGVK6WMHA2IGLZHZ", ConcurrencyStamp = "4bf2a5ec-6447-44fb-993a-8ec9b854b64e", EmailConfirmed = true }
                );
        }
    }
}
