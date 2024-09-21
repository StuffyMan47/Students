namespace Students.DataBase.Domain;

public class Estimate
{
    public int Id { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public int EdProgrammId { get; set; }

    public Student Student { get; set; }
    public EdProgram EdProgramm { get; set; }
}
