using lr_2;
using NuGet.Frameworks;

namespace Tests
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void Test_GetFromString()
        {
            //Arrange
            string str = "{<2,a>,<5,b>,<9,c>}";
            Set set = new Set(("a", 2), ("b", 5), ("c", 9));
            Set set1 = new Set(("a", 2), ("b", 5), ("c", 8));

            //Act
            Set set2 = Set.GetFromString(str);

            //Assert
            Assert.AreEqual(set, set2);
            Assert.AreNotEqual(set, set1);

        }

        [TestMethod]
        public void Test_Disjunction()
        {
            //Arrange
            Set set1= new Set(("a", 2), ("b", 5), ("c", 9));
            Set set2 = new Set(("a", 1), ("b", 7));
            Set espect = new Set(("a", 2), ("b", 7), ("c", 9));

            //Act
            Set result = Set.Disjunction(set1, set2);

            //Assert
            Assert.AreEqual(espect, result);
        }

        [TestMethod]
        public void Test_Difference()
        {
            //Arrange
            Set set = new Set(("a", 2), ("b", 5), ("c", 9));
            Set set1 = new Set(("a", 2), ("b", 5));
            Set espect = new Set(("c", 9));

            //Act
            Set set2 = Set.Difference(set, set1);

            //Assert
            Assert.AreEqual(espect, set2);
        }

        [TestMethod]
        public void Test_SymmetricDifference()
        {
            //Arrange
            Set set = new Set(("a", 2), ("b", 5), ("c", 9));
            Set set1 = new Set(("a", 2), ("b", 5), ("c", 5), ("d", 1));
            Set espect = new Set(("c", 4), ("d", 1));

            //Act
            Set set2 = Set.SymmetricDifference(set, set1);

            //Assert
            Assert.AreEqual(espect, set2);
        }

        [TestMethod]
        public void Test_EmptySet()
        {
            //Arrange
            Set espect = new(("a", 2), ("b", 5), (new Set(), 1));
            string str = "{<2,a>,<5,b>,<1,{}>}";

            //Act
            Set set = Set.GetFromString(str);

            //Assert
            Assert.AreEqual(espect, set);
        }

        [TestMethod]
        public void Test_SymmetricDifference_more_params()
        {
            //Arrange
            Set set1 = new((1, 2), (4, 2), (3, 5), (5, 1));
            Set set2 = new((1, 2), (4, 2));
            Set set3 = new((5, 1), (3, 3));
            Set set4 = new(("a", 1));
            Set espect = new((3, 2), ("a", 1));

            //Act
            Set set = Set.SymmetricDifference(set1, set2, set3, set4);

            //Assert
            Assert.AreEqual(espect, set);
        }


    }
}