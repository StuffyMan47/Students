using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.DataBase;
using Students.Models;

namespace Students.Controllers;

public class Stud1Controller : Controller
{
    private readonly AppDBContext _context;

    public Stud1Controller(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? student, int? exams)
    {
        var studentsList = await _context.Students
            .Select(x=> new StudentsDto
            {
                Id = x.Id,
                Name = x.FullName,
            }).ToListAsync();

        return View(new Exams {SelectetStudent = student, StudentsList = studentsList, Exam = exams } );
    }

    [HttpPost]
    public async Task<IActionResult> GetExams(int studentId)
    {
        var exams = await _context.Students.Where(x => x.Id == studentId)
            .Select(x=> new
            {
                x.FullName,
                exams = x.Estimates.Count(y=>y.Value>2),
            })
        .FirstOrDefaultAsync();


        return RedirectToAction(nameof(Index), new { student = exams.FullName, exams = exams.exams });
    }
}
