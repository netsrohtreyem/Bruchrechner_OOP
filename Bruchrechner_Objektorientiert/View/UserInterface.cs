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
            try
            {
                this.Bruchobjekt = new Bruch(zaehl, nenn);
            }
            catch(Exception ex)
            {
                this.Bruchobjekt = new Bruch(zaehl, 1);
            }
            eingabe.Zuweisung(this.Bruchobjekt);

        }
        private void printRechnung(char rechenzeichen, String a, String b, String c, String d)
        {
            Console.Clear();
            Console.WriteLine("          " + a + "       " + c);
            Console.WriteLine("Format:  ---  " + rechenzeichen + "  ---");
            Console.WriteLine("          " + b + "       " + d);
            Console.WriteLine("");
        }
        public void printErgebnis(Bruch ergebnis)
        {
            this.Bruchobjekt = new Bruch(ergebnis);

            bool negativ = false;
            String ganzeZahl = "";
            //Vorzeichen?
            if (ergebnis.Zaehler < 0 && ergebnis.Nenner > 0)
            {
                Bruchobjekt.Zaehler = Bruchobjekt.Zaehler * (-1);
                negativ = true;
            }
            else if (ergebnis.Zaehler > 0 && ergebnis.Nenner < 0)
            {
                Bruchobjekt.Nenner = Bruchobjekt.Nenner * (-1);
                negativ = true;
            }
            else if (ergebnis.Zaehler < 0 && ergebnis.Nenner < 0)
            {
                Bruchobjekt.Zaehler = Bruchobjekt.Zaehler * (-1);
                Bruchobjekt.Nenner = Bruchobjekt.Nenner * (-1);
                negativ = false;
            }
            else
            {
                negativ = false;
            }

            if (Bruchobjekt.Zaehler == Bruchobjekt.Nenner)
            {
                ganzeZahl = "1";
                Bruchobjekt.Zaehler = 1;
                Bruchobjekt.Nenner = 1;
            }
            else
            { }

            if (negativ)
            {
                ganzeZahl = "-" + ganzeZahl;
            }
            else
            {
                ganzeZahl = "+" + ganzeZahl;
            }
            if (Bruchobjekt.Zaehler == 0)
            {
                Console.Clear();
                Console.WriteLine("ERGEBNIS: 0");
                Console.WriteLine("");
            }
            else if (Bruchobjekt.Zaehler == 1 && Bruchobjekt.Nenner == 1)
            {
                Console.Clear();
                Console.WriteLine("ERGEBNIS: "+ ganzeZahl);
                Console.WriteLine("");
            }
            else if (Bruchobjekt.Nenner == 1)
            {
                Console.Clear();
                Console.WriteLine("ERGEBNIS: " + ganzeZahl + " " + Bruchobjekt.Zaehler);
                Console.WriteLine("");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("             " + Bruchobjekt.Zaehler);
                Console.WriteLine("ERGEBNIS: " + ganzeZahl + " ---");
                Console.WriteLine("             " + Bruchobjekt.Nenner);
                Console.WriteLine("");
            }
            Console.WriteLine("\nWeiter mit einer beliebigen Taste!");
            while (!Console.KeyAvailable) ;
            Console.ReadKey();
        }
        public void RechnungEinlesen(Bruch bruch1,Bruch bruch2,char zeichen)
        {
            Console.Clear();
            printRechnung(zeichen, "A", "B", "C", "D");
            Console.WriteLine("Bitte den Zähler des ersten Bruchs angeben (A):");
            bruch1.Zaehler = parser(Console.ReadLine(), 1, '+');

            printRechnung(zeichen, "" + bruch1.Zaehler, "B", "C", "D");
            Console.WriteLine("Bitte den Nenner des ersten Bruchs angeben (B):");
            bruch1.Nenner = parser(Console.ReadLine(), 2, zeichen);

            printRechnung(zeichen, "" + bruch1.Zaehler, "" + bruch1.Nenner, "C", "D");
            Console.WriteLine("Bitte den Zähler des zweiten Bruchs angeben (C):");
            bruch2.Zaehler = parser(Console.ReadLine(), 1, zeichen);

            printRechnung(zeichen, "" + bruch1.Zaehler, "" + bruch1.Nenner, "" + bruch2.Zaehler, "D");
            Console.WriteLine("Bitte den Nenner des zweiten Bruchs angeben (D):");
            bruch2.Nenner = parser(Console.ReadLine(), 2, zeichen);

            
            printRechnung(zeichen, "" + bruch1.Zaehler, "" + bruch1.Nenner, "" + bruch2.Zaehler, "" + bruch2.Nenner);
            Console.WriteLine("Drücken Sie ENTER...");
            Console.ReadLine();
        }
        private int parser(String data, int status,char zeichen)
        {
            this.Text = data;
            String pData = data + "#";
            String newData = "";
            bool valid = true;
            String id = "";

            int x = 0;
            while (pData[x] != '#')
            {
                if ((pData[x] != '1') && (pData[x] != '2') && (pData[x] != '3') && (pData[x] != '4')
                     && (pData[x] != '5') && (pData[x] != '6') && (pData[x] != '7') && (pData[x] != '8') && (pData[x] != '9')
                    && (pData[x] != '0') && (pData[x] != '-'))
                {
                    valid = false;
                }
                else
                {
                    newData = newData + pData[x];
                }
                x++;
            }

            if (newData == "")
            {
                newData = "1";
            }
            else
            {
            }

            if (!valid)
            {
                Console.WriteLine("");
                Console.WriteLine("Die eingegebene Zahl '" + data + "' enthaelt unerlaubte Zeichen.");
                Console.WriteLine("- Meinten Sie '" + newData + "' ? -");
                Console.WriteLine(" (0) - JA.");
                Console.WriteLine(" (1) - NEIN.");

                id = Console.ReadLine();
                if (id == "0")
                {

                }
                else if (id == "1")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bitte erneut eingeben:");
                    Double temp = 0;
                    temp = parser(Console.ReadLine(), status, zeichen);
                    newData = Convert.ToString(temp);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Menuepunkt " + id + " gibt es nicht. Bitte erneut..");
                    Console.ReadLine();
                    Double temp = 0;
                    temp = parser(data, status, zeichen);
                    newData = Convert.ToString(temp);
                }
            }
            else
            {
            }

            if (data.Equals("0") && status == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("'" + data + "' fuer Nenner ist nicht erlaubt.");
                Console.WriteLine("");
                Console.WriteLine("Bitte erneut eingeben:");
                Double temp = 0;
                temp = parser(Console.ReadLine(), status,zeichen);
                newData = Convert.ToString(temp);
            }
            else
            {
            }

            if(data.Equals("0") && status == 1 && zeichen == '/')
            {
                Console.WriteLine("");
                Console.WriteLine("'" + data + "' fuer Zähler eines Dividenten ist nicht erlaubt.");
                Console.WriteLine("");
                Console.WriteLine("Bitte erneut eingeben:");
                Double temp = 0;
                temp = parser(Console.ReadLine(), status, zeichen);
                newData = Convert.ToString(temp);
            }
            else
            { }

            if (newData.Contains('-'))
            {
                newData = newData.Replace("-", String.Empty);
                newData = "-" + newData;
            }
            else
            {
            }

            return Convert.ToInt32(newData);
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
            this.Text = auswahl.ToString();
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
            this.Text = Console.ReadLine();
            eingabe = this.Text;
        }
        public void TextAusgeben(string value)
        {
            this.Text = value;
            Console.WriteLine(Text);
        }
        public void BruchAusgeben(Bruch value)
        {
            this.Bruchobjekt = value;
            Console.WriteLine(Bruchobjekt.Vorzeichen + " " + Bruchobjekt.Zaehler + "/" + Bruchobjekt.Nenner);
            Console.WriteLine("Taste druecken");
            while (!Console.KeyAvailable) ;
            Console.ReadKey(true);
        }
        #endregion
    }
}