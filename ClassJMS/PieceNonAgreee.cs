using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJMS
{
    public class PieceNonAgreee : Piece
    {
        #region attributs privés
        private string etat;  // état de la pièce - VERT, ORANGE ou ROUGE
        private int seuil;    // nombre d'heures minimal qui déclenche un contrôle de la pièce
        #endregion

        #region constructeur
        public PieceNonAgreee(int unNumero, string unLibelle, int unNombre, int unSeuil)
            : base(unNumero, unLibelle, unNombre)
        {
            this.etat = "VERT";
            this.seuil = unSeuil;
        }
        #endregion

        #region méthodes
        public override string ObtenirInfos()
        {
            string res = base.ObtenirInfos();
            res += "\nEtat : " + this.etat;
            return res;
        }
       
        public string GetEtat()
        {
            return this.etat;
        }
        public void ChangerEtat(string unEtat)
        {
            this.etat = unEtat.ToUpper();
        }

        public override bool AControler()
        {
            bool controleOK = false;
            if (this.etat == "VERT" && base.nbHeures >= this.seuil)
            {
                controleOK = true;
                this.etat = "ORANGE";
            }
            return controleOK;
        }
        #endregion
    }
}
