using HouseDesignsEcommerce.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseDesignsEcommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public ApplicationDbContext _context;

        public DbSet<HouseDesign> HouseDesigns { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
        public DbSet<HouseDesignCategory> HouseDesignCategory { get; set; }

        /*public ApplicationDbContext(ApplicationDbContext context)
        {
            _context = context;
        }*/

        /* private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-HouseDesignsEcommerce-A58DB898-3B4C-4946-8F0E-43340591B593;Trusted_Connection=True;MultipleActiveResultSets=true";

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(connectionString);
         }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();
        }

        /*  protected override void OnModelCreating(ModelBuilder builder)
          {
            /*  base.OnModelCreating(builder);


              _context.Database.EnsureCreated();
              if (!_context.HouseDesigns.Any())
              {*/
        // builder.Seed();
        /* builder.Entity<Category>().HasData(new Category() { CategoryId = 1, CategoryName = "Domy parterowe" });
         builder.Entity<HouseDesign>().HasData(new HouseDesign()
         {
             HouseDesignId = 1,
             ProjectName = "Dom w przebiśniegach",
             UseableArea = 196.02,
             MinPlotDimensionWidth = 24.3,
             MinPlotDimensionLength = 28.7,
             RoofAngle = 30,
             Price = 2499,
             NumberOfRooms = 5,
             NumberOfBathrooms = 2,
             NumberOfGaragePositions = 2
         });

         builder.Entity<HouseDesignCategory>().HasData(new HouseDesignCategory() { HouseDesignCategoryId = 1, HouseDesignId = 1, CategoryId = 1 });
         builder.Entity<HouseDesignCategory>().HasData(new ImageCategory() { ImageCategoryId = 1, ImageCategoryName = "Widok zewnątrz" });
         builder.Entity<HouseDesignCategory>().HasData(new Image()
         {
             ImagePath = "HouseDesignEcommerce/Images/1.jpg",
             ImageCategoryId = 1,
             HouseDesignId = 1
         });
         }
 }*/
    }
}
