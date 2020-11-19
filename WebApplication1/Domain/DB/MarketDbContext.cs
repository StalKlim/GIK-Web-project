using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Domain.Model;
using WebApplication1.Domain.Model.Common;

namespace WebApplication1.Domain.DB
{
    public class MarketDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options)
               : base(options)
        {

            Database.Migrate();
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public override DbSet<User> Users { get; set; }

        /// <summary>
        /// Клиенты
        /// </summary>
        public DbSet<Client> Clients { get; private set; }

        /// <summary>
        /// Новости
        /// </summary>
        public DbSet<Post> Posts { get; private set; }

        /// <summary>
        /// Товары
        /// </summary>
        public DbSet<Product> Products { get; private set; }

        /// <summary>
        /// Корзины клиентов
        /// </summary>
        public DbSet<Cart> Carts { get; private set; }

        /// <summary>
        /// Категории товаров
        /// </summary>
        public DbSet<Category> Categories { get; private set; }

        public DbSet<PurchaseHistory> PurchaseHistories { get; private set; }

        public DbSet<SalesHistory> SalesHistories { get; private set; }


        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User
            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Client)
                .WithOne(x => x.User)
                .HasForeignKey<User>("ClientId")
                .IsRequired(true);
                x.HasIndex("ClientId").IsUnique(true);
            });
            #endregion

            #region Client
            modelBuilder.Entity<Client>(b =>
            {
                b.ToTable("Clients");
                b.HasOne(x => x.Cart)
                .WithOne(y => y.Client)
                .HasForeignKey<Client>("CartId");
                EntityId(b);
                b.Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                b.Property(x => x.Surname)
                    .HasColumnName("Surname")
                    .IsRequired();
                b.Ignore(x => x.FullName);
            });
            #endregion

            #region Post
            modelBuilder.Entity<Post>(b =>
            {
                b.ToTable("Posts");
                b.HasOne(x => x.Client)
                .WithMany()
                .IsRequired();
                EntityId(b);
                b.Property(x => x.Created)
                    .HasColumnName("Created")
                    .IsRequired();
                b.Property(x => x.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                b.Property(x => x.Description)
                    .HasColumnName("Description")
                    .IsRequired();
                b.Property(x => x.Data)
                    .HasColumnName("Data")
                    .IsRequired();
                b.Property(x => x.FileId)
                    .HasColumnName("FileId");
            });
            #endregion

            #region Cart
            modelBuilder.Entity<Cart>(b =>
            {
                b.ToTable("Carts");
                EntityId(b);
            });
            #endregion

            #region Category
            modelBuilder.Entity<Category>(b =>
            {
                b.ToTable("Categories");
                EntityId(b);
                b.Property(x => x.CategoryName)
                    .HasColumnName("CategoryName")
                    .IsRequired();
            });
            #endregion

            #region Product
            modelBuilder.Entity<Product>(b =>
            {
                b.ToTable("Products");
                EntityId(b);
                b.Property(x => x.Name)
                    .HasColumnName("Name")
                    .IsRequired();
                b.Property(x => x.Description)
                    .HasColumnName("Description")
                    .IsRequired();
                b.Property(x => x.Price)
                    .HasColumnName("Price")
                    .IsRequired();
                b.Property(x => x.IsAproved)
                    .HasColumnName("isAproved")
                    .IsRequired();
                b.Property(x => x.FileId)
                    .HasColumnName("FileId")
                    .IsRequired();
                b.Property(x => x.Created)
                    .HasColumnName("Created")
                    .IsRequired();
                b.HasOne(x => x.Client)
                .WithMany()
                .IsRequired();
                b.HasOne(x => x.Category)
                .WithOne(y => y.Product)
                .HasForeignKey<Product>("CategoryId");
                b.HasOne(x => x.Cart)
                .WithMany()
                .IsRequired();
            });
            #endregion

            #region PurchaseHistory
            modelBuilder.Entity<PurchaseHistory>(b =>
            {
                b.ToTable("PurchaseHistory");
                EntityId(b);
                b.Property(x => x.PurchaseDate);
                b.HasOne(x => x.Client)
                .WithOne(y => y.PurchaseHistory)
                .HasForeignKey<Client>("PurchaseHistoryId");
            });
            #endregion

            #region SalesHistory
            modelBuilder.Entity<SalesHistory>(b =>
            {
                b.ToTable("SalesHistory");
                EntityId(b);
                b.Property(x => x.IsSold);
                b.Property(x => x.SaleDate);
                b.HasOne(x => x.Client)
                .WithOne(y => y.SalesHistory)
                .HasForeignKey<Client>("SalesHistoryId");
            });
            #endregion
        }

        /// <summary>
        /// Описание идентификатора сущности модели
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="builder">Построитель модели данных</param>
        private static void EntityId<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(x => x.Id)
                .HasAnnotation("Npgsql:Serial", true);
        }
    }
}
