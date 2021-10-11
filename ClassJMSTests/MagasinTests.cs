using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassJMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJMS.Tests
{
    [TestClass()]
    public class MagasinTests
    {
        
        [TestMethod()]
        public void AjouterPieceTest()
        {
            // Instanciation d'un magasin et de 3 pièces
            Magasin m = new Magasin();
            Piece p1 = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            Piece p2 = new PieceAgreee(477, "Truc", 4500, DateTime.Parse("01/05/2014"), "ZZZ");
            Piece p3 = new PieceNonAgreee(477, "Courroie", 3250, 3000);
            // Etat 0 : Aucune pièce dans le magasin
            Assert.AreEqual(0, m.GetLesPieces().Count);
            // Etat 1 : Ajout d'une pièce au magasin
            Assert.AreEqual(true, m.AjouterPiece(p1));
            Assert.AreEqual(1, m.GetLesPieces().Count);
            // Etat 2 : Ajout d'une autre pièce au magasin avec un numéro de série différent
            Assert.AreEqual(true, m.AjouterPiece(p2));
            Assert.AreEqual(2, m.GetLesPieces().Count);
            // Etat 3 : Ajout d'une pièce déjà présente au magasin avec le même numéro de série
            Assert.AreEqual(false, m.AjouterPiece(p3));
            Assert.AreEqual(2, m.GetLesPieces().Count);
        }

        [TestMethod()]
        public void ObtenirTauxPNATest()
        {
            // Etape 1 : Instanciation d'un magasin, de 5 pièces agréées et de 3 pièces non agréées
            Magasin m = new Magasin();
            Piece p1 = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            Piece p2 = new PieceAgreee(477, "Truc", 4500, DateTime.Parse("01/05/2014"), "ZZZ");
            Piece p3 = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            Piece p4 = new PieceAgreee(478, "Autre2 ", 3000, DateTime.Parse("15/02/2020"), "FFF");
            Piece p5 = new PieceAgreee(479, "Autre3 ", 3000, DateTime.Parse("15/02/2020"), "FFF");
            Piece p6 = new PieceAgreee(480, "Autre4 ", 3000, DateTime.Parse("15/02/2004"), "FFF");
            Piece p7 = new PieceNonAgreee(276, "Machin1", 3250, 4000);
            Piece p8 = new PieceNonAgreee(277, "Machin2", 1500, 4000);

            // Etape 2 : Ajout des pièces au magasin - utilisation de la méthode SetLesPieces 
            List<Piece> lesPieces = new List<Piece>() {p1, p2, p3, p4, p5, p6, p7, p8 };
            m.SetLesPieces(lesPieces);

            // Etape 3 : Vérification du taux de pièces non agréées
            Assert.AreEqual(37.5, m.ObtenirTauxPNA());
        }

        [TestMethod()]
        public void ControlerPiecesTest()
        {
            // Etape 1 : Instanciation d'un magasin,
            // de 5 pièces agréées (dont 3 ont un agrément de plus de 2 ans)
            // et de 3 pièces non agréées (dont une a dépassé le nombre d'heures d'utilisation)
            Magasin m = new Magasin();
            Piece p1 = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            Piece p2 = new PieceAgreee(477, "Truc", 4500, DateTime.Parse("01/05/2014"), "ZZZ");
            Piece p3 = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            Piece p4 = new PieceAgreee(478, "Autre2 ", 3000, DateTime.Parse("15/02/2020"), "FFF");
            Piece p5 = new PieceAgreee(479, "Autre3 ", 3000, DateTime.Parse("15/02/2020"), "FFF");
            Piece p6 = new PieceAgreee(480, "Autre4 ", 3000, DateTime.Parse("15/02/2004"), "FFF");
            Piece p7 = new PieceNonAgreee(276, "Machin1", 3250, 4000);
            Piece p8 = new PieceNonAgreee(277, "Machin2", 1500, 4000);

            // Etape 2 : Ajout des pièces au magasin - utilisation de la méthode SetLesPieces 
            List<Piece> lesPieces = new List<Piece> { p1, p2, p3, p4, p5, p6, p7, p8 };
            m.SetLesPieces(lesPieces);

            // Etape 3 : Vérification du nombre de pièces à contrôler et du contenu de la liste des pièces à contrôler {p1, p2, p3, p6}
            List<Piece> actual = m.ControlerPieces();
            Assert.AreEqual(4, actual.Count);
            List<Piece> expected = new List<Piece> { p1, p2, p3, p6 };
            CollectionAssert.AreEqual(expected, actual);
        }

        
    }
}