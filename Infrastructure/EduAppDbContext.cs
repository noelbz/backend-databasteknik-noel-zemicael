using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class EduAppDbContext : DbContext
{
    public EduAppDbContext(DbContextOptions<EduAppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseSession> Sessions => Set<CourseSession>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<CourseRegistration> Registrations => Set<CourseRegistration>();
}