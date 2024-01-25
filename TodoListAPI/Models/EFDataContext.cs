using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Models
{
    public class EFDataContext : DbContext
    {
         public EFDataContext(DbContextOptions<EFDataContext> options)
              : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config primary key(product,category)
            modelBuilder.Entity<TodoList>(b =>
            {
                b.HasKey(s => s.id);
                b.Property(p => p.id).ValueGeneratedOnAdd();
            });


        }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
