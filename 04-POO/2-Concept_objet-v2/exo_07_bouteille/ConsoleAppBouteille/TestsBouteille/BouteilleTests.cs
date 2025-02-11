using ClassLibraryBouteille;

namespace TestsBouteille
{
    [TestClass]
    public class BouteilleTest
    {
        [TestMethod]
        public void Ouvrir_Bouteille_ReturnsTrue()
        {
            // arrange
            Bouteille bouteilleTest1 = new Bouteille();

            // act
            bool result = bouteilleTest1.Ouvrir();

            // assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Ouvrir_Bouteille_Ouverte_ReturnsFalse()
        {
            // arrange
            Bouteille bouteilleTest2 = new Bouteille("Cristaline", 2.0f, 1.5f, true);

            // act
            bool result = bouteilleTest2.Ouvrir();

            // assert
            Assert.IsFalse(result);

        }
    }
}