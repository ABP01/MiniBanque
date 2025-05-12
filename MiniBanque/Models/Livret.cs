using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniBanque.Models
{
    public class Livret : Compte
    {
        public double TauxRemuneration { get; set; }

        public void AjouterInteret() {
            var Interet = Solde * (decimal)(TauxRemuneration / 100);
            Credit(Interet);
        }
        public override bool Debit(decimal montant) => false;



    }
}