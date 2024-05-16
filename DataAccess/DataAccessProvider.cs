using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly SqlContext _context;

        public DataAccessProvider(SqlContext context)
        {
            _context = context;
        }

        public List<catalumno> GetAlumnos()
        {
            return _context.catalumno.ToList();
        }

        public List<catalumno> GetAlumnosBySearchTerm(string searchTerm)
        {
            // Filtrar los alumnos por el término de búsqueda
            return _context.catalumno.Where(a => a.Name.Contains(searchTerm)).ToList();
        }

        public void AddAlumno(catalumno alumno)
        {
            _context.catalumno.Add(alumno);
            _context.SaveChanges();
        }
    }
}
