namespace Students.DataBase.Domain;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }
    public DateTime Birthday { get; set; }
    public string Parents { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Passport { get; set; }
    public int ReportCard { get; set; }
    public DateTime ReceiptDate { get; set; }
    public int StudyYear { get; set; }
    public bool FullTime { get; set; }

    public Class Class { get; set; }
    public EdProgram EdProgram { get; set; }
    public List<Estimate> Estimates { get; set; }
}
