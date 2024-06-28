using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApp
{
    internal class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public int Edad { get; set; }
        public string Region { get; set; }
        public List<string> Intereses { get; set; }

        public Usuario(string nombre, string apellido, string mail, string telefono, string contraseña, int edad, string region, List<string> intereses)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Telefono = telefono;
            Contraseña = contraseña;
            Edad = edad;
            Region = region;
            Intereses = intereses;
        }

        public void AgregarInteres(string interes)
        {
            Intereses.Add(interes);
        }

        public void ImprimirDetalles()
        {
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo: {Mail}");
            Console.WriteLine($"Región: {Region}");
            Console.WriteLine("Intereses:");
            foreach (var interes in Intereses)
            {
                Console.WriteLine($"- {interes}");
            }
        }
        public override string ToString()
        {
            string intereses = Intereses != null ? string.Join(", ", Intereses) : "Ninguno";
            return $"Nombre: {Nombre} {Apellido}\n Edad: {Edad}\n Teléfono: {Telefono}\n Correo: {Mail}\n Región: {Region}\n Intereses: {intereses}";
        }
    }
}
