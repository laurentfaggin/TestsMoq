using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_UT_ConsolidationAbonnes
{
     public interface IDepotImportationAbonnes
     {
        IEnumerable<Abonne> ObtenirAbonnes();
    }
}
