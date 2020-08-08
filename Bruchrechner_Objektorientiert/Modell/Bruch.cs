// Name:            Fabula
// Datum:           23.09.2019
// Dateiname:       Bruch.cs
// Beschreibung:    Bruch Klasse für Rechnungen mit Brüchen
// Aenderungen:     08.08.2020, Meyer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechner_Objektorientiert
{
    class Bruch
    {
        #region Eigenschaften
        private int _zaehler;
        private int _nenner;
        private char _vorzeichen;
        #endregion

        #region Accessoren/Modifier

        public int Nenner
        {
            get => _nenner;
            set
            {
                if (value == 0)
                {
                    throw (new Exception("Nenner darf nicht Null sein!"));
                }
                else if(value < 0)
                {
                    if(Zaehler > 0)
                    {
                        Vorzeichen = '-';
                    }
                    else
                    {
                        Vorzeichen = '+';                        
                    }
                    _nenner = value;
                }
                else
                {
                    if (Zaehler > 0)
                    {
                        Vorzeichen = '+';
                    }
                    else
                    {
                        Vorzeichen = '-';
                    }
                    _nenner = value;
                }
            }
        }
        public char Vorzeichen { get => _vorzeichen; set => _vorzeichen = value; }
        public int Zaehler { get => _zaehler; set => _zaehler = value; }
        #endregion

        #region Konstruktoren
        // Standard Konstruktor
        public Bruch()
        {
            this.Zaehler = 1;
            this.Nenner = 1;
        }
        // Spezial Konstruktor
        public Bruch(int zaehler, int nenner)
        {
            this.Zaehler = zaehler;
            this.Nenner = nenner;
            this.Kuerzen();
        }

        public Bruch(Bruch value)
        {
            this.Zaehler = value.Zaehler;
            this.Nenner = value.Nenner;
            this.Vorzeichen = value.Vorzeichen;
        }
        #endregion

        #region Worker
        public void Zuweisung(Bruch bruch)
        {
            this.Zaehler = bruch.Zaehler;
            this.Nenner = bruch.Nenner;
            this.Vorzeichen = bruch.Vorzeichen;
        }
        public Bruch Addieren(Bruch bruch2)
        {
            int zaehl = 0;
            int nenn = 1;
            Bruch ergebnis = null;

            zaehl = this.Zaehler * bruch2.Nenner + bruch2.Zaehler * this.Nenner;
            nenn = this.Nenner * bruch2.Nenner;

            try
            {
                ergebnis = new Bruch(zaehl, nenn);
            }
            catch (Exception ex)
            {
                ergebnis = new Bruch(zaehl, 1);
            }

            return ergebnis; 
        } 
        public Bruch Subtrahieren(Bruch bruch2)
        {
            int zaehl = 0;
            int nenn = 1;
            Bruch ergebnis = null;

            zaehl = this.Zaehler * bruch2.Nenner - bruch2.Zaehler * this.Nenner;
            nenn = this.Nenner * bruch2.Nenner;
            try
            {
                ergebnis = new Bruch(zaehl, nenn);
            }
            catch (Exception ex)
            {
                ergebnis = new Bruch(zaehl, 1);
            }

            return ergebnis;
        }
        public Bruch Multiplizieren(Bruch bruch2)
        {
            int zaehl = 0;
            int nenn = 1;
            Bruch ergebnis = null;

            zaehl = this.Zaehler * bruch2.Zaehler;
            nenn = this.Nenner * bruch2.Nenner;

            try
            {
                ergebnis = new Bruch(zaehl, nenn);
            }
            catch (Exception ex)
            {
                ergebnis = new Bruch(zaehl, 1);
            }

            return ergebnis;
        }
        public Bruch Dividieren(Bruch bruch2)
        {
            int zaehl = 0;
            int nenn = 1;
            Bruch ergebnis=null;

            zaehl = this.Zaehler * bruch2.Nenner;
            nenn = bruch2.Zaehler * this.Nenner;
            try
            {
              ergebnis = new Bruch(zaehl, nenn);
            }
            catch(Exception ex)
            {
              ergebnis = new Bruch(zaehl, 1);
            }
            return ergebnis;
        }
        private void Kuerzen()
        {
            int tmpz = this.Zaehler;
            int tmpn = this.Nenner;

            if (tmpz != 0)
            {
                int rest;
                int ggt = Math.Abs(tmpz);
                int divisor = Math.Abs(tmpn);

                do
                {
                    rest = ggt % divisor;
                    ggt = divisor;
                    divisor = rest;
                } while (rest > 0);

                tmpz = tmpz / ggt;
                tmpn = tmpn / ggt;
            }
            else
            {
                //nichts
            }
            char tempvorzeichen = this.Vorzeichen;
            this.Zaehler = tmpz;
            this.Nenner = tmpn;
            this.Vorzeichen = tempvorzeichen;
        }
        #endregion
    }
}
