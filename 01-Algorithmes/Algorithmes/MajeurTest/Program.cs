namespace MajeurTest
   
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            int age;

            /* DEBUT PROGRAMME */

            Console.Write("QUel est votre âge ? : ");
            age = int.Parse(Console.ReadLine());

            if (age < 0)
            {
                Console.WriteLine("Vous n'êtes pas né");
            }
            else if (age >= 18)
            {
                Console.WriteLine("Vous êtes majeur.");
            }
            else
            {
                Console.WriteLine("Vous êtes mineur.");
            }
            /* FIN PROGRAMME */

        }
    }
}
