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
            entity.HasData(new Korisnici() {Id = 1, Ime = "User", Prezime = "Admin", Email = "user.admin@tab.ba", Status = true,  NormalizedEmail = "USER.ADMIN@TAB.BA", NormalizedUserName = "USER.ADMIN", UserName = "user.admin",PasswordHash = "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", SecurityStamp = "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", ConcurrencyStamp = "6934403b-2af5-4a78-8c73-6f10971a4fa4", EmailConfirmed = true },
                new Korisnici() { Id = 2, Ime = "User", Prezime = "Serviser", Email = "user.serviser@tab.ba", Status = true, NormalizedEmail = "USER.SERVISER@TAB.BA", NormalizedUserName = "USER.SERVISER", UserName = "user.serviser", PasswordHash = "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", SecurityStamp = "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", ConcurrencyStamp = "6934403b-2af5-4a78-8c73-6f10971a4fa4", EmailConfirmed = true },
                new Korisnici() { Id = 3, Ime = "User", Prezime = "Pretplatnik", Email = "user.pretplatnik@tab.ba", Status = true, NormalizedEmail = "USER.PRETPLATNIK@TAB.BA", NormalizedUserName = "USER.PRETPLATNIK", UserName = "user.pretplatnik", PasswordHash = "AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==", SecurityStamp = "76KTGLXOVWQI7YTYAKT4G2YVOKJBFEDL", ConcurrencyStamp = "6934403b-2af5-4a78-8c73-6f10971a4fa4", EmailConfirmed = true, RadnaJedinica = "Sarajevo" }
                );
        }
    }
}
