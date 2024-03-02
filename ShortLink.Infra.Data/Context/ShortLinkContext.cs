using Microsoft.EntityFrameworkCore;
using shortLink.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace ShortLink.Infra.Data.Context
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }
        #region account
        public DbSet<User> users { get; set; }
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
