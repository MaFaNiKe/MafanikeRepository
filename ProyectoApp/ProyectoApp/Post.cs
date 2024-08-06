using System;

namespace ProyectoApp
{
    public class Post
    {
        private static int contadorIds = 0;
        public int Id { get; }
        public string MailUsuario { get; set; } // Agregado
        public string NombreUsuario { get; set; } // Agregado
        public DateTime Fecha { get; } // Renombrado de FechaHora a Fecha
        public string Texto { get; }
        public int CantLikes { get; private set; }
        public string Categoria { get; set; } // Renombrado de AreaInteres a Categoria

        public Post(string mailUsuario, string nombreUsuario, DateTime fecha, string texto, string categoria)
        {
            MailUsuario = mailUsuario; // Agregado
            NombreUsuario = nombreUsuario; // Agregado
            Id = ++contadorIds;
            Fecha = fecha; // Renombrado de FechaHora a Fecha
            Texto = texto;
            CantLikes = 0;
            Categoria = categoria; // Renombrado de AreaInteres a Categoria
        }

        public void IncrementarLikes()
        {
            CantLikes++;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Fecha: {Fecha}, Texto: {Texto}, Likes: {CantLikes}, Categoría: {Categoria}";
        }
    }
}
