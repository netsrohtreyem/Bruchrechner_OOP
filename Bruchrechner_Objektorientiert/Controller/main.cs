// Name:            Fabula
// Datum:           23.09.2019
// Dateiname:       main.cs
// Beschreibung:    main Funktion des Projektes Bruchrechner_Objektorientiert

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechner_Objektorientiert
{
    partial class main
    {
        static void Main(string[] args)
        {
            Controller Verwalter = new Controller();

            Verwalter.Run();
        }
    }
}
