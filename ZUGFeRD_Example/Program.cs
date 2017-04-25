using DevExpress.XtraPrinting;
using s2industries.ZUGFeRD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ZUGFeRD_Example
{
   class Program
   {
      static void Main(string[] args)
      {
         var report = new Rechnung();
         report.XmlDataPath = CreateXML();

         string additionalMetadata = CreateDocumentInfo() + CreatePdfASchema();

         PdfExportOptions options = new PdfExportOptions()
         {
            PdfACompatibility = PdfACompatibility.PdfA3b,
            AdditionalMetadata = additionalMetadata
         };

         options.Attachments.Add(new PdfAttachment()
         {
            FilePath = report.XmlDataPath,
            Type = "text/xml",
            Description = "Rechnungsdaten im ZUGFeRD-XML-Format",
         });
         report.ExportToPdf("Rechnung.pdf", options);
         Process.Start("Rechnung.pdf");
      }

      static internal string CreateXML()
      {
         Klassen.Rechnung ar = CreateDemoData.Rechnung();

         List<Klassen.RechnungPosten> arPosten = CreateDemoData.RechnungPosten();

         InvoiceDescriptor desc = InvoiceDescriptor.CreateInvoice(ar.Nummer, ar.Datum, CurrencyCodes.EUR, ar.BestellNr);
         desc.Profile = Profile.Basic;
         desc.AddNote(ar.Beschreibung);

         StringBuilder lieferantNote = new StringBuilder();
         lieferantNote.AppendLine("Lieferant GmbH");
         lieferantNote.AppendLine("Lieferantenstraße 20");
         lieferantNote.AppendLine("80333 München");
         lieferantNote.AppendLine("Deutschland");
         lieferantNote.AppendLine("Geschäftsführer: Hans Muster");
         lieferantNote.AppendLine("Handelsregisternummer: H A 123");
         desc.AddNote(lieferantNote.ToString());

         desc.AddNote(ar.Skontotext);

         desc.SetSeller("Lieferant GmbH",
                        "80333",
                        "München",
                        "Lieferantenstraße 20",
                        CountryCodes.DE,
                        "");
         desc.AddSellerTaxRegistration("DE123456789", TaxRegistrationSchemeID.VA);

         desc.SetBuyer(name: (ar.Name1 + " " + ar.Name2).Trim(),
                       postcode: ar.PLZ,
                       city: ar.Ort,
                       street: ar.Strasse,
                       country: CountryCodes.DE,
                       id: null,
                       receiver: ar.Ansprechpartner);

         desc.ActualDeliveryDate = ar.Datum;

         //Zahlart   
         switch (ar.ZahlArt)
         {
            case "E":
            case "A":
               //SEPA
               Klassen.Einrichtung en = CreateDemoData.Einrichtung();

               desc.setPaymentMeans(PaymentMeansTypeCodes.PaymentMeans_49,
                                    information: "Betrag wird per SEPA-Lastschrift eingezogen",
                                    identifikationsnummer: "DE98ZZZ09999999999",
                                    mandatsnummer: en.Mandatsnummer);
               desc.SetTradePaymentTerms($"Der zu zahlende Gesamtbetrag von {ar.Bruttobetrag.ToString("N2")} Euro wird frühestens am {ar.Datum.AddDays(ar.Nettotage).ToShortDateString()} von der Bankverbindung {en.IBAN} per Lastschrift unter Bezug auf die Mandatsreferenz {en.Mandatsnummer} mit der Gläubiger-Identifikationsnummer DE98ZZZ09999999999 eingezogen.",
                                          ar.Datum.AddDays(ar.Nettotage));
               desc.addDebitorFinancialAccount(en.IBAN, en.BIC);    
               break;
            case "K":
            default: //Überweisung
               desc.addCreditorFinancialAccount("DE08700901001234567890", "GENODEF1M04");
               break;
         }

         //Mwst 
         foreach (var mwst in arPosten.Where(x => x.Art == "MWST"))
         {
            desc.AddApplicableTradeTax(mwst.Gesamtpreis, mwst.MwSt, TaxTypes.VAT, TaxCategoryCodes.S);
         }

         //Gesamt
         desc.SetTotals(lineTotalAmount: ar.Nettobetrag,
                        chargeTotalAmount: 0.00m,
                        allowanceTotalAmount: 0.00m,
                        taxBasisAmount: ar.Nettobetrag,
                        taxTotalAmount: ar.USTBetrag,
                        grandTotalAmount: ar.Bruttobetrag);

         //Posten 
         foreach (var posten in arPosten.Where(x => string.IsNullOrEmpty(x.Art)))
         {
            desc.addTradeLineItem(name: posten.Bezeichnung,
                                 unitCode: QuantityCodes.C62,
                                 grossUnitPrice: posten.Einzelpreis,
                                 netUnitPrice: posten.Einzelpreis,
                                 billedQuantity: posten.Anzahl,
                                 taxType: TaxTypes.VAT,
                                 categoryCode: TaxCategoryCodes.S,
                                 taxPercent: posten.MwSt,
                                 id: new GlobalID(GlobalID.SchemeID_EAN, ""),
                                 sellerAssignedID: posten.Artikelnummer);
         }

         string filename = Path.GetTempPath() + @"\ZUGFeRD-invoice.xml";

         desc.Save(filename);

         return filename;
      }

      static internal string CreateDocumentInfo()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine("<rdf:Description xmlns:pdfaExtension=\"http://www.aiim.org/pdfa/ns/extension/\" xmlns:pdfaProperty=\"http://www.aiim.org/pdfa/ns/property#\" xmlns:pdfaSchema=\"http://www.aiim.org/pdfa/ns/schema#\" rdf:about=\"\">");
         sb.AppendLine("<pdfaExtension:schemas>");
         sb.AppendLine("<rdf:Bag>");
         sb.AppendLine("<rdf:li rdf:parseType=\"Resource\">");
         sb.AppendLine("<pdfaSchema:schema>ZUGFeRD PDFA Extension Schema</pdfaSchema:schema>");
         sb.AppendLine("<pdfaSchema:namespaceURI>urn:ferd:pdfa:invoice:rc#</pdfaSchema:namespaceURI>");
         sb.AppendLine("<pdfaSchema:prefix>zf</pdfaSchema:prefix>");
         sb.AppendLine("<pdfaSchema:property>");
         sb.AppendLine("<rdf:Seq>");
         sb.AppendLine("<rdf:li rdf:parseType=\"Resource\">");
         sb.AppendLine("<pdfaProperty:name>DocumentFileName</pdfaProperty:name>");
         sb.AppendLine("<pdfaProperty:valueType>Text</pdfaProperty:valueType>");
         sb.AppendLine("<pdfaProperty:category>external</pdfaProperty:category>");
         sb.AppendLine("<pdfaProperty:description>The name of the embedded Zugferd XML invoice file</pdfaProperty:description>");
         sb.AppendLine("</rdf:li>");
         sb.AppendLine("<rdf:li rdf:parseType=\"Resource\">");
         sb.AppendLine("<pdfaProperty:name>DocumentType</pdfaProperty:name>");
         sb.AppendLine("<pdfaProperty:valueType>Text</pdfaProperty:valueType>");
         sb.AppendLine("<pdfaProperty:category>external</pdfaProperty:category>");
         sb.AppendLine("<pdfaProperty:description>INVOICE</pdfaProperty:description>");
         sb.AppendLine("</rdf:li>");
         sb.AppendLine("<rdf:li rdf:parseType=\"Resource\">");
         sb.AppendLine("<pdfaProperty:name>Version</pdfaProperty:name>");
         sb.AppendLine("<pdfaProperty:valueType>Text</pdfaProperty:valueType>");
         sb.AppendLine("<pdfaProperty:category>external</pdfaProperty:category>");
         sb.AppendLine("<pdfaProperty:description>The version of the ZUGFeRD data</pdfaProperty:description>");
         sb.AppendLine("</rdf:li>");
         sb.AppendLine("<rdf:li rdf:parseType=\"Resource\">");
         sb.AppendLine("<pdfaProperty:name>ConformanceLevel</pdfaProperty:name>");
         sb.AppendLine("<pdfaProperty:valueType>Text</pdfaProperty:valueType>");
         sb.AppendLine("<pdfaProperty:category>external</pdfaProperty:category>");
         sb.AppendLine("<pdfaProperty:description>The conformance level of the ZUGFeRD data, i.e. BASIC or EXTENDED</pdfaProperty:description>");
         sb.AppendLine("</rdf:li>");
         sb.AppendLine("</rdf:Seq>");
         sb.AppendLine("</pdfaSchema:property>");
         sb.AppendLine("</rdf:li>");
         sb.AppendLine("</rdf:Bag>");
         sb.AppendLine("</pdfaExtension:schemas>");
         sb.AppendLine("</rdf:Description>");

         return sb.ToString();
      }

      static internal string CreatePdfASchema()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine("<rdf:Description xmlns:zf=\"urn: ferd:pdfa: invoice:1p0#\" rdf:about=\"\">");
         sb.AppendLine("<zf:DocumentType>INVOICE</zf:DocumentType>");
         sb.AppendLine("<zf:DocumentFileName>ZUGFeRD-invoice.xml</zf:DocumentFileName>");
         sb.AppendLine("<zf:Version>1.0</zf:Version>");
         sb.AppendLine("<zf:ConformanceLevel>BASIC</zf:ConformanceLevel>");
         sb.AppendLine("</rdf:Description>");

         return sb.ToString();
      }

      public class CreateDemoData
      {
         static public Klassen.Einrichtung Einrichtung()
         {
            Klassen.Einrichtung einrichtung = new Klassen.Einrichtung()
            {
               BIC = "MARKDEF1860",
               IBAN = "DE21860000000086001055",
               Mandatsnummer = "REF A-123"
            };
            return einrichtung;
         }

         static public Klassen.Rechnung Rechnung()
         {
            Klassen.Rechnung rechnung = new Klassen.Rechnung()
            {
               Ansprechpartner = "Hans Muster",
               Beschreibung = "Rechnung gemäß Bestellung vom 01.03.2013.",
               BestellNr = "2013-471102",
               Bruttobetrag = 529.87m,
               Datum = new DateTime(2013, 3, 5),
               GLN = 4000001987658,
               Kundennummer = "GE2020211",
               Name1 = "Kunden AG",
               Name2 = "Mitte",
               Nettobetrag = 473.00m,
               Nettotage = 30,
               Nummer = "471102",
               Ort = "Frankfurt",
               PLZ = "69876",
               Skontotext = "Zahlbar innerhalb 30 Tagen netto bis 04.04.2013.",
               Strasse = "Kundenstraße 15",
               USTBetrag = 56.87m,
               ZahlArt = "E"
            };

            return rechnung;
         }

         static public List<Klassen.RechnungPosten> RechnungPosten()
         {
            List<Klassen.RechnungPosten> rechnungposten = new List<Klassen.RechnungPosten>();

            rechnungposten.Add(new Klassen.RechnungPosten()
            {
               Anzahl = 20m,
               Art = "",
               Artikelnummer = "TB100A4",
               Bezeichnung = "Trennblätter A4",
               Einzelpreis = 9.90m,
               Gesamtpreis = 198.00m,
               MwSt = 19.00m,
               MwStBetrag = 37.62m
            });

            rechnungposten.Add(new Klassen.RechnungPosten()
            {
               Anzahl = 50m,
               Art = "",
               Artikelnummer = "ARNR2",
               Bezeichnung = "Joghurt Banane",
               Einzelpreis = 5.50m,
               Gesamtpreis = 275.0m,
               MwSt = 7.00m,
               MwStBetrag = 19.25m
            });

            rechnungposten.Add(new Klassen.RechnungPosten()
            {
               Anzahl = 0,
               Art = "MWST",
               Artikelnummer = "MWST",
               Bezeichnung = "",
               Einzelpreis = 0,
               Gesamtpreis = 198.00m,
               MwSt = 19.00m,
               MwStBetrag = 37.62m
            });

            rechnungposten.Add(new Klassen.RechnungPosten()
            {
               Anzahl = 0,
               Art = "MWST",
               Artikelnummer = "MWST",
               Bezeichnung = "",
               Einzelpreis = 0,
               Gesamtpreis = 275.0m,
               MwSt = 7.00m,
               MwStBetrag = 19.25m
            });

            return rechnungposten;
         }
      }
   }
}
