// Name:            Fabula
// Datum:           29.09.2019
// Dateiname:       Controller.cs
// Beschreibung:    Controller Klasse die das Programm steuert.
// Aenderungen:     08.08.2020, Meyer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechner_Objektorientiert
{
    class Controller
    {
        #region Eigenschaften
        private Bruch _bruch1;
        private Bruch _bruch2;
        private Bruch _ergebnis;
        private UserInterface _UI;
        #endregion

        #region Accessoren/Modifier
        public Bruch bruch1 { get => _bruch1; set => _bruch1 = value; }
        public Bruch bruch2 { get => _bruch2; set => _bruch2 = value; }
        public Bruch ergebnis { get => _ergebnis; set => _ergebnis = value; }
        public UserInterface UI { get => _UI; set => _UI = value; }
        #endregion

        #region Konstruktoren 
        // Standard Konstruktor
        public Controller()
        {
            bruch1 = new Bruch();
            bruch2 = new Bruch();
            ergebnis = new Bruch();

            UI = new UserInterface();
        }
        #endregion

        #region Worker
        public void Run()
        {
            bool weiter = true;
            //1. Splash anzeigen -> UserInterface
            this.UI.splash();

            while (weiter)
            {
                //2. Menü anzeigen + Menüauswahl einlesen -> UserInterface
                char auswahl = this.UI.Menue();
                //3. Auswahl auswerten -> Controller Geschäftsprozesse
                switch(auswahl)
                {
                    case '0':
                        this.BruecheAddieren();
                        break;
                    case '1':
                        this.BruecheSubtrahieren();
                        weiter = true;
                        break;
                    case '2':
                        this.BruecheMultiplizieren();
                        weiter = true;
                        break;
                    case '3':
                        this.BruecheDividieren();
                        weiter = true;
                        break;
                    case '4':
                        this.Programmbeenden();
                        weiter = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Programmbeenden()
        {
            this.UI.Programmbeenden();
        }

        private void BruecheDividieren()
        {
            Bruch tempBruch = new Bruch();
            //1. Brueche einlesen UserInterface
            UI.BruchEinlesen(ref tempBruch);
            this.bruch1.Zuweisung(tempBruch);
            UI.BruchEinlesen(ref tempBruch);
            this.bruch2.Zuweisung(tempBruch);
            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Dividieren(this.bruch2));
            //3. Ergebnis anzeigen
            this.UI.TextAusgeben("Das Ergebnis lautet:");
            this.UI.BruchAusgeben(ergebnis);
        }

        private void BruecheMultiplizieren()
        {
            Bruch tempBruch = new Bruch();
            //1. Brueche einlesen UserInterface
            UI.BruchEinlesen(ref tempBruch);
            this.bruch1.Zuweisung(tempBruch);
            UI.BruchEinlesen(ref tempBruch);
            this.bruch2.Zuweisung(tempBruch);
            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Multiplizieren(this.bruch2));
            //3. Ergebnis anzeigen
            this.UI.TextAusgeben("Das Ergebnis lautet:");
            this.UI.BruchAusgeben(ergebnis);
        }

        private void BruecheSubtrahieren()
        {
            Bruch tempBruch = new Bruch();
            //1. Brueche einlesen UserInterface
            UI.BruchEinlesen(ref tempBruch);
            this.bruch1.Zuweisung(tempBruch);
            UI.BruchEinlesen(ref tempBruch);
            this.bruch2.Zuweisung(tempBruch);
            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Subtrahieren(this.bruch2));
            //3. Ergebnis anzeigen
            this.UI.TextAusgeben("Das Ergebnis lautet:");
            this.UI.BruchAusgeben(ergebnis);
        }

        //Geschäftsprozesse
        private void BruecheAddieren()
        {
            Bruch tempBruch = new Bruch();
            //1. Brueche einlesen UserInterface
            UI.BruchEinlesen(ref tempBruch);
            this.bruch1.Zuweisung(tempBruch);
            UI.BruchEinlesen(ref tempBruch);
            this.bruch2.Zuweisung(tempBruch);
            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Addieren(this.bruch2));
            //3. Ergebnis anzeigen
            this.UI.TextAusgeben("Das Ergebnis lautet:");
            this.UI.BruchAusgeben(ergebnis);
        }
        #endregion
    }
}
