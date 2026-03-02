using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CourseService
    {
        private readonly EduAppDbContext _context;

        public CourseService(EduAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.Include(c => c.Sessions).ToListAsync();
            return courses;
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.Include(c => c.Sessions)
                .FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}