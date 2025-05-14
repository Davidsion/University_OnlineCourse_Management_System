using Microsoft.EntityFrameworkCore;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        // Add this line for the Submissions table
        public DbSet<Submission> Submissions { get; set; }
        // Add this line for the Announcements table
        public DbSet<Announcement> Announcements { get; set; }

        // Add this line for the Exams table
        public DbSet<Exam> Exams { get; set; }

        // Add this line for the Grades table
        public DbSet<Grade> Grades { get; set; }

        // Add this line for the Timetable table
        public DbSet<Timetable> Timetables { get; set; }
        // Add this line for the LibraryResources table
        public DbSet<LibraryResource> LibraryResources { get; set; }
        // Add this line for the Attendance table
        public DbSet<Attendance> Attendances { get; set; }
        // Add this line for the Payments table
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configuration for the Submission entity to handle the Score property
            modelBuilder.Entity<Submission>()
                .Property(s => s.Score)
                .HasColumnType("decimal(5, 2)"); // Or use .HasPrecision(5, 2);

            // Add configurations for other entities (Assignments, Enrollments, etc.) here
            // if you haven't already. For example, foreign key relationships.

            base.OnModelCreating(modelBuilder);
        }
    }
}