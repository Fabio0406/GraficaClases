using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    internal class Parte
    {
        public Dictionary<string, Cara> caras;

        public Parte()
        {
            caras = new Dictionary<string, Cara>();
        }

        public void AgregarCara(string nombre, Cara cara)
        {
            caras.Add(nombre, cara);
        }

        public void Dibujar(float offsetX, float offsetY, float offsetZ)
        {
            foreach (Cara cara in caras.Values)
            {
                cara.Draw(offsetX, offsetY, offsetZ);
            }
        }
    }
}
