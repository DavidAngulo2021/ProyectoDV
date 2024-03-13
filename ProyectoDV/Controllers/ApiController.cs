using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using ProyectoDV.Models;

namespace ProyectoDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        public readonly DB_pruebaDVContext _dbcontext;

        public ApiController(DB_pruebaDVContext _context)
        {
            _dbcontext = _context;
        }


        [HttpGet]
        [Route("lista")]

        public IActionResult Lista()
        {
            List<Trace> lista = new List<Trace>();


            try
            {
                lista = _dbcontext.Traces.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{Identificador}")]
        public IActionResult Obtener(string Identificador)
        {
            try
            {
                // Buscar el Trace por su identificador en la base de datos
                Trace trace = _dbcontext.Traces.FirstOrDefault(t => t.Identificador == Identificador);

                // Verificar si el Trace fue encontrado
                if (trace == null)
                {
                    return NotFound(new { mensaje = "El Trace con el identificador especificado no fue encontrado." });
                }

                // Si se encuentra, devolverlo como respuesta
                return Ok(new { mensaje = "Ok", response = trace });
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolver un código de estado 500 junto con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error al intentar obtener el Trace.", error = ex.Message });
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Trace objeto)
        {
            try
            {
                _dbcontext.Traces.Add(objeto);
                _dbcontext.SaveChanges();


                // Si se encuentra, devolverlo como respuesta
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolver un código de estado 500 junto con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error al intentar obtener el Trace.", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Trace objeto)
        {
            Trace user = _dbcontext.Traces.Find(objeto.Id);

            if (user == null)
            {
                return BadRequest("no encontrado");
            }


            try

            {
                user.Identificador = objeto.Identificador is null ? user.Identificador : objeto.Identificador;
                user.FechaYhora = objeto.FechaYhora is null ? user.FechaYhora : objeto.FechaYhora;
                user.Longitud = objeto.Longitud is null ? user.Longitud : objeto.Longitud;
                user.Latitud = objeto.Latitud is null ? user.Latitud : objeto.Latitud;
                user.Dispositivo = objeto.Dispositivo is null ? user.Dispositivo : objeto.Dispositivo;



                _dbcontext.Traces.Update(user);
                _dbcontext.SaveChanges();


                // Si se encuentra, devolverlo como respuesta
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }


            catch (Exception ex)
            {
                // Si ocurre un error, devolver un código de estado 500 junto con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error al intentar obtener el Trace.", error = ex.Message });
            }
        }
    }
}


    

