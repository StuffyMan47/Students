﻿using Microsoft.AspNetCore.Mvc;
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
                Grades = new List<Grade>(x.Estimates.Select(y => new Grade { Id = y.Id, SubjectId = y.EdProgrammId, SubjectName = y.EdProgramm.Name, Value = y.Value }).ToList()),
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
    ////public async Task<IActionResult> Index()
    ////{
    ////    var students = await _context.Students
    ////        .Include(x=>x.Estimates)
    ////        //.Where(s => s.EdProgram.Id == specialtyId)
    ////        .Select(x=> new StudentsDto
    ////        {
    ////            Id = x.Id,
    ////            Name = x.FullName,
    ////            Grades = new List<Grade> (x.Estimates.Select(y => new Grade { Id = y.Id, SubjectId = y.EdProgrammId, SubjectName = y.EdProgramm.Name, Value = y.Value }).ToList()),
    ////            Specialty = new Specialty
    ////            {
    ////                Id = x.EdProgram.Id,
    ////                Name = x.EdProgram.Name,
    ////            },
    ////            SpecialtyId = x.EdProgram.Id,
    ////        })
    ////        .ToListAsync();
    ////    var edProgram = await _context.Classes
    ////        .Select(x => new ClassDto
    ////        {
    ////            Id = x.Id,
    ////            Name = x.Name,
    ////        }).ToListAsync();

    ////    return View(new PageDto { Class = edProgram, Students = students});
    ////}

    public IActionResult UpdateGrade(int gradeId, int newValue)
    {
        var grade = _context.Estimates.Find(gradeId);
        if (grade == null)
        {
            return NotFound();
        }

        grade.Value = newValue;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index), new { specialtyId = grade.Student.Class.Id });
    }
}