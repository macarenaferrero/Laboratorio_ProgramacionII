using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiDomo;

namespace MisDomos
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                //Creacion de lista de pendientes y diferentes objetos Domos Geodesicos
                PendienteAConstruir<DomoGeodesico> listaPendiente = new PendienteAConstruir<DomoGeodesico>();
                KitMadera nuevoKit = new KitMadera(4, EFrecuencia.F1, "Agustin", ETipoConexion.GoodKarma);
                KitMadera nuevoKit2 = new KitMadera(5, EFrecuencia.F2, "Macarena", ETipoConexion.Piped);
                KitPVC nuevoKit3 = new KitPVC(2, EFrecuencia.F1, "Silvia");

                //Se agregan a la lista los objetos creados
                bool agregar = listaPendiente + nuevoKit;
                agregar = listaPendiente + nuevoKit2;
                agregar = listaPendiente + nuevoKit3;
                
                //Si se pudieron añadir imprime el detalle de cada objeto
                foreach (DomoGeodesico item in listaPendiente.ListaPendientes)
                {
                    Console.WriteLine(item.InformeFabricacion());
                }

                Console.ReadKey();
                Console.Clear();

                //Se intenta crear y agregar a la lista un objeto con un Radio fuera del rango
                KitPVC nuevoKit4 = new KitPVC(0.5f, EFrecuencia.F2, "Roberto");
                agregar = listaPendiente + nuevoKit4;                

            }
            catch (DomoException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }
    }
}
