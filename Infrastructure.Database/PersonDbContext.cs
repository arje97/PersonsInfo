using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace Infrastructure.Database
{
    class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PersonRelation> PersonRelations { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasNoKey().ToView(null);
          //  modelBuilder.Entity<PhoneNumber>().HasNoKey().ToView(null);
            modelBuilder.Entity<PersonRelation>().HasOne(x => x.Person).WithMany(x => x.RelatedPeople).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PersonRelation>().HasOne(x => x.RelatedPerson).WithMany().HasForeignKey(x => x.RelatedPersonId).OnDelete(DeleteBehavior.NoAction);
           modelBuilder.Entity<Person>().HasMany(x => x.PhoneNumbers).WithOne(x=>x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);

      //     modelBuilder.Entity<PhoneNumber>().HasOne(x => x.People).WithMany(x=>x.).HasForeignKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Person>().Property(x => x.FirstName).IsRequired();
            //modelBuilder.Entity<Person>().Property(x => x.LastName).IsRequired();
            //modelBuilder.Entity<Person>().Property(x => x.BirthDate).IsRequired();
            //modelBuilder.Entity<Person>().Property(x => x.PrivateNumber).IsRequired();
            //modelBuilder.Entity<Person>().Property(x => x.Gender).IsRequired();
     
        }




    }
}
