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

namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private Escenario Escenario1;
        private float rotationAngle = 0.0f;

        public Game() : base(800, 600) // Constructor que define el tamaño de la ventana
        {
            Escenario1=new Escenario(0.0f,0.0f,0.0f);
            Objeto t=new Objeto(0.0f, 0.0f, 0.0f);
            
            //Partes de la T
            Parte Tsuperior = new Parte();
            Parte Tinferior = new Parte(); 
            //Caras
            Cara TSCFrente = new Cara();
            Cara TSCSuperior = new Cara();
            Cara TSCInferior = new Cara();
            Cara TSCPosterior = new Cara();
            Cara TSCDerecha = new Cara();
            Cara TSCIzquierda = new Cara();

            Cara TICFrente = new Cara();
            Cara TICSuperior = new Cara();
            Cara TICInferior = new Cara();
            Cara TICPosterior = new Cara();
            Cara TICDerecha = new Cara();
            Cara TICIzquierda = new Cara();

            //Armar el escenario
            Escenario1.AgregarObjeto("T", t);


            //Ensamblar T
            t.AgregarParte("Superior", Tsuperior);
            t.AgregarParte("Inferior", Tinferior);
            

           

            //Ensamblar partes
            Tsuperior.AgregarCara("frente", TSCFrente);
            Tsuperior.AgregarCara("superior",TSCSuperior);
            Tsuperior.AgregarCara("inferior", TSCInferior);
            Tsuperior.AgregarCara("posterior", TSCPosterior);
            Tsuperior.AgregarCara("derecha", TSCDerecha);
            Tsuperior.AgregarCara("izquierda", TSCIzquierda);

            Tinferior.AgregarCara("frente", TICFrente);
            Tinferior.AgregarCara("superior", TICSuperior);
            Tinferior.AgregarCara("inferior", TICInferior);
            Tinferior.AgregarCara("posterior", TICPosterior);
            Tinferior.AgregarCara("derecha", TICDerecha);
            Tinferior.AgregarCara("izquierda", TICIzquierda);


            //Vertices
            Vertice[] v1 = {
                new Vertice(-4, 3.5, 2),
                new Vertice(4, 3.5, 2), 
                new Vertice(4, -1, 2),
                new Vertice(- 4, -1, 2)
            };
            TSCFrente.LoadVertices(v1);

            Vertice[] v2 = {
                new Vertice(4, 3.5, 2),
                new Vertice(4, 3.5, -2),
                new Vertice(4, -1, -2),
                new Vertice(4, -1, 2)
            };
            TSCDerecha.LoadVertices(v2);

            Vertice[] v3 = {
                new Vertice(-4, 3.5, -2),
                new Vertice(4, 3.5, -2),
                new Vertice(4, -1, -2),
                new Vertice(-4, -1, -2)
            };
            TSCPosterior.LoadVertices(v3);

            Vertice[] v4 = {
                new Vertice(-4, 3.5, 2),
                new Vertice(-4, 3.5, -2),
                new Vertice(-4, -1, -2),
                new Vertice(-4, -1, 2)
            };
            TSCIzquierda.LoadVertices(v4);

            Vertice[] v5 = {
                new Vertice(-4, 3.5, 2),
                new Vertice(-4, 3.5, -2),
                new Vertice(4, 3.5, -2),
                new Vertice(4, 3.5, 2)
            };
            TSCSuperior.LoadVertices(v5);

            Vertice[] v6 = {
                new Vertice(-4, -1, 2),
                new Vertice(-4, -1, -2),
                new Vertice(4, -1, -2),
                new Vertice(4, -1, 2)
            };
            TSCInferior.LoadVertices(v6);



            Vertice[] v7 = {
                new Vertice(-1.5, 3.5, 2),
                new Vertice(1.5, 3.5, 2),
                new Vertice(1.5, -10, 2),
                new Vertice(-1.5, -10, 2)
            };
            TICFrente.LoadVertices(v7);

            Vertice[] v8 = {
                new Vertice(1.5, 3.5, 2),
                new Vertice(1.5, 3.5, -2),
                new Vertice(1.5, -10, -2),
                new Vertice(1.5, -10, 2)
            };
            TICDerecha.LoadVertices(v8);

            Vertice[] v9 = {
                new Vertice(-1.5, 3.5, -2),
                new Vertice(1.5, 3.5, -2),
                new Vertice(1.5, -10, -2),
                new Vertice(-1.5, -10, -2)
            };
            TICPosterior.LoadVertices(v9);

            Vertice[] v10 = {
                new Vertice(-1.5, 3.5, 2),
                new Vertice(-1.5, 3.5, -2),
                new Vertice(-1.5, -10, -2),
                new Vertice(-1.5, -10, 2)
            };
            TICIzquierda.LoadVertices(v10);

            Vertice[] v11 = {
                new Vertice(-1.5, 3.5, 2),
                new Vertice(-1.5, 3.5, -2),
                new Vertice(1.5, 3.5, -2),
                new Vertice(1.5, 3.5, 2)
            };
            TICSuperior.LoadVertices(v11);

            Vertice[] v12 = {
                new Vertice(-1.5, -10, 2),
                new Vertice(-1.5, -10, -2),
                new Vertice(1.5, -10, -2),
                new Vertice(1.5, -10, 2)
            };
            TICInferior.LoadVertices(v12);

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

            // Ajustar la vista en caso de que se redimensione la ventana
            GL.Viewport(0, 0, Width, Height);
        }
    }
}