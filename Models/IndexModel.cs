﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Students.DataBase.Domain;
using Students.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Students.Models
{
    public class IndexModel(AppDBContext dBContext) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int SelectedSpecialty { get; set; }

        public IEnumerable<SelectListItem> Specialties { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Subject> EdPrograms { get; set; }

        public async void OnGet()
        {
            Specialties = await dBContext.Classes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToListAsync();
        }

        public void OnPost()
        {
            Specialties = dBContext.Classes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            Students = dBContext.Students.Where(x=>x.Class.Id == SelectedSpecialty);
            EdPrograms = dBContext.EdPrograms.Where(x=>x.Class.Id == SelectedSpecialty);
        }
    }
}
