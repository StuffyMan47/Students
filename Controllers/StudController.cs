using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.DataBase;
using Students.Models;

public class StudController : Controller
{
    private readonly AppDBContext _context;

    public StudController(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var edProgram = await _context.Classes
           .Select(x => new ClassDto
           {
               Id = x.Id,
               Name = x.Name,
           }).ToListAsync();

        return View(new PageDto { Class = edProgram });
    }

    [HttpPost]
    public async Task<IActionResult> Index(int specialtyId)
    {
        var students = await _context.Students
            .Include(x => x.Estimates)
            .Where(s => s.Class.Id == specialtyId)
            .Select(x => new StudentsDto
            {
                Id = x.Id,
                Name = x.FullName,
                Grades = new List<Grade>(x.Estimates.Select(y => new Grade 
                { 
                    Id = y.Id,
                    SubjectId = y.SubjectId,
                    SubjectName = y.Subject.Name,
                    Value = y.Value
                }).ToList()),
                Specialty = new Specialty
                {
                    Id = x.EdProgram.Id,
                    Name = x.EdProgram.Name,
                },
                SpecialtyId = x.EdProgram.Id,
            })
            .ToListAsync();

        var edProgram = await _context.Classes
            .Select(x => new ClassDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();

        return View(new PageDto { Class = edProgram, Students = students });
    }

    public async Task<IActionResult> UpdateGrade(int gradeId, string newValue)
    {
        var grade = await _context.Estimates
            .Include(x=>x.Student)
            .ThenInclude(x=>x.Class)
            .FirstOrDefaultAsync(x=>x.Id == gradeId);

        if (grade == null)
            return NotFound();
        
        grade.Value = Int32.Parse(newValue);
        grade.Date = DateTime.Now;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}