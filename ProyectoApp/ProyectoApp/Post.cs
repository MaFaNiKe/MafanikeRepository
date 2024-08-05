using System;

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
        public int CantLikes { get; private set; }
        public string AreaInteres { get; set; }

        public Post(string correoCreador, string nombreCreador, DateTime fechaHora, string texto, string areaInteres)
        {
            CorreoCreador = correoCreador;
            NombreCreador = nombreCreador;
            Id = ++contadorIds;
            FechaHora = fechaHora;
            Texto = texto;
            CantLikes = 0;
            AreaInteres = areaInteres;
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
