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
            foreach (Abonne s in this.m_depotSource.ObtenirAbonnes())
            {
                bool abonneTrouve = false;
                
                foreach (Abonne d in this.m_depotDestination.ObtenirAbonnes())
                {
                    if (s.AbonneId == d.AbonneId)
                    {
                        abonneTrouve = true;
                        if (s.Prenom != d.Prenom)
                        {
                            this.m_depotDestination.MettreAjourAbonne(d);
                        }                       
                    }
                }
                
                if (!abonneTrouve)
                {
                    this.m_depotDestination.AjouterAbonne(s);
                }
            
            }
            foreach (Abonne d in this.m_depotDestination.ObtenirAbonnes())
            {
                if (!this.m_depotSource.ObtenirAbonnes().Any())
                {
                    this.m_depotDestination.DesactiverAbonne(d.AbonneId);
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
