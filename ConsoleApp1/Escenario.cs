
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Escenario
    {
        public Dictionary<string, Objeto> objetos;
        private float originX, originY, originZ;

        public Escenario(float originX, float originY, float originZ)
        {
            this.originX = originX;
            this.originY = originY;
            this.originZ = originZ;
            objetos = new Dictionary<string, Objeto>();
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


        public void AgregarObjeto(string nombre, Objeto objeto)
        {
            objetos.Add(nombre, objeto);
        }

        public Objeto get(string nombreobjeto)
        {
            if (objetos.ContainsKey(nombreobjeto))
            {
                return objetos[nombreobjeto];
            }
            else
            {
                throw new Exception($"La parte {nombreobjeto} no existe en este objeto.");
            }
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Trasladar(x, y, z);
            }
        }
        public void Escalar(float n)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Escalar(n);
            }
        }
        public void Rotar(string eje, float angulo)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Rotar(eje, angulo);
            }
        }
        public void Dibujar()
        {
            DibujarEjes();
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Trasladar(originX, originY, originZ);
                objeto.Dibujar();
            }
        }
    }
}