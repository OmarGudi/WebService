using Microsoft.AspNetCore.Mvc;
using WebService.DataAccess;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class catalumnoController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public catalumnoController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IActionResult Get(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Ok(_dataAccessProvider.GetAlumnos());
            }
            else
            {
                return Ok(_dataAccessProvider.GetAlumnosBySearchTerm(searchTerm));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] catalumno alumno)
        {
            if (alumno == null)
            {
                return BadRequest("El alumno proporcionado es nulo");
            }

            try
            {
                _dataAccessProvider.AddAlumno(alumno);
                return CreatedAtRoute("GetAlumno", new { id = alumno.ID }, alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
