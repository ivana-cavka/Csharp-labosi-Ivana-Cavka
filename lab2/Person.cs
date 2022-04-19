using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_Csharp_Ivana_Čavka
{
    class Person
    {
        public string? Name { get; set; } //naziv/ime
        public string? Address { get; set; } //Adresa
        public string? IBAN { get; set; } //IBAN ili broj računa platitelja
        public Person()
        {
            Name = "-";
            Address = "-";
            IBAN = "-";
        }
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
        public bool CheckName()
        {
            if (Name.Length > 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ime ili naziv tvrtke mora biti minimalne dužine 3 znaka");
                return false;
            }
        }
        public void SetName()
        {
            Console.WriteLine("Unesite ime i prezime ili naziv tvrtke: ");
            string input = Console.ReadLine();
            if (input == null) SetName();
            else Name = input;
            if (!CheckName()) SetName();
        }
        public void SetAddress()
        {
            Console.WriteLine("Unesite adresu: ");
            string input = Console.ReadLine();
            if (input != null) Address = input;
        }
        public void SetIBAN()
        {
            Console.WriteLine("Unesite IBAN: ");
            string input = Console.ReadLine();
            if (input == null) SetIBAN();
            else IBAN = input;
            if (!CheckIBAN()) SetIBAN();
        }
        public void InputPerson()
        {
            SetName();
            SetAddress();
            SetIBAN();
        }
    }

}