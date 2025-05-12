using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBanque.Models
{
    public class PEL : Compte
    {
        public double TauxRemuneration { get; set; }

        public override bool Debit(decimal montant)
        {
            if ((DateTime.Now - DateOuverture).TotalDays >= 365 * 5)
            {
                return base.Debit(montant);
            }
            return false;
        }
        public void AjouterInteret()
        {
            var Interet = Solde * (decimal)(TauxRemuneration / 100);
            Credit(Interet);
        }

    }
}