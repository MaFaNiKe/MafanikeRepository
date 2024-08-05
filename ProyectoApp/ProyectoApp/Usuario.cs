using System.Collections.Generic;

public class Usuario
{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public int Edad { get; set; }
        public string Region { get; set; }
    public List<string> Intereses { get; set; } // Cambiado a List<string>

        public Usuario(string nombre, string apellido, string mail, string telefono, string contraseña, int edad, string region, List<string> intereses)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Telefono = telefono;
            Contraseña = contraseña;
            Edad = edad;
            Region = region;
        Intereses = intereses; // Cambiado a List<string>
    }
}
