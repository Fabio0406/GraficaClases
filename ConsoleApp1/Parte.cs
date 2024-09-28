using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Parte
    {
        [JsonProperty(Order = 1)]
        public Vertice CentroDeMasa { get;  set; }
        [JsonProperty(Order = 2)]
        public Dictionary<string, Cara> caras;

        public Parte(Vertice centroDeMasa)
        {
            caras = new Dictionary<string, Cara>();
            CentroDeMasa = centroDeMasa;
        }
        private void DibujarEjes()
        {
            // Dibuja el eje X en rojo
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(1.0f, 0.0f, 0.0f); // Rojo para el eje X
            GL.Vertex3(-10.0f, 0.0f, 0.0f); // Punto negativo en X
            GL.Vertex3(10.0f, 0.0f, 0.0f); // Punto positivo en X
            GL.End();

            // Dibuja el eje Y en verde
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.0f, 1.0f, 0.0f); // Verde para el eje Y
            GL.Vertex3(0.0f, -10.0f, 0.0f); // Punto negativo en Y
            GL.Vertex3(0.0f, 10.0f, 0.0f); // Punto positivo en Y
            GL.End();

            // Dibuja el eje Z en azul
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.0f, 0.0f, 1.0f); // Azul para el eje Z
            GL.Vertex3(0.0f, 0.0f, -10.0f); // Punto negativo en Z
            GL.Vertex3(0.0f, 0.0f, 10.0f); // Punto positivo en Z
            GL.End();

            // Resetea el color para evitar que afecte otros objetos
            GL.Color3(1.0f, 1.0f, 1.0f); // Blanco por defecto
        }

        public void AgregarCara(string nombre, Cara cara)
        {
            caras.Add(nombre, cara);
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Cara Cara1 in caras.Values)
            {
                Cara1.Trasladar(x, y, z);
            }
        }
        public void Escalar(float n)
        {
            foreach (Cara cara in caras.Values)
            {
                cara.Escalar(n);
            }
        }
        public void Rotar(string eje, float angulo)
        {
            foreach (Cara cara in caras.Values)
            {
                cara.Rotar(eje, angulo);
            }
        }
        public void Dibujar()
        {
            foreach (Cara cara in caras.Values)
            {
                cara.Trasladar((float)CentroDeMasa.X, (float)CentroDeMasa.Y, (float)CentroDeMasa.Z);
                cara.Draw();
            }
            DibujarEjes();

        }

        
    }
}