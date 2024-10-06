namespace Students.Models;

public class PageDto
{
    public List<StudentsDto> Students { get; set; } = [];
    public List<ClassDto> Class { get; set; } = [];
}
