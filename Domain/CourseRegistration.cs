namespace Domain;

public class CourseRegistration
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int CourseSessionId { get; set; }
    public CourseSession? Session { get; set; }
}