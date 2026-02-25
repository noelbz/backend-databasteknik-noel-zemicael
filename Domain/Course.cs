namespace Domain;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<CourseSession> Sessions { get; set; } = new();
}
