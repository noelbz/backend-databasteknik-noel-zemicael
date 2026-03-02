using Xunit;
using Application.Services;
using Infrastructure;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class CourseServiceTests
    {
        // Create a new in-memory DbContext
        private EduAppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<EduAppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            return new EduAppDbContext(options);
        }
        // Test for creating a course
        [Fact]
        public async Task CreateCourse_AddsCourse()
        {
            // Arrange
            var context = GetDbContext();
            var service = new CourseService(context);
            var course = new Course { Name = "Test Course" };

            // Act
            await service.CreateCourseAsync(course);

            // Assert
            var savedCourses = await service.GetAllCoursesAsync();
            Assert.Single(savedCourses);
            Assert.Equal("Test Course", savedCourses.First().Name);
        }

    }
}