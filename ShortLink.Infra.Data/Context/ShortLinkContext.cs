using Microsoft.EntityFrameworkCore;
using shortLink.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using shortLink.Domain.Models.Link;

namespace ShortLink.Infra.Data.Context
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }
        #region account
        public DbSet<User> users { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Os> Os { get; set; }
        public DbSet<RequestUrl> RequestUrls { get; set; }
        #endregion
        #region
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
