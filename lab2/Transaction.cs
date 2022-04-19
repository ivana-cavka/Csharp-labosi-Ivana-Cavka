using System;

namespace lab2_Csharp_Ivana_Čavka
{
    class Transaction
    {
        static void Main(string[] args)
        {
            uint n = 1;            
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("-------------------------------- transakcija br " + DateTime.Now.Day + n + " --------------------------------");
                Deposit deposit = new Deposit();
                Console.WriteLine("Podaci o platitelju: ");
                deposit.Payer.InputPerson();
                Console.WriteLine("Podaci o primatelju: ");
                deposit.Payee.InputPerson();
                deposit.InputInfo();
                Console.WriteLine("Vaša uplata je uspješno izvršena.");
                using StreamWriter file = new StreamWriter("Potvrda-br-" + DateTime.Now.Day + n + ".txt");
                file.WriteLine(deposit.ToString());
                Console.WriteLine("Potvrda spremljena.");
                Console.WriteLine("Želite li izvršiti jos jednu uplatu? (da/ne)");
                string input = Console.ReadLine();
                if (input != null) flag = (input.ToLower() == "da");
                n++;
            }
        }
    }
}
