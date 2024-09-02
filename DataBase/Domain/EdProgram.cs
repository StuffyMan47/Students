namespace Students.DataBase.Domain;

public class EdProgram
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }

    public Class Class { get; set; }
}
