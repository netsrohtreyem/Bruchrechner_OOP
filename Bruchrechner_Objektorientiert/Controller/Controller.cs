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
            //1. Splash anzeigen
            this.UI.splash();

            //Hauptschleife
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

        #region Geschäftsprozesse
        private void Programmbeenden()
        {
            this.UI.Programmbeenden();
        }
        private void BruecheDividieren()
        {
            //1. Brueche einlesen UserInterface
            this.UI.RechnungEinlesen(bruch1, bruch2, '/');

            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Dividieren(this.bruch2));

            //3. Ergebnis anzeigen
            this.UI.printErgebnis(this.ergebnis);
        }
        private void BruecheMultiplizieren()
        {
            //1. Brueche einlesen UserInterface
            this.UI.RechnungEinlesen(bruch1, bruch2, '*');

            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Multiplizieren(this.bruch2));

            //3. Ergebnis anzeigen
            this.UI.printErgebnis(this.ergebnis);
        }
        private void BruecheSubtrahieren()
        {
            //1. Brueche einlesen UserInterface
            this.UI.RechnungEinlesen(bruch1, bruch2, '-');

            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Subtrahieren(this.bruch2));

            //3. Ergebnis anzeigen
            this.UI.printErgebnis(this.ergebnis);
        }
        private void BruecheAddieren()
        {
            //1. Brueche einlesen UserInterface
            this.UI.RechnungEinlesen(bruch1,bruch2, '+');

            //2. Rechnung durchführen
            this.ergebnis.Zuweisung(this.bruch1.Addieren(this.bruch2));

            //3. Ergebnis anzeigen
            this.UI.printErgebnis(this.ergebnis);
        }
        #endregion
        #endregion
    }
}
