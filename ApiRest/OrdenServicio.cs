using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest
{
    public partial class OrdenServicio
    {   
        public OrdenServicio(SNMP_Mensaje mensaje)
        {
            this.Id = 0;
            this.Agrupamiento = new IdNombre() { Id = 11, Nombre = "Eventos" };

            this.Workflow = new IdNombre() { Id = 31, Nombre = "En produccion" }; //este es el que va , el 31
                                                                                  //this.Workflow = new IdNombre() { Id = 33, Nombre = "Baja" };

            this.Interesados = new IdNombre[] { new IdNombre() { Id = 2, Nombre = "ATC" } };
            this.FallaTipo = new IdNombre() { Id = 25, Nombre = "Externa" };
            this.Estado = new IdNombre() { Id = 10, Nombre = "Abierto" };
            this.Prioridad = new IdNombre() { Id = 12, Nombre = "Minor" };
            this.FechaInicio = mensaje.ProblemaFecha;
            this.Resolucion = new IdNombre() { Id = 33, Nombre = "Corte de fibra" };

            //cargar los campos relativos a cada mensaje
            this.Sitio = new IdNombre() { Id = int.Parse(mensaje.DispositivoIdentificador) };
            this.Resumen = "Dispositivo Afectado: " + mensaje.DispositivoAfectado + " Causa Reportada: " + mensaje.ProblemaCausa;
            this.Alcance = JsonConvert.SerializeObject(new { ops = new object[] { new { insert = $"Ip del dispositivo: {mensaje.DispositivoIp}\nDescripcion: {mensaje.ProblemaDescripcion}\nSolucion: {mensaje.ProblemaSolucion}\n" } } });
            this.MensajeId = mensaje.Id;
        }

        //Campos Constantes
        public long Id { get; private set; } //siempre 0 (cero)
        public IdNombre Agrupamiento { get; private set; } //siempre 11 y nombre "Eventos"
        public IdNombre Workflow { get; private set; } //siempre 31 y nombre "En produccion"
        public IdNombre[] Interesados { get; set; } //siempre un unico elemento en la lista y que diga id 2 y nombre ATC
        public IdNombre FallaTipo { get; set; } //siempre Id 25 y Nombre Externa
        public IdNombre Estado { get; set; } //siempre Id 10 y nombre Abierto
        public IdNombre Prioridad { get; set; } //siempre 12 y nombre Minor
        public IdNombre Resolucion { get; set; } //siempre 33 y nombre Corte de Fibra
        //Campos Variables
        public IdNombre Sitio { get; set; } //va el dispositivoId
        public string Resumen { get; set; } //Dispositivo Afectado: Dispositivo  + Problema: lo que nos viene en el mansaje(ProblemaCausa)
        public string Alcance { get; set; } //Alcance === Observaciones "{\"ops\":[{\"insert\":\"Ip del dispositivo: 127.0.0.1\\nDescripcion: Se rompio\\nSolucion: Reiniciar\\n\"}]}"
        public DateTimeOffset FechaInicio { get; set; } //hora del mensaje
        public int MensajeId { get; set; }
    }

    public class IdNombre
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}
