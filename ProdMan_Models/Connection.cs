using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdMan_Models.Tables;

namespace ProdMan_Models
{

    public class Connection : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Connection> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Connection>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.Product> Producten { get; set; }

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.Btw> Btws { get; set; }        

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.ProductEigenschappen> ProductEigenschappen { get; set; }

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.Leverancier> Leveranciers { get; set; }

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.ProductEigenschappenKoppeling> ProductEigenschappenKoppelingen { get; set; }

        public System.Data.Entity.DbSet<ProdMan_Models.Tables.ProductGroep> ProductGroepen{ get; set; }     
        
    }
}
