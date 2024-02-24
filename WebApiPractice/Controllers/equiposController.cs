using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContexto;

        public equiposController(equiposContext equiposContexto)
        {
            _equiposContexto = equiposContexto;

            

            

        }

        //EndPoint que retorna el listado de todos los equipos existentes

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<equipos> ListadoEquipo = (from e in _equiposContexto.equipos 
                                           select e).ToList();

            if (ListadoEquipo.Count == 0)
            {
                return NotFound();
            } 

            return Ok(ListadoEquipo);

        }

    }


}
