using ClassLibraryLepidoptere;

namespace ConsoleAppLepidoptere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lepidoptere monLepi = new Lepidoptere("Le vulcain");
            monLepi.SeDeplacer();
            monLepi.SeMetamorphoser();
            monLepi.SeDeplacer();
            monLepi.SeMetamorphoser();
            monLepi.SeDeplacer();
            monLepi.SeMetamorphoser();
            monLepi.SeDeplacer();
            monLepi.SeMetamorphoser();
            monLepi.SeDeplacer();
        }
    }
}
