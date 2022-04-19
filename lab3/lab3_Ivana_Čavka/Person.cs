using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_Ivana_Čavka
{
    class Person
    {
        public string Name { get; set; } //naziv/ime
        public string Address { get; set; } //Adresa
        public string IBAN { get; set; } //IBAN ili broj računa platitelja
        public string Total { get; set; } //Iznos
        public string Model { get; set; } //Model
        public string Number { get; set; } //Poziv na broj platitelja

        public bool CheckIBAN()
        {
            if(IBAN.Length == 22)
            {
                for (int i=0; i < 22; i++)
                {
                    if (Char.IsLetter(IBAN[i]) && i < 2 || Char.IsDigit(IBAN[i]) && i>=2)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("IBAN mora sadržavati 2 znak i 20 znamenki");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("IBAN mora biti dužine 22 znaka");
                return false;
            }
            return false;
        }
        public bool CheckModel()
        {
            if (Model.Length == 2)
            {
                if (Char.IsDigit(IBAN[0]) && Char.IsDigit(IBAN[1]))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Model mora sadržavati 2 znamenke");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Model mora sadržavati 2 znamenke");
                return false;
            }
        }
    }

}