using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJMS
{
    public class PieceAgreee : Piece
    {
        #region attributs privés
        private DateTime dateAgrement;      // date du dernier agrément de la pièce
        private string nomConstructeur;     // nom du constructeur de la pièce
        #endregion

        #region constructeur
        public PieceAgreee(int unNumero, string unLibelle, int unNombre, DateTime uneDate, string unConstructeur)
            : base(unNumero, unLibelle, unNombre)
        {
            this.dateAgrement = uneDate;
            this.nomConstructeur = unConstructeur;
        }
        #endregion

        #region méthodes
        public override string ObtenirInfos()
        {
            string res = base.ObtenirInfos();
            res += "\nConstructeur : " + this.nomConstructeur;
            res += "\nDate Agrément : " + this.dateAgrement.ToShortDateString(); //au format JJ/MM/AAAA
            return res;
        }

         
        public int CalculerDureeAgrement()
        {
            return DateTime.Now.Year - this.dateAgrement.Year;
        }

               
        public void RenouvelerAgrement(DateTime uneDate)
        {
            this.dateAgrement = uneDate;
        }

        public override bool AControler()
        {
            if (this.CalculerDureeAgrement() > 2)
                return true;
            else
                return false;
        }

        // pour les tests unitaires
        public DateTime GetDateAgrement()
        {
            return this.dateAgrement;
        }
        #endregion
    }
}
