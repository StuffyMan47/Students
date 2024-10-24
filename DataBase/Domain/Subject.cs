namespace Students.DataBase.Domain;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Class Class { get; set; }
    public List<Student> Students { get; set; }
    public List<Estimate> Estimates { get; set; }
}
