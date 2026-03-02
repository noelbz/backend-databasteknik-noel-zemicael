using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite database
builder.Services.AddDbContext<EduAppDbContext>(options =>
{
    options.UseSqlite("Data Source=eduapp.db");
});

var app = builder.Build();

// Course Endpoints

// Get all courses
app.MapGet("/courses", async (EduAppDbContext db) =>
{
    return await db.Courses.ToListAsync();
});

// Get course by id
app.MapGet("/courses/{id}", async (int id, EduAppDbContext db) =>
{
    var course = await db.Courses.FindAsync(id);

    if (course == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(course);
});

// Create new course
app.MapPost("/courses", async (Course course, EduAppDbContext db) =>
{
    db.Courses.Add(course);
    await db.SaveChangesAsync();

    return Results.Created("/courses/" + course.Id, course);
});

// Update existing course
app.MapPut("/courses/{id}", async (int id, Course updatedCourse, EduAppDbContext db) =>
{
    var course = await db.Courses.FindAsync(id);

    if (course == null)
    {
        return Results.NotFound();
    }

    course.Name = updatedCourse.Name;

    await db.SaveChangesAsync();

    return Results.Ok(course);
});

// Delete course
app.MapDelete("/courses/{id}", async (int id, EduAppDbContext db) =>
{
    var course = await db.Courses.FindAsync(id);

    if (course == null)
    {
        return Results.NotFound();
    }

    db.Courses.Remove(course);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();