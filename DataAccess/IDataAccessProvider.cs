using System.Collections.Generic;
using WebService.Models;

namespace WebService.DataAccess
{
    public interface IDataAccessProvider
    {
        List<catalumno> GetAlumnos();
        List<catalumno> GetAlumnosBySearchTerm(string searchTerm);
        void AddAlumno(catalumno alumno);
    }
}
