using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MAnejoEventos
{

    public delegate void MyDelegate(string message);
   
    class Program
    {
       
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>

        public class Empleado
        {
            public event MyDelegate NombreCambiado;
            private string  _name;
            

            public Empleado(string name)
            {
                Name = name;
            }

            public  string Name
            {

                set
                {
                    string nombreAnteriror = this._name;
                    _name = value;
                    if((NombreCambiado != null)&&(_name.Equals("Zafiro")))
                    NombreCambiado("Antes era:" + nombreAnteriror + ", ahora es:" + this._name);
                }
            }
        }
        
/// <summary>
/// ////////////////////////////////////////////////////////////
/// </summary>
/// <param name="args"></param>

        static void Main(string[] args)
        {

            //var fuente = new Fuente();
            //fuente.myEvent += new MyDelegate(OnMyEvent);
          //  fuente.MessageShowing();   
     

            var empleado = new Empleado("Roberto");
            empleado.NombreCambiado += new MyDelegate(NotificarCambioNombre);

            int x = 0;
            while (x<=3)
            {
                Console.WriteLine("New name");
                string newName = Console.ReadLine();
                empleado.Name = newName;
                x++;
            }


        }

        static void NotificarCambioNombre(string name)
        {

            Console.WriteLine("Hubo un cambio!!!!");
            Console.WriteLine(name);
        }

        static void OnMyEvent(string text)
        {
            //Console.WriteLine(text);
        }
    }
}
