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
    public class PieceTests
    {
        [TestMethod()]
        public void GetNumSerieTest()
        {
            Piece p = new Piece(125, "Anémomètre", 1250);
            Assert.AreEqual(125, p.GetNumSerie());
        }

        [TestMethod()]
        public void ObtenirInfosTest()
        {
            Piece p = new Piece(125, "Anémomètre", 1250);
            string expected = "125 - Anémomètre";
            Assert.AreEqual(expected, p.ObtenirInfos());
        }
    }
}