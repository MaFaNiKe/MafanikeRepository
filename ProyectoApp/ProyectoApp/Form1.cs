using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
// using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;


namespace ProyectoApp
{
    public partial class Form1 : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private Usuario usuarioActual;
        private List<Post> posts = new List<Post>();
        private int postIndice = 0;
        private int eventoIndice = 0;
        private bool post_o_evento;
        private List<Evento> eventos = new List<Evento>();

        public Form1()
        {
            InitializeComponent();

            // Inicializar usuarios precargados
            InicializarUsuarios();

            // Inicializar posts precargados
            InicializarPosts();

            // Configurar vista inicial
            MostrarPanel(panelInicioSesion);

            InicializarEventos();
        }

        private void MostrarPanel(Panel panelAMostrar)
        {
            // Ocultar todos los paneles primero
            panelInicioSesion.Visible = false;
            panelCrearCuenta.Visible = false;
            panelVerPerfiles.Visible = false;
            panelPrincipal.Visible = false;
            panelPerfil.Visible = false;
            panelCrearPost.Visible = false;
            panelCrearEvento.Visible = false;
            // Mostrar el panel recibido como parámetro
            panelAMostrar.Visible = true;
            if (panelAMostrar == panelPrincipal) 
            {
                if (post_o_evento == true)
                {
                    postIndice = 0;
                    MostrarPosts(postIndice);
                }
                else if (post_o_evento == false) 
                {
                    eventoIndice = 0;
                    MostrarEvento(eventoIndice);
                }
            }
        }

        private void InicializarUsuarios()
        {
            // Crear algunos usuarios precargados
            List<string> intereses1 = new List<string> { "Deportes", "Tecnología", "Viajes" };
            Usuario usuario1 = new Usuario("Juan", "Pérez", "juan@gmail.com", "123456789", "contraseña1", 30, "Artigas", intereses1);

            List<string> intereses2 = new List<string> { "Música", "Arte", "Cocina" };
            Usuario usuario2 = new Usuario("María", "Gómez", "maria@gmail.com", "987654321", "contraseña2", 25, "Maldonado", intereses2);

            List<string> intereses3 = new List<string> { "Videojuegos", "Ciencia", "Libros" };
            Usuario usuario3 = new Usuario("Carlos", "Martínez", "carlos@gmail.com", "456789123", "contraseña3", 35, "Canelones", intereses3);

            // Agregar usuarios a la lista
            usuarios.Add(usuario1);
            usuarios.Add(usuario2);
            usuarios.Add(usuario3);
        }

