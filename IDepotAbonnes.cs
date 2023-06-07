using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_UT_ConsolidationAbonnes
{
    public interface IDepotAbonnes
    {
       
        void AjouterAbonne(Abonne p_abonne);
        IEnumerable<Abonne> ObtenirAbonnes();
        Abonne ObtenirAbonne(int AbonneId);
        void MettreAjourAbonne(Abonne p_abonne);
        void DesactiverAbonne(int p_abonneId);
    }
}
