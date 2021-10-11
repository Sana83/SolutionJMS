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
    public class PieceNonAgreeeTests
    {
        [TestMethod()]
        public void ObtenirInfosTest()
        {
            PieceNonAgreee pna = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            string expected = "274 - Courroie\nEtat : VERT";
            Assert.AreEqual(expected, pna.ObtenirInfos());
        }

        [TestMethod()]
        public void GetEtatTest()
        {
            PieceNonAgreee pna = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            Assert.AreEqual("VERT", pna.GetEtat());
        }

        [TestMethod()]
        public void ChangerEtatTest()
        {
            PieceNonAgreee pna = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            Assert.AreEqual("VERT", pna.GetEtat());
            pna.ChangerEtat("ORANGE");
            Assert.AreEqual("ORANGE", pna.GetEtat());
        }

        [TestMethod()]
        public void AControlerTest()
        {
            // Cas 1 - La piece est à contrôler car son état est vert et le seuil est dépassé
            PieceNonAgreee pna1 = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            Assert.AreEqual("VERT", pna1.GetEtat());
            Assert.AreEqual(true, pna1.AControler());
            Assert.AreEqual("ORANGE", pna1.GetEtat());
            // Cas 2 - La piece n'est pas à contrôler car le seuil n'est pas dépassé, même si son état est vert
            PieceNonAgreee pna3 = new PieceNonAgreee(274, "Courroie", 2000, 3000);
            Assert.AreEqual(false, pna3.AControler());
            Assert.AreEqual("VERT", pna3.GetEtat());
            // Cas 3 - La piece n'est pas à contrôler car son état n'est pas vert, même si le seuil est dépassé
            PieceNonAgreee pna2 = new PieceNonAgreee(274, "Courroie", 3250, 3000);
            pna2.ChangerEtat("ROUGE");
            Assert.AreEqual(false, pna2.AControler());
            Assert.AreEqual("ROUGE", pna2.GetEtat());
            
        }
    }
}