        private void InicializarPosts()
        {
            // Crear algunos posts precargados
            Post post1 = new Post("juan@gmail.com", "Juan", DateTime.Now.AddDays(-2), "¡Hoy jugué un partido de fútbol increíble!", "Deportes");
            Post post2 = new Post("maria@gmail.com", "María", DateTime.Now.AddDays(-3), "Acabo de terminar un nuevo cuadro en mi clase de arte.", "Arte");
            Post post3 = new Post("carlos@gmail.com", "Carlos", DateTime.Now.AddDays(-1), "Descubrí un nuevo juego de estrategia, ¡es muy adictivo!", "Videojuegos");

            // Agregar posts a la lista
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);

        }

        private void InicializarEventos()
        {
            Evento evento1 = new Evento("juan@gmail.com", "Juan Pérez", DateTime.Now.AddDays(-5), "Concierto de rock en el parque central.", "Música");
            Evento evento2 = new Evento("maria@gmail.com", "María Gómez", DateTime.Now.AddDays(-10), "Exposición de arte contemporáneo en la galería principal.", "Arte");
            Evento evento3 = new Evento("carlos@gmail.com", "Carlos Martínez", DateTime.Now.AddDays(-3), "Competencia de videojuegos en el centro de eventos.", "Videojuegos");
            Evento evento4 = new Evento("ana@gmail.com", "Ana López", DateTime.Now.AddDays(-7), "Clase magistral de cocina internacional en el instituto culinario.", "Cocina");
            Evento evento5 = new Evento("pedro@gmail.com", "Pedro Rodríguez", DateTime.Now.AddDays(-2), "Seminario de tecnología y nuevas tendencias en la universidad.", "Tecnología");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar ListView al cargar el formulario
            ConfigurarListView();
            MostrarPosts(postIndice);
        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNomb.Text.Trim();
            string apellido = textBoxApe.Text.Trim();
            string mail = textBoxCorreo.Text.Trim();
            string telefono = textBoxTel.Text.Trim();
            string contraseña = textBoxContra.Text.Trim();
            string confirmarContraseña = textBoxConfContra.Text.Trim();
            int edad = Convert.ToInt32(comboBoxEdad.SelectedItem);
            string region = comboBoxRegion.SelectedItem.ToString();

            // Validacion que todos los campos estén completos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(mail)
                || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmarContraseña) ||
                string.IsNullOrEmpty(confirmarContraseña) || edad == 0 || string.IsNullOrEmpty(region))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            // Validar formato de correo electrónico
            if (!ValidarCorreo(mail))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido");
                return;
            }

            // Verificar si el correo existe
            if (CorreoExistente(mail))
            {
                MessageBox.Show("El correo electrónico ya está registrado");
                return;
            }

            // Bucle do-while para validar que las contraseñas coincidan
            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor intentalo de nuevo");
                return;
            }

            // Obtener intereses seleccionados por el usuario
            List<string> interesesSeleccionados = new List<string>();
            for (int i = 0; i < checkedListBoxIntereses.CheckedItems.Count; i++)
            {
                interesesSeleccionados.Add(checkedListBoxIntereses.CheckedItems[i].ToString());
            }

            // Crear nuevo usuario
            Usuario nuevoUsuario = new Usuario(nombre, apellido, mail, telefono, contraseña, edad, region, interesesSeleccionados);

            MostrarUsuarioEnTextBox(nuevoUsuario);

            usuarios.Add(nuevoUsuario);
            AgregarUsuarioAlListView(nuevoUsuario);
            MessageBox.Show("Usuario creado exitosamente");

            // Limpiar formulario
            LimpiarFormulario();
        }

        private void ConfigurarListView()
        {
            // Configurar el ListView
            listView1.View = View.Details;
            listView1.Columns.Add("Nombre", 120);
            listView1.Columns.Add("Apellido", 120);
            listView1.Columns.Add("Correo", 200);
            listView1.Columns.Add("Contraseña", 200);
            listView1.Columns.Add("Edad", 50);
            listView1.Columns.Add("Región", 100);
            listView1.Columns.Add("Intereses", 150);

            // Agregar usuarios al ListView
            for (int i = 0; i < usuarios.Count; i++)
            {
                Usuario usuario = usuarios[i];
                ListViewItem item = new ListViewItem(usuario.Nombre);
                item.SubItems.Add(usuario.Apellido);
                item.SubItems.Add(usuario.Mail);
                item.SubItems.Add(usuario.Contraseña);
                item.SubItems.Add(usuario.Edad.ToString());
                item.SubItems.Add(usuario.Region);
                item.SubItems.Add(string.Join(",", usuario.Intereses));
                listView1.Items.Add(item);
            }
        }

        private void AgregarUsuarioAlListView(Usuario usuario)
        {
            ListViewItem item = new ListViewItem(usuario.Nombre);
            item.SubItems.Add(usuario.Apellido);
            item.SubItems.Add(usuario.Mail);
            item.SubItems.Add(usuario.Contraseña);
            item.SubItems.Add(usuario.Edad.ToString());
            item.SubItems.Add(usuario.Region);
            item.SubItems.Add(string.Join(",", usuario.Intereses));
            listView1.Items.Add(item);
        }

        private bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private bool CorreoExistente(string correo)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Mail == correo)
                {
                    return true;
                }
            }
            return false;
        }

        private void MostrarUsuarioEnTextBox(Usuario usuario)
        {
            richTextBoxDetallesUsuario.Text = $"Nombre: {usuario.Nombre} \n" +
                $"Apellido: {usuario.Apellido} \n" +
                $"Correo: {usuario.Mail} \n" +
                $"Teléfono: {usuario.Telefono} \n" +
                $"Edad: {usuario.Edad} \n" +
                $"Region: {usuario.Region} \n" +
                $"Intereses: {string.Join(",", usuario.Intereses)}";
        }

        private void LimpiarFormulario()
        {
            textBoxNomb.Clear();
            textBoxApe.Clear();
            textBoxCorreo.Clear();
            textBoxTel.Clear();
            textBoxContra.Clear();
            textBoxConfContra.Clear();
            comboBoxEdad.SelectedIndex = -1;
            comboBoxRegion.SelectedIndex = -1;
            for (int i = 0; i < checkedListBoxIntereses.Items.Count; i++)
            {
                checkedListBoxIntereses.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void IniciarSesion_Click(object sender, EventArgs e)
        {
            string correoInicio = textBoxCorreoInicio.Text.Trim();
            string contraseñaInicio = textBoxContraInicio.Text.Trim();

            if (string.IsNullOrEmpty(correoInicio) || string.IsNullOrEmpty(contraseñaInicio))
            {
                MessageBox.Show("Por favor, complete todos los campos para iniciar sesión");
                return;
            }

            Usuario usuarioEncontrado = null;
            for (int i = 0; i < usuarios.Count ; i++)
            {
                if (usuarios[i].Mail == correoInicio && usuarios[i].Contraseña == contraseñaInicio)
                {
                    usuarioEncontrado = usuarios[i];
                    break;
                }
            }

            if (usuarioEncontrado != null)
            {
                usuarioActual = usuarioEncontrado; // Almacenar el usuario actual
                MessageBox.Show($"Inicio de sesión exitoso para {usuarioActual.Nombre} {usuarioActual.Apellido}");
                MostrarPanel(panelPrincipal); // Muestra el panel principal de la red social, donde se verán los post
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. No se reconoce el usuario.");
            }
            textBoxCorreoInicio.Clear();
            textBoxContraInicio.Clear();
        }

        private void MostrarDatosDeUsuarioEnPerfi(Usuario usuario)
        {
            textBoxNombPerfil.Text = $"{usuario.Nombre}";
            textBoxApePerfil.Text = $"{usuario.Apellido}";
            textBoxCorreoPerfil.Text = $"{usuario.Mail}";
            textBoxTelPerfil.Text = $"{usuario.Telefono}";
            textBoxContraPerfil.Text = $"{usuario.Contraseña}";
            textBoxEdadPerfil.Text = $"{usuario.Edad}";
            textBoxRegionPerfil.Text = $"{usuario.Region}";
            textBoxInteresesPerfil.Text = $"{string.Join(", ", usuario.Intereses)}";
        }

        private void crearCuentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MostrarPanel(panelCrearCuenta);
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelInicioSesion);
        }

        private void verPerfilesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MostrarPanel(panelVerPerfiles);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuarioActual != null)
            {
                MostrarPanel(panelPerfil);
                MostrarDatosDeUsuarioEnPerfi(usuarioActual);
            }
            else
            {
                MessageBox.Show("No hay ningún usuario logueado.");
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelPrincipal);
        }

        private void buttonVolver2_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelPrincipal); // Vuelve al panel principal
            MostrarPosts(postIndice); // Actualiza la lista de posts
        }

        private void CrearPost()
        {
            // Obtener texto ingresado por el usuario
            string texto = textBoxContPost.Text.Trim();

            // Verificar que se haya seleccionado un área de interés
            if (comboBoxIntereses.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un área de interés.");
                return;
            }

            string areaInteres = comboBoxIntereses.SelectedItem.ToString();

            DateTime fechaHoraActual = DateTime.Now;

            if (usuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión para crear un post.");
                return;
            }

            Post nuevoPost = new Post(usuarioActual.Mail, usuarioActual.Nombre, fechaHoraActual, texto, areaInteres);

            posts.Add(nuevoPost);

            MessageBox.Show("Post creado exitosamente.");

            LimpiarFormularioCrearPost();
        }

        private void CrearEvento() 
        {
            string textoIngresado = textBoxContEvento.Text.Trim();
            if (comboBoxAreaEvento.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un área de interes para el evento");
                return;
            }
            string areaInteresEvento = comboBoxAreaEvento.SelectedItem.ToString();
            DateTime fechaHoraCreacionEvento = DateTime.Now;

            if (usuarioActual == null) 
            {
                MessageBox.Show("Debe iniciar sesión para crear un post.");
                return;
            }

            Evento nuevoEvento = new Evento(usuarioActual.Mail, usuarioActual.Nombre, fechaHoraCreacionEvento, textoIngresado, areaInteresEvento );
            eventos.Add(nuevoEvento);
            MessageBox.Show("Evento Creado y publicado Exitosamente");
            LimpiarFormularioCrearEvento();

        }
        
        private void LimpiarFormularioCrearPost()
        {
            textBoxContPost.Clear();
            comboBoxIntereses.SelectedIndex = -1;
        }

        private void LimpiarFormularioCrearEvento()
        {
            textBoxContenidoEvento.Clear();
            comboBoxAreaEvento.SelectedIndex = -1;
        }
       
        private void MostrarPosts(int indicePosts)
        {
            if (posts.Count == 0) return;

            Post postActual = posts[indicePosts];
            //panelPostPrincipal.Controls.Clear();
            labelpost.Text = postActual.NombreCreador;
            textBoxContenidoPost.Text = postActual.Texto;
            Fecha.Text = postActual.FechaHora.ToString("g");
            Likes.Text = "Likes: " + postActual.CantLikes;
            labelAreaInteresPost.Text = $"Área de Interés: {postActual.AreaInteres}";
            

        }

        private void MostrarEvento(int indiceEvento)
        {
            if (indiceEvento >= 0 && indiceEvento < eventos.Count)
            {
                Evento eventoActual = eventos[indiceEvento];
                labelEvento.Text = eventoActual.NombreCreador;
                textBoxContenidoEvento.Text = eventoActual.Descripcion;
                labelFechaEvento.Text = eventoActual.FechaHoraCreacion.ToString("g");
                labelLikesEvento.Text = "Likes: " + eventoActual.CantLikes;
                labelTemaEvento.Text = $"Área de Interés: {eventoActual.AreaInteres}";
            }
        }

        private void crearPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelCrearPost);
        }

        private void buttonPublicar_Click_1(object sender, EventArgs e)
        {
            CrearPost(); // Llama al método para crear el post
            MostrarPanel(panelPrincipal); // Vuelve al panel principal
        }

        private void buttonSiguientePost_Click(object sender, EventArgs e)
        {
            postIndice = (postIndice + 1) % posts.Count;
            MostrarPosts(postIndice);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void crearEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelCrearEvento);
        }

        private void buttonPublicarEvento_Click(object sender, EventArgs e)
        {
            CrearEvento();
            MostrarPanel(panelPrincipal);
        }

        private void buttonSiguienteEvento_Click(object sender, EventArgs e)
        {
            eventoIndice = (eventoIndice + 1) % eventos.Count;
            MostrarEvento(eventoIndice);
        }

        private void verEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            post_o_evento = false;
        }

        private void verPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            post_o_evento = true;
        }
    }
}
