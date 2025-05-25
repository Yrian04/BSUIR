using PPOIS_lab1;

namespace Lab1_tests
{
    [TestClass]
    public class VectorUnitTest
    {
        //dotnet test /p:CollectCoverage=true

        [TestMethod]
        public void ConstructorTestMethod()
        {
            Vector expected = new Vector(3, 3, 3);

            Vector actual = new Vector((1, 2, 3), (4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VectorToCortegeTestMethod()
        {
            Vector v = new Vector(3, 3, 3);
            (double, double, double) expected = (3, 3, 3);

            (double, double, double) actual = v;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CortegeToVectorTestMethod()
        {
            (double, double, double) vector = (3, 3, 3);
            Vector expected = new Vector(3, 3, 3);

            Vector actual = vector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ModuleTestMethod()
        {
            Vector v = new Vector(3, 4, 0);
            double expected = 5;

            double actual = v.Module();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlusTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            Vector expected = new Vector(5, 7, 9);

            Vector actual = v1 + v2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            Vector expected = new Vector(-3, -3, -3);

            Vector actual = v1 - v2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            double expected = 32;

            double actual = v1 * v2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyNumberTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            double n = 2;
            Vector expected = new Vector(2, 4, 6);

            Vector actual = v1 * n;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CosinusTestMethod()
        {
            Vector v1 = new Vector(1, 0, 0);
            Vector v2 = new Vector(-1, 0, 0);
            double expected = -1;

            double actual = v1 ^ v2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CosinusNullTestMethod()
        {
            Vector v1 = new Vector(3,3,3);
            Vector v2 = new Vector();

            double cosinus = v1^v2;
        }

        [TestMethod]
        public void OverTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);

            Assert.IsTrue(v2 > v1);
        }

        [TestMethod]
        public void LessTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);

            Assert.IsTrue(v1 < v2);
        }

        [TestMethod]
        public void OverOrEqualTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            Vector v3 = new Vector(4, 5, 6);

            Assert.IsTrue(v2 >= v1 && v2 >= v3);
        }

        [TestMethod]
        public void LessOrEqualTestMethod()
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            Vector v3 = new Vector(4, 5, 6);

            Assert.IsTrue(v1 <= v2 && v2 <= v3);
        }

        [TestMethod]
        public void EqualTestMethod()
        {
            Vector v1 = new Vector();
            Vector v2 = new Vector();

            Assert.IsTrue(v1 == v2);
        }

        public void NotEqualTestMethod()
        {
            Vector v1 = new Vector();
            Vector v2 = new Vector(1, 2, 3);

            Assert.IsTrue(v1 != v2);
        }
    }
}