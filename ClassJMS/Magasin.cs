using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJMS
{
    public class Magasin
    {
        #region attributs privés
        private List<Piece> lesPieces;  // ensemble des pièces du magasin
        #endregion

        #region constructeur
        public Magasin()
        {
            this.lesPieces = new List<Piece>();
        }
        #endregion

        #region méthodes
        public bool AjouterPiece(Piece unePiece)
        {
            bool ajout = true;
            foreach (Piece p in this.lesPieces)
                if (p.GetNumSerie() == unePiece.GetNumSerie())
                    ajout = false;
            if (ajout)
                this.lesPieces.Add(unePiece);
            return ajout;
        }

        public void AfficherMagasin()
        {
            foreach (Piece p in this.lesPieces)
                Console.WriteLine("\n" + p.ObtenirInfos() + "\n------------------------------------");
        }

        public double ObtenirTauxPNA()
        {
            double nbPNA = 0;
            foreach (Piece p in this.lesPieces)
            {
                if (p is PieceNonAgreee)
                    nbPNA++;
            }
            return nbPNA * 100 / (double)this.lesPieces.Count;
        }

        public List<Piece> ControlerPieces()
        {
            List<Piece> lesPiecesAControler = new List<Piece>();
            foreach (Piece p in this.lesPieces)
            {
                if (p.AControler())
                    lesPiecesAControler.Add(p);
            }
            return lesPiecesAControler;
        }

        // pour les tests unitaires
        public List<Piece> GetLesPieces()
        {
            return this.lesPieces;
        }

        public void SetLesPieces(List<Piece> lesPieces)
        {
            this.lesPieces = lesPieces;
        }

        #endregion
    }
}
