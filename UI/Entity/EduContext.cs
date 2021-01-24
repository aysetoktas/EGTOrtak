using System.Data.Entity;

namespace Entity
{
    public class EduContext:DbContext
    {
        public EduContext():base("dbEGT")  
        {
            //Database.Connection.ConnectionString = @"server=.; database=Two;Integrated Security=true";
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Student> Students { get; set; }
       
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
