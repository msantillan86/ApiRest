using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdenServicioController : ControllerBase
    {   
   

        private readonly ILogger<OrdenServicioController> _logger;

        public OrdenServicioController(ILogger<OrdenServicioController> logger)
        {
            _logger = logger;
        }

        //Para añadir base de datos agregar a appsetings.json
        //  "ConnectionStrings": {
        //"ConnectionStrings": "Data Source=.;Initial catalog=DEVELOPERU;Integrated Security= true",


        [HttpGet("{id}")]
        public IEnumerable<OrdenServicio> GetById(int? id)
        {
            SNMP_Mensaje mensaje = new SNMP_Mensaje()
            {
                Id = 123,
                ClienteId = 1,
                DispositivoTipo = "ONT",
                DispositivoIp = "10.52.0.6",
                DispositivoAfectado = "ONT:BA_OLTA_SM01_05:R1.S1.LT13.PON14.ONT3",
                DispositivoIdentificador = "21",
                ProblemaCausa = "Signal Power Problem",
                ProblemaDescripcion = "Received Optical Signal Level Too Low",
                ProblemaSolucion = "Check the received optical signal and increase the signal level.",
                ProblemaFecha = DateTime.Now,
                FabricanteId = 1
            };
            OrdenServicio orden = new OrdenServicio(mensaje)
            {

            };
            if (id == orden.Id) { 
         
            yield return orden;
                }
           
        }
       [HttpPost]
       public string PostOrden(SNMP_Mensaje mensaje)
        {

            var servicios = new List<OrdenServicio>();
            var servicio = new OrdenServicio(mensaje);
            servicios.Add(servicio);
            return "Enhorabuena";
        }
    }
}
