using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Barren Lake", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShTPT61tw5A24B5N3rRdXQ0Ff-1Qo9437u9_U3khT-P2gElVviRLzQaB6yVRK4IgXP32s&usqp=CAU"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Devils Backbone", ImageUrl="https://i.ytimg.com/vi/mYlGrDoQcU0/maxresdefault.jpg"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Freed Owl", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRETxTWjN0pPEpVHJo35djs-961fT5Brtdy_A&s"},
        new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Alpine Garden", ImageUrl="https://www.onlyinyourstate.com/wp-content/uploads/2022/03/Alpine-Garden.jpg?w=720"},
        new Campsite {Id = 6, CampsiteTypeId = 3, Nickname = "Dale Hollow", ImageUrl="https://cdn.recreation.gov/public/2018/09/23/00/30/89910_396395a1-bbc4-41d4-8cfc-36c79dfeeef4_700.jpg"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
        new UserProfile {Id = 1, FirstName = "Lola", LastName = "Mings", Email="Lola.Mings@gmail.com"},
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
        new Reservation {Id = 1, CampsiteId = 3, UserProfileId = 1, CheckinDate=new DateTime(2024, 9, 12), CheckoutDate=new DateTime(2024, 9, 18)},
        });
    }
}

