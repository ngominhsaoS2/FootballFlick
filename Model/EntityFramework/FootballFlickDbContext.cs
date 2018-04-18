namespace Model.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ViewModel;

    public partial class FootballFlickDbContext : DbContext
    {
        public FootballFlickDbContext()
            : base("name=FootballFlickDbContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<ClubArea> ClubAreas { get; set; }
        public virtual DbSet<ClubAvailableTime> ClubAvailableTimes { get; set; }
        public virtual DbSet<ClubPlayer> ClubPlayers { get; set; }
        public virtual DbSet<ClubPoint> ClubPoints { get; set; }
        public virtual DbSet<ClubStadium> ClubStadiums { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentCategory> ContentCategories { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchDetail> MatchDetails { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerPoint> PlayerPoints { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<StatusCategory> StatusCategories { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<ClubLevel> ClubLevels { get; set; }

        //ViewModel
        public virtual DbSet<ClubAreaViewModel> vClubAreas { get; set; }
        public virtual DbSet<ClubAvailableTimeViewModel> vClubAvailableTimes { get; set; }
        public virtual DbSet<ClubPlayerViewModel> vClubPlayers { get; set; }
        public virtual DbSet<ClubStadiumViewModel> vClubStadiums { get; set; }
        public virtual DbSet<ClubViewModel> vClubs { get; set; }
        public virtual DbSet<ContentViewModel> vContenst  { get; set; }
        public virtual DbSet<MatchDetailViewModel> vMatchDetails { get; set; }
        public virtual DbSet<MatchViewModel> vMatches { get; set; }
        public virtual DbSet<OrderDetailViewModel> vOrderDetails { get; set; }
        public virtual DbSet<PlayerPointViewModel> vPlayerPoints { get; set; }
        public virtual DbSet<ClubPointViewModel> vClubPoints { get; set; }
        public virtual DbSet<ProductViewModel> vProducts { get; set; }
        public virtual DbSet<PlayerViewModel> vPlayers { get; set; }
        public virtual DbSet<ClubLevelViewModel> vClubLevels { get; set; }
        public virtual DbSet<RankViewModel> vRanks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<ContentCategory>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Match>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Match>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Permission>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContentViewModel>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<MatchViewModel>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MatchViewModel>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetailViewModel>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductViewModel>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductViewModel>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);
        }


    }
}
