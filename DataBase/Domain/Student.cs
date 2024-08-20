namespace Students.DataBase.Domain;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }

    public Class Class { get; set; }
    public List<Estimate> Estimates { get; set; }
}
