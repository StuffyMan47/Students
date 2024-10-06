namespace Students.Models;

public class StudentsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }
    public List<Grade> Grades { get; set; }
}

public class Specialty
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Grade
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public int Value { get; set; }
}
