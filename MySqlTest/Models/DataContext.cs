using Microsoft.EntityFrameworkCore;

namespace MySqlTest {
	public class DataContext : DbContext {
		public DataContext(DbContextOptions<DataContext> options)
			: base(options) {
		}

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<User>()
						.ToTable("user");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseMySql(@"Server=localhost;database=test_db;uid=root;pwd=123456;");
	}
}