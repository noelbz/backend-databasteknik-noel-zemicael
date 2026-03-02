namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<CourseSession> Sessions { get; set; } = new();
}

public class CourseSession
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class CourseRegistration
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CourseSessionId { get; set; }
    public CourseSession? Session { get; set; }
}