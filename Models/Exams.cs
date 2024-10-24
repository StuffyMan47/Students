namespace Students.Models;

public class Exams
{
    public string? SelectetStudent { get; init; }
    public List<StudentsDto> StudentsList { get; init; } = [];
    public int? Exam { get; init; }
}
