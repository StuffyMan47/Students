namespace Students.Models;

public class PageDto
{
    public List<StudentsDto> Students { get; set; } = [];
    public List<EdProgramDto> EdProgram { get; set; } = [];
}
