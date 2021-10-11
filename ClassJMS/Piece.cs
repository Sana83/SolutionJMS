using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJMS
{
    public class Piece
    {
        #region attributs privés
        private int numSerie;       // numéro de série
        private string libelle;     // libellé de la pièce
        protected int nbHeures;     // nombre d'heures de fonctionnement
        #endregion

        #region constructeur
        public Piece(int unNumero, string unLibelle, int unNombre)
        {
            this.numSerie = unNumero;
            this.libelle = unLibelle;
            this.nbHeures = unNombre;
        }
        #endregion

        #region méthodes
        public int GetNumSerie()
        {
            return this.numSerie;
        }

        public virtual string ObtenirInfos()
        {
            return this.numSerie + " - " + this.libelle;
        }

        public virtual bool AControler()
        {
            return false;
        }
        #endregion
    }
}
