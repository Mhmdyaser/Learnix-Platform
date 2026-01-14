using Learnix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Learnix.Data
{
    public class LearnixContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLanguage> CourseLanguages { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonMaterial> LessonMaterials { get; set; }
        public DbSet<LessonStatus> LessonStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<StudentLessonProgress> StudentLessonProgresses { get; set; }
        public DbSet<InstructorStatus> InstructorStatus { get; set; }

        public LearnixContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.Balance)
                .HasDefaultValue(500);

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Student>().ToTable(tb =>
               tb.HasCheckConstraint("CK_Student_Balance", "[Balance] >= 0"));





            modelBuilder.Entity<Instructor>()
                .Property(i => i.Balance)
                .HasDefaultValue(0);

            modelBuilder.Entity<Instructor>()
                .Property(I => I.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Instructor>().ToTable(tb =>
                tb.HasCheckConstraint("CK_Instructor_Balance", "[Balance] >= 0"));





            modelBuilder.Entity<Admin>()
               .Property(a => a.Balance)
               .HasDefaultValue(0);

            modelBuilder.Entity<Admin>()
                .Property(a => a.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Admin>().ToTable(tb =>
               tb.HasCheckConstraint("CK_Admin_Balance", "[Balance] >= 0"));




            
            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.NormalizedEmail)
                .IsUnique();



            modelBuilder.Entity<CourseStatus>().HasData(
                new CourseStatus { Id = 1, Name = "Draft" },
                new CourseStatus { Id = 2, Name = "Published" },
                new CourseStatus { Id = 1002, Name = "Rejected" }
            );

            modelBuilder.Entity<InstructorStatus>().HasData(
                new InstructorStatus { Id = 1, Name = "Pending" },
                new InstructorStatus { Id = 2, Name = "Approved" },
                new InstructorStatus { Id = 3, Name = "Rejected" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 2, Name = "Web Development", Description = "Learn how to build websites and web applications using front-end and back-end technologies." },
                new Category { Id = 3, Name = "Programming", Description = "Master various programming languages and coding concepts for software development." },
                new Category { Id = 4, Name = "Data Science", Description = "Explore data analysis, visualization, and machine learning to extract insights from data." },
                new Category { Id = 5, Name = "Artificial Intelligence", Description = "Understand AI fundamentals including machine learning, deep learning, and neural networks." },
                new Category { Id = 6, Name = "Marketing", Description = "Develop skills in digital marketing, SEO, social media strategy, and content creation." },
                new Category { Id = 7, Name = "Business", Description = "Gain knowledge in management, entrepreneurship, finance, and business strategy." },
                new Category { Id = 8, Name = "Design", Description = "Learn graphic design, UI/UX, and creative skills for digital and print media." },
                new Category { Id = 9, Name = "Cyber Security", Description = "Discover how to protect systems, networks, and data from cyber threats and attacks." }
            );

            modelBuilder.Entity<CourseLanguage>().HasData(
                new CourseLanguage { Id = 1, Name = "English" },
                new CourseLanguage { Id = 2, Name = "Arabic" }
            );

            modelBuilder.Entity<CourseLevel>().HasData(
                new CourseLevel { Id = 1, Name = "Beginner" },
                new CourseLevel { Id = 2, Name = "Intermediate" },
                new CourseLevel { Id = 3, Name = "Advanced" },
                new CourseLevel { Id = 4, Name = "All Levels" }
            );

            modelBuilder.Entity<LessonStatus>().HasData(
                new LessonStatus { Id = 1, Name = "Draft" },
                new LessonStatus { Id = 2, Name = "Published" }
            );


        }


    }
}


