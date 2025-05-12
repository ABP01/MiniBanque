using MiniBanque.Models;

namespace MiniBanque.Services
{
    public class BanqueServices
    {
        private List<Client> clients=new();
        private List<Compte> comptes = new();

        private void AjouterClient(Client c)=> clients.Add(c);

        private void SupprimerClient(int id)
        {
            comptes.RemoveAll(c => c.ClientId==id);
            clients.RemoveAll(c => c.NumClient == id);
        }

        public Client RechercherClient(int id)=> clients.FirstOrDefault(c => c.NumClient == id);

        public List<Client> RechercherClientParNom(string DebutNom) =>
            clients.Where(c => c.Nom.StartsWith(DebutNom)).ToList();
        public void AjouterCompte(Compte c)=>comptes.Add(c);
        public void SupprimerCompte(int id)
        {
            comptes.RemoveAll(c => c.NumCompte == id);
        }

        public Compte RechercherCompte(int id) => comptes.FirstOrDefault(c => c.NumCompte == id);

        public List<Compte> ObtenirCompteParClient(int clientId) =>
            comptes.Where(c => c.ClientId == clientId).ToList();

        public bool Virement(int sourceId, int destinationId, decimal montant)
        {
            var src= RechercherCompte(sourceId);
            var dest = RechercherCompte(destinationId);
            if (src != null && dest != null && src.Debit(montant))
            {
                dest.Debit(montant);
                return true;
            }
            return false;
        }


    }

    
}
