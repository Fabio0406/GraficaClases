using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using ConsoleApp1.Clases;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private Escenario Escenario1;
        private float rotationAngle = 0.0f;

        public Game() : base(800, 600) // Constructor que define el tamaño de la ventana
        {
            // Leer el JSON desde el archivo
            string json = File.ReadAllText(@"C:\Users\fabio\Documents\UAGRM\Semestre 2-2024\Grafica\ProgramGrafica-Tarea3\ConsoleApp1\escenario.txt");

            // Deserializar el JSON en el objeto Escenario1
            Escenario1 = JsonConvert.DeserializeObject<Escenario>(json);

            // Serializa el escenario
            //SerializarEscenario(@"C:\Users\fabio\Documents\UAGRM\Semestre 2-2024\Grafica\ProgramGrafica-Tarea3\ConsoleApp1\escenario.txt");
        }

        private void SerializarEscenario(string filePath)
        {
            try
            {
                // Serializar el escenario a formato JSON
                string json = JsonConvert.SerializeObject(Escenario1, Formatting.Indented);

                // Guardar el JSON en un archivo .txt
                File.WriteAllText(filePath, json);

                Console.WriteLine("Escenario serializado exitosamente en: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error serializando el escenario: " + ex.Message);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.FromArgb(0, 100, 0));
            GL.Enable(EnableCap.DepthTest); // Profundidad
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            rotationAngle += 6.5f * (float)e.Time; // Rotación
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Frustum(-1.0, 1.0, -1.0, 1.0, 1.0, 100.0); // Proyección perspectiva
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Posiciona y orienta la cámara
            GL.Translate(0.0f, 0.0f, -15.0f); // Mueve la cámara hacia atrás
            GL.Rotate(0.0f, 1.0f, 0.0f, 0.0f); // Inclina la vista hacia abajo
            GL.Rotate(40.0f + rotationAngle, 0.0f, 1.0f, 0.0f); // Rota la vista hacia un ángulo lateral

            Escenario1.Dibujar();

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }
    }
}
