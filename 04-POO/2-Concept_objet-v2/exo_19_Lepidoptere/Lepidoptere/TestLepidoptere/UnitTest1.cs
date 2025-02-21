using ClassLibraryLepidoptere;

namespace TestLepidoptere
{
    [TestClass]
    public class LepidoptereTest
    {
        [TestMethod]
        public void TestSeMetamorphoser_returnStadeEvolution()
        {
            // arrange
            Lepidoptere lepiTest1 = new Lepidoptere("Le vulcain");

            // act
            lepiTest1.SeMetamorphoser();
            StadeEvolution monStadeEvolution = lepiTest1;

            // assert
        }
    }
}