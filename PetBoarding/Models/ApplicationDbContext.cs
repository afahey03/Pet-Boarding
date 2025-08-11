using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace AF.PetBoarding.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BookingModel> BookingModels { get; set; }

        public DbSet<ContactUsModel> ContactUsModels { get; set; }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }

        public DbSet<PetModel> PetModels { get; set; }

        public DbSet<PetOwnerModel> PetOwnerModels { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}