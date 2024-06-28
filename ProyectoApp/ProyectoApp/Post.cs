using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApp
{
    public class Post
    {
        private static int contadorIds = 0;
        public int Id { get; }
        public string CorreoCreador { get; set; }
        public string NombreCreador { get; set; } 
        public DateTime FechaHora { get; }
        public string Texto { get; }
        public int CantLikes { get; set; }
        public string AreaInteres { get; set; }

        public Post(string correoCreador, string nombreCreador, DateTime fechaHora, string texto, string areaInteres)
        {
            this.CorreoCreador = correoCreador;
            this.NombreCreador = nombreCreador;
            this.Id = ++contadorIds;
            this.FechaHora = fechaHora;
            this.Texto = texto;
            this.CantLikes = 0;
            this.AreaInteres = areaInteres;
        }

        public void IncrementarLikes()
        {
            CantLikes++;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Fecha/Hora: {FechaHora}, Texto: {Texto}, Likes: {CantLikes}, Intereses: {AreaInteres}";
        }
    }
}
