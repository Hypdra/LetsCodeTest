using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ReservationService
{
    public class Sala
    {
        public List<Rezerwacja> rezerwacje;

        public Sala()
        {
            rezerwacje = new List<Rezerwacja>();
        }
    }
}