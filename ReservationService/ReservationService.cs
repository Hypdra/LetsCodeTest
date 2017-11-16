using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.IO;

namespace ReservationService
{    
    public class ReservationService : IOReservationService
    {
        public ReservationDetailsContract ReserveRoom(ReservationDetailsContract reservacja)
        {

            var path = Path.Combine(@"Sala.xml");

            try
            {   
                /*
                XDocument doc = XDocument.Load(@"C:\Users\Sii\LetsCodeTest\ReservationService\Sala.xml");
                XDocument doc = XDocument.Load(@"Sala.xml");
                doc.Element("Sala").Add(
                        new XElement("Rezerwacja",
                        new XElement("Start", reservacja.StartDate),
                        new XElement("Stop", reservacja.StopDate)));

                doc.Save(@"C:\Users\Sii\LetsCodeTest\ReservationService\Sala.xml");
                */
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }
            reservacja.NumberOfPeoples = reservacja.NumberOfPeoples + "0";
            return reservacja;
        }
    }
}
