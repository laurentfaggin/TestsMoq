using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_UT_ConsolidationAbonnes
{
    public class TraitementLotsConsolidationAbonnes: IDepotImportationAbonnes, IDepotAbonnes
    {
        private IDepotImportationAbonnes m_depotSource;
        private IDepotAbonnes m_depotDestination;
        
        public TraitementLotsConsolidationAbonnes(IDepotImportationAbonnes p_depotSource, IDepotAbonnes p_depotDestination)
        {
            this.m_depotSource = p_depotSource;
            this.m_depotDestination = p_depotDestination;
        }

        public void ConsoliderDonneesDestination()
        {
            Dictionary <int, Abonne> listeAbonnesSource = new Dictionary<int, Abonne>();
            Dictionary<int, Abonne> listeAbonnesDestination = new Dictionary<int, Abonne>();

            foreach (Abonne d in this.m_depotDestination.ObtenirAbonnes())
            {
                listeAbonnesDestination.Add(d.AbonneId, d);
            }
            foreach (Abonne s in this.m_depotSource.ObtenirAbonnes())
            {
                if (!listeAbonnesDestination.ContainsKey(s.AbonneId))
                {
                    this.m_depotDestination.AjouterAbonne(s);
                }
                else 
                {
                    if (!s.Equals(listeAbonnesDestination[s.AbonneId]))
                    {
                        this.m_depotDestination.MettreAjourAbonne(s);
                    }
                }
                
                listeAbonnesSource.Add(s.AbonneId, s);
            }

            foreach (KeyValuePair<int, Abonne> s in listeAbonnesDestination)
            {
                if (!listeAbonnesSource.ContainsKey(s.Key))
                {
                    this.m_depotDestination.DesactiverAbonne(s.Value.AbonneId);
                }
            }          
        }
        public IEnumerable<Abonne> ObtenirAbonnes()
        {
            return this.ObtenirAbonnes();
        }

        public void AjouterAbonne(Abonne p_abonne)
        {
            this.AjouterAbonne(p_abonne);
        }

        public Abonne ObtenirAbonne(int p_abonneId)
        {
            return this.ObtenirAbonne(p_abonneId);
        }

        public void MettreAjourAbonne(Abonne p_abonne)
        {
            this.MettreAjourAbonne(p_abonne);
        }

        public void DesactiverAbonne(int p_abonneId)
        {
            this.DesactiverAbonne(p_abonneId);
        }
    }
}
