using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
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


        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Client)
                .WithOne(x => x.User)
                .HasForeignKey<User>("ClientId")
                .IsRequired(true);
                x.HasIndex("ClientId").IsUnique(true);
            });

            #region Client

            modelBuilder.Entity<Client>(b =>
            {
                b.HasOne(y => y.Cart)
                .WithOne(x => x.Client)
                .HasForeignKey<Client>("CartId")
                .IsRequired(true);
                b.ToTable("Clients");
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
                b.HasOne(y => y.Owner)
                .WithMany(x => x.Post)
                .IsRequired(true);
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
                b.HasOne(y => y.Client)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>("ClientId")
                .IsRequired(true);
                EntityId(b);
                b.HasOne(y => y.Product)
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .IsRequired(false);
                b.HasIndex("ProductId").IsUnique(false);
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
                b.HasOne(y => y.Category)
                    .WithOne()
                    .HasForeignKey<Product>("CategoryId")
                    .IsRequired(true);
                b.HasIndex("CategoryId").IsUnique(true);
                b.HasOne(y => y.Owner)
                    .WithOne()
                    .HasForeignKey<Product>("OwnerId")
                    .IsRequired(true);
                b.HasIndex("OwnerId").IsUnique(true);

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
