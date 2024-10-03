using FBretonTools;

namespace SaisieFloatDLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Entrer un nombre décimal positif : ";
            float reponse;

            reponse = ConsoleTools.DemanderNombreFloatPositif(message);

            Console.WriteLine(reponse);
        }
    }
}
