using System;
using System.Collections.Generic;

namespace ZUGFeRD_Example
{
   public class Klassen
   {
      public class Ausgangsrechnung
      {
         public Einrichtung einrichtung { get; set; } = Program.CreateDemoData.Einrichtung();
         public Rechnung rechnung { get; set; } = Program.CreateDemoData.Rechnung();
         public List<RechnungPosten> posten { get; set; } = Program.CreateDemoData.RechnungPosten();
      }

      public class Einrichtung
      {
         public string Mandatsnummer { get; set; } = "";
         public string IBAN { get; set; } = "";
         public string BIC { get; set; } = "";
      }

      public class Rechnung
      {
         public string Kundennummer { get; set; } = "";
         public long GLN { get; set; } = long.MinValue;
         public string ZahlArt { get; set; } = "";
         public string Nummer { get; set; } = "";
         public DateTime Datum { get; set; } = DateTime.MinValue;
         public string Ansprechpartner { get; set; } = "";
         public string BestellNr { get; set; } = "";
         public string Beschreibung { get; set; } = "";
         public string Name1 { get; set; } = "";
         public string Name2 { get; set; } = "";
         public string Strasse { get; set; } = "";
         public string PLZ { get; set; } = "";
         public string Ort { get; set; } = "";
         public decimal Nettobetrag { get; set; } = decimal.MinValue;
         public decimal USTBetrag { get; set; } = decimal.MinValue;
         public decimal Bruttobetrag { get; set; } = decimal.MinValue;
         public int Nettotage { get; set; } = int.MaxValue;
         public string Skontotext { get; set; } = "";
      }

      public class RechnungPosten
      {
         public string Art { get; set; } = "";
         public string Artikelnummer { get; set; } = "";
         public string Bezeichnung { get; set; } = "";
         public decimal Anzahl { get; set; } = decimal.MinValue;
         public decimal Einzelpreis { get; set; } = decimal.MinValue;
         public decimal Gesamtpreis { get; set; } = decimal.MinValue;
         public decimal MwSt { get; set; } = decimal.MinValue;
         public decimal MwStBetrag { get; set; } = decimal.MinValue;
      }
   }
}
