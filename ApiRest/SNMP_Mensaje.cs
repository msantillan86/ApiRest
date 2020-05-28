using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest
{
    public class SNMP_Mensaje
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string DispositivoTipo { get; set; }
        public string DispositivoIp { get; set; }
        public string DispositivoAfectado { get; set; }
        public string DispositivoIdentificador { get; set; }
        public string ProblemaCausa { get; set; }
        public string ProblemaDescripcion { get; set; }
        public string ProblemaSolucion { get; set; }
        public DateTimeOffset ProblemaFecha { get; set; }
        public int FabricanteId { get; set; }
        public bool Reservado { get; set; }
        public bool Procesado { get; set; }
    }
}
