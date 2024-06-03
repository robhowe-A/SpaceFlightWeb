using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Spaceflight_News_Server.Models;

namespace Spaceflight_News_Server.Data
{

    public class Spaceflight_News_MySQLContext : DbContext
    {
        public Spaceflight_News_MySQLContext(DbContextOptions<Spaceflight_News_MySQLContext> options)
            : base(options)
        {
        }
        static readonly string connectionString = "<Redacted for privacy>";
        //List of Articles
        public DbSet<Spaceflight_News_Server.Models.Article> Article { get; set; } = default!;
        //List of APODs
        public DbSet<Spaceflight_News_Server.Models.APOD> APOD { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.Create(major:8, minor:0, patch:36, serverType:ServerType.MySql)) ;
        }
    }
}
