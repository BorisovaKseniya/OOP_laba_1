
namespace Chisla.Tests { 


    [TestClass]
    public class ChislaTests
    {
      
        [DataTestMethod]
        [DataRow(10, 2, 10, 2, 1, 1, 1)]
        [DataRow(10, 2, 2, 10, 25, 1, 1)]
        [DataRow(12, 3, 7, 8, 4, 4, 7)]


        public void division(int a1, int a2, int b1, int b2, int r1, int r2, int r3)
        {
            Chislo UserChislo1 = new Chislo(a1,a2); 
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 / UserChislo2;
            Actual = Chislo.sokrashenie(Actual);

            Assert.AreEqual(r1, Actual.Int_part);
            Assert.AreEqual(r2, Actual.Num);
            Assert.AreEqual(r3, Actual.Den);   
        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, 25, 1, 1)]
        [DataRow(10, 2, 2, 10, 1, 1, 1)]
        [DataRow(12, 3, 7, 8, 3, 1, 2)]
        public void multiplication(int a1, int a2, int b1, int b2, int r1, int r2, int r3)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 * UserChislo2;
            Actual = Chislo.sokrashenie(Actual);

            Assert.AreEqual(r1, Actual.Int_part);
            Assert.AreEqual(r2, Actual.Num);
            Assert.AreEqual(r3, Actual.Den);
        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, 10, 1, 1)]
        [DataRow(10, 2, 2, 10, 5, 1, 5)]
        [DataRow(12, 3, 7, 8, 4, 7, 8)]
        public void addition(int a1, int a2, int b1, int b2, int r1, int r2, int r3)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 + UserChislo2;
            Actual = Chislo.sokrashenie(Actual);

            Assert.AreEqual(r1, Actual.Int_part);
            Assert.AreEqual(r2, Actual.Num);
            Assert.AreEqual(r3, Actual.Den);
        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, 0, 0, 0)]  // тут что-то не так
        [DataRow(10, 2, 2, 10, 4, 4, 5)]
        [DataRow(12, 3, 7, 8, 3, 1, 8)]

        public void subtraction(int a1, int a2, int b1, int b2, int r1, int r2, int r3)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 - UserChislo2;
            Actual = Chislo.sokrashenie(Actual);

            Assert.AreEqual(r1, Actual.Int_part);
            Assert.AreEqual(r2, Actual.Num);
            Assert.AreEqual(r3, Actual.Den);
        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, true)]
        [DataRow(10, 2, 2, 10, false)]
        [DataRow(12, 3, 7, 8, false)]
        public void ravnoravno(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 == UserChislo2;


            Assert.AreEqual(r1, Actual);

        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, false)]
        [DataRow(10, 2, 2, 10, true)]
        [DataRow(12, 3, 7, 8, true)]
        public void ravnoneravno(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 != UserChislo2;


            Assert.AreEqual(r1, Actual);

        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, true)]
        [DataRow(10, 2, 2, 10, true)]
        [DataRow(12, 3, 7, 8, true)]
        public void ravnobolshe(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 >= UserChislo2;


            Assert.AreEqual(r1, Actual);

        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, false)]   // да что ж такое
        [DataRow(10, 2, 2, 10, false)]
        [DataRow(12, 3, 7, 8, false)]
        public void ravnomenshe(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 <= UserChislo2;


            Assert.AreEqual(r1, Actual);

        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, false)]  
        [DataRow(10, 2, 2, 10, false)]
        [DataRow(12, 3, 7, 8, false)]
        public void menshe(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 < UserChislo2;


            Assert.AreEqual(r1, Actual);

        }

        [TestMethod]
        [DataRow(10, 2, 10, 2, false)]
        [DataRow(10, 2, 2, 10, true)]     // и снова треш
        [DataRow(12, 3, 7, 8, true)]
        public void bolshe(int a1, int a2, int b1, int b2, bool r1)
        {
            Chislo UserChislo1 = new Chislo(a1, a2);
            Chislo UserChislo2 = new Chislo(b1, b2);

            var Actual = UserChislo1 < UserChislo2;


            Assert.AreEqual(r1, Actual);

        }










    }
}
