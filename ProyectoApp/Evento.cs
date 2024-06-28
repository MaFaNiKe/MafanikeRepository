﻿using System;
using System.Collections.Generic;

public class Evento
{
    public string MailCreador { get; set; }
    public string NombreCreador { get; set; }
    public DateTime FechaHoraCreacion { get; set; }
    public string Direccion { get; set; }
    public string FechaEvento { get; set; } // Fecha del evento como cadena
    public string HoraEvento { get; set; } // Hora del evento como cadena
    public string Descripcion { get; set; }
    public string AreaInteres { get; set; }
    public int CantLikes { get; set; }

    // Constructor
    public Evento(string mailCreador, string nombreCreador, DateTime fechaHoraCreacion, string direccion, string fechaEvento, string horaEvento, string descripcion, string areaInteres)
    {
        MailCreador = mailCreador;
        NombreCreador = nombreCreador;
        FechaHoraCreacion = fechaHoraCreacion;
        Direccion = direccion;
        FechaEvento = fechaEvento;
        HoraEvento = horaEvento;
        Descripcion = descripcion;
        AreaInteres = areaInteres;
        CantLikes = 0;
    }

    // Método para dar like al evento
    public void DarLike()
    {
        CantLikes++;
    }

    public override string ToString()
    {
        return $"Mail: {MailCreador}, Nombre del Creador: {NombreCreador},Fecha del Evento: {FechaEvento}, Hora Evento: {HoraEvento}, Dirección: {Dirección}, Area de Interes: {AreaInteres}, Descripción {Descripcion}";
    }
}
