using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_UT_ConsolidationAbonnes
{
    public class Abonne
    {
        public int AbonneId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Actif { get; set; }


        public override int GetHashCode()
        {
            return HashCode.Combine(this.AbonneId, this.Nom, this.Prenom);
        }
        public override bool Equals(object? p_obj)
        {
            if (p_obj == null || !(p_obj is Abonne))
            {
                return false;
            }
            return this.GetHashCode() == p_obj.GetHashCode();
        }

    }
}
