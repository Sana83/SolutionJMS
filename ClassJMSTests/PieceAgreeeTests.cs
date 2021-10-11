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
    public class PieceAgreeeTests
    {
        [TestMethod()]
        public void ObtenirInfosTest()
        {
            PieceAgreee p = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            string expected = "125 - Anémomètre\nConstructeur : ZZZ\nDate Agrément : 12/03/2012";
            Assert.AreEqual(expected, p.ObtenirInfos());
        }

        [TestMethod()]
        public void CalculerDureeAgrementTest()
        {
            PieceAgreee p = new PieceAgreee(125, "Anémomètre", 1250, new DateTime(2012, 03, 12), "ZZZ");
            Assert.AreEqual(DateTime.Now.Year - 2012, p.CalculerDureeAgrement());
        }


        [TestMethod()]
        public void RenouvelerAgrementTest()
        {
            PieceAgreee p = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            Assert.AreEqual(new DateTime(2012, 03, 12), p.GetDateAgrement());
            p.RenouvelerAgrement(new DateTime(2015, 10, 25));
            Assert.AreEqual(new DateTime(2015, 10, 25), p.GetDateAgrement());
        }

        [TestMethod()]
        public void AControlerTest()
        {
            // Cas 1 - Agrément de plus de 2 ans
            PieceAgreee p1 = new PieceAgreee(125, "Anémomètre", 1250, DateTime.Parse("12/03/2012"), "ZZZ");
            Assert.AreEqual(true, p1.AControler());
            // Cas 2 - Agrément de moins de 2 ans
            PieceAgreee p2 = new PieceAgreee(145, "Courroie", 150, DateTime.Parse("12/03/2020"), "WWW");
            Assert.AreEqual(false, p2.AControler());
        }
    }
}