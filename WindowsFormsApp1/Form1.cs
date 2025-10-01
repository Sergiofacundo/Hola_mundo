//*  Este es un formulario de Windows Forms que valida contraseñas usando expresiones regulares.

//* Importación de librerías
using System; //* se usa para tipos básicos como string, int, etc, funciones basicas del sistema
using System.Text.RegularExpressions; //* se usa para trabajar con expresiones regulares
using System.Windows.Forms; //* se usa para crear aplicaciones de Windows Forms, contiene clases para crear interfaces gráficas en Windows


//*Definición del espacio de nombre
namespace WindowsFormsApp1 //* Define el contenedor lógico del proyecto. Aquí se agrupan clases relacionadas 
{
    public partial class Form1 : Form //* clase principal del formulario que hereda de Form
    {
        public Form1() //* Constructor del formulario
        {
            InitializeComponent(); //* carga los controles visuales definidos en el diseñador
            button1.Click += Button1_Click; //* - asocia el evento de clic del botón button1 con el método Button1_Click.
        }

        private void Form1_Load(object sender, EventArgs e) //* Evento de carga del formulario
        {

        }

        private void Button1_Click(object sender, EventArgs e) //* Evento de clic del botón, es donde se ejecuta el nucleo de la logica
        {
            string password = textBox1.Text; //* obtiene el texto del primer cuadro de texto (contraseña)
            string confirmPassword = textBox2.Text; //* obtiene el texto del segundo cuadro de texto (confirmación de contraseña)
            
            // Definición de la expresión.
            // Expresión regular: al menos una mayúscula, una minúscula, un número y un símbolo
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$";
            // Esta expresion regula lo siguiente
            // Que la contraseña contenga:
            // - Al menos una letra mayúscula ([A-Z])
            // - Al menos una letra minúscula ([a-z])
            // - Al menos un número (\d)
            // - Al menos un símbolo o carácter especial ([\W_])

            if (!Regex.IsMatch(password, pattern)) //* valida la contraseña contra el patrón definido
             // Si la contraseña no cumple con el patrón, muestra un mensaje de error y termina la ejecución del método
            {
                MessageBox.Show("La contraseña no cumple con los requisitos."); 
                return;
            }
            // Verifica si las contraseñas coinciden
            if (password != confirmPassword)
            // Si las contraseñas no coinciden, muestra un mensaje de error y termina la ejecución del método
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Si la contraseña es válida y las contraseñas coinciden, muestra un mensaje de éxito
            MessageBox.Show("La contraseña ha sido validada");
        }
    }
}
