using System;

namespace ProyectoApp
{
public class Evento
{
    public string MailCreador { get; set; }
    public string NombreCreador { get; set; }
    public DateTime FechaHoraCreacion { get; set; }
    public string Descripcion { get; set; }
    public string AreaInteres { get; set; }
        public int CantLikes { get; private set; }

    public Evento(string mailCreador, string nombreCreador, DateTime fechaHoraCreacion, string descripcion, string areaInteres)
    {
        MailCreador = mailCreador;
        NombreCreador = nombreCreador;
        FechaHoraCreacion = fechaHoraCreacion;
        Descripcion = descripcion;
        AreaInteres = areaInteres;
        CantLikes = 0;
    }

    public void DarLike()
    {
        CantLikes++;
    }

    public override string ToString()
    {
            return $"Mail: {MailCreador}, Nombre del Creador: {NombreCreador}, Area de Interes: {AreaInteres}, Descripción: {Descripcion}, Likes: {CantLikes}";
        }
    }
}
