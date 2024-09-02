using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Students.DataBase.Domain;
using Students.DataBase;

namespace Students.Models
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;

        [BindProperty(SupportsGet = true)]
        public int SelectedSpecialty { get; set; }

        public IEnumerable<SelectListItem> Specialties { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<EdProgram> EdPrograms { get; set; }

        public void OnGet()
        {
            Specialties = _context.Classes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });
        }

        public void OnPost()
        {
            Specialties = _context.Classes.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            Students = _context.Students.Where(x=>x.Class.Id == SelectedSpecialty);
            EdPrograms = _context.EdPrograms.Where(x=>x.Class.Id == SelectedSpecialty);
        }
    }
}
