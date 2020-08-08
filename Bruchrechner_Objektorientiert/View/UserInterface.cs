// Name:            Fabula
// Datum:           23.09.2019
// Dateiname:       UserInterface.cs
// Beschreibung:    UserInterface Klasse für Konsolenausgaben.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bruchrechner_Objektorientiert
{
    class UserInterface
    {
        #region Eigenschaften
        private Bruch _Bruchobjekt;
        private string _Text;
        #endregion

        #region Accessoren/Modifier
        public Bruch Bruchobjekt { get => _Bruchobjekt; set => _Bruchobjekt = value; }
        public string Text { get => _Text; set => _Text = value; }
        #endregion

        #region Konstruktoren 
        public UserInterface()
        {
            this.Bruchobjekt = new Bruch();
            this.Text = "";
        }

        public UserInterface(string value)
        {
            this.Bruchobjekt = null;
            this.Text = value;
        }
        public UserInterface(Bruch value)
        {
            this.Bruchobjekt.Zuweisung(value);
            this.Text = "";
        }
        #endregion

        #region Worker
        public void BruchEinlesen(ref Bruch eingabe)
        {
            Console.WriteLine("Bitte geben sie den Zähler an:");
            int zaehl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben sie den Nenner an:");
            int nenn = Convert.ToInt32(Console.ReadLine());

            this.Bruchobjekt = new Bruch(zaehl, nenn);

            eingabe.Zuweisung(this.Bruchobjekt);
        }

        public char Menue()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("------------------------- Hauptmenü -------------------------");
            Console.WriteLine("");
            Console.WriteLine("     (0) - Brüche addieren.       [ + ]");
            Console.WriteLine("     (1) - Brüche subtrahieren.   [ - ]");
            Console.WriteLine("     (2) - Brüche multiplizieren. [ * ]");
            Console.WriteLine("     (3) - Brüche dividieren.     [ / ]");
            Console.WriteLine("");
            Console.WriteLine("     (4) - Beenden.");
            Console.WriteLine("");

            //  Der Benutzer kann nun zwischen Funktionen des Programms waehlen.
            //  Die Funktionsnamen bzw. Beschreibungen sollten selbsterklaerend sein.
            while (!Console.KeyAvailable) ;
            ConsoleKeyInfo id = Console.ReadKey(true);
            char auswahl = id.KeyChar;

            return auswahl;
        }

        public void Programmbeenden()
        {
            Console.Clear();
            Console.WriteLine("Programm wird beendet!");
            Console.WriteLine("Taste druecken");
            while (!Console.KeyAvailable) ;
            Console.ReadKey(false);
        }

        public void splash()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|    Programm: Bruchrechnen V1.00                            |");
            Console.WriteLine("|       Autor: Fabula                                     |");
            Console.WriteLine("|       Datum: 09/2019                                       |");
            Console.WriteLine("|              angepasst 08.08.2020, Meyer                   |");
            Console.WriteLine("|Beschreibung: Anwendung zum Rechnen mit Bruechen.           |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("------------------------- WILLKOMMEN -------------------------");
            Console.WriteLine("");
            Console.WriteLine("     Drücken Sie ENTER..");

            Console.ReadLine();
        }

        public void TextEinlesen(ref string eingabe)
        {
            eingabe = Console.ReadLine();
        }
        public void TextAusgeben(string value)
        {
            this.Text = value;
            Console.WriteLine(value);
        }
        public void BruchAusgeben(Bruch value)
        {
            Console.WriteLine(value.Vorzeichen + " " + value.Zaehler + "/" + value.Nenner);
            Console.WriteLine("Taste druecken");
            while (!Console.KeyAvailable) ;
            Console.ReadKey(true);
        }
        #endregion
    }
}