using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab2_Csharp_Ivana_Čavka
{
    class Deposit
    {
        public Person? Payer { get; set; } //platitelj
        public Person? Payee { get; set; } //primatelj
        public decimal Total { get; set; } //Iznos
        public string? Currency { get; set; } //valuta
        public string? Model { get; set; } //Model
        public string? Number { get; set; } //Poziv na broj platitelja
        public string? Description { get; set; } //opis plaćanja
        public DateOnly ExecutionDate { get; set; } //datum izvršenja
        public Deposit()
        {
            Payer = new Person();
            Payee = new Person();
            Total = 0;
            Currency = "HRK";
            Model = "00";
            Number = "-";
            Description = "-";
            ExecutionDate = DateOnly.FromDateTime(DateTime.Now);
        }
        public bool CheckCurrency()
        {
            string[] CurrencyOptions = { "HRK", "USD", "EUR", "GBP" };
            return CurrencyOptions.Contains(Currency);
        }
        public bool CheckTotal()
        {
            return Total > 0;
        }
        public bool CheckDate()
        {
            TimeSpan diff = ExecutionDate.ToDateTime(TimeOnly.Parse("10:00 PM")) - DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("10:00 PM"));
            return diff.Days > 0;
        }
        public bool CheckModel()
        {
            if (Model.Length == 2 && Model != null)
            {
                if (Char.IsDigit(Model[0]) && Char.IsDigit(Model[1]))
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
        public void SetTotal()
        {
            Console.WriteLine("Unesite iznos uplate: ");
            string input = Console.ReadLine();
            if (input == null) SetTotal();
            else Total = Decimal.Parse(input);
            if (!CheckTotal()) SetTotal();
        } 
        public void SetCurrency()
        {
            Console.WriteLine("Unesite valutu (HRK,USD,EUR ili GBP): ");
            string input = Console.ReadLine();
            if (input == null) SetCurrency();
            else Currency = input.ToUpper();
            if (!CheckCurrency()) SetCurrency();
        } 
        public void SetModel()
        {
            Console.WriteLine("Unesite model placanja: ");
            string input = Console.ReadLine();
            if (input == null) SetModel();
            else Model = input;
            if (!CheckModel()) SetModel();
        } 
        public void SetNumber()
        {
            Console.WriteLine("Unesite poziv na broj: ");
            string input = Console.ReadLine();
            if (input != null)
                Number = input;
        }
        public void SetDescription()
        {
            Console.WriteLine("Unesite opis placanja: ");
            string input = Console.ReadLine();
            if (input != null)
                Description = input;
        }
        public void SetExecutionDate()
        {
            Console.WriteLine("Unesite datum izvrsenja uplate (DD.MM.YYYY): ");
            string input = Console.ReadLine();
            DateOnly dateValue;
            if (input == null) SetExecutionDate();
            else if (DateOnly.TryParse(input, out dateValue))
            { 
                Console.WriteLine("Converted '{0}' to {1}.", input, dateValue);
                ExecutionDate = dateValue;
            }
            else
                Console.WriteLine("Unable to convert '{0}' to a date.", input); 
            if (!CheckDate()) SetExecutionDate();
        }
        public void InputInfo()
        {
            SetCurrency();
            SetTotal();
            SetModel();
            SetNumber();
            SetDescription();
            SetExecutionDate();
        }
       public override string ToString()
        {
            string output = "";
            output += "Podaci o platitelju: ";
            output += "\nIme: " + Payer.Name;
            output += "\nAdresa: " + Payer.Address;
            output += "\nIBAN: " + Payer.IBAN;
            output += "\n\nPodaci o primatelju: ";
            output += "\nIme: " + Payee.Name;
            output += "\nAdresa: " + Payee.Address;
            output += "\nIBAN: " + Payer.IBAN;
            output += "\n\nPodaci o plaćanju: ";
            output += "\nIznos: " + Total;
            output += "\nValuta: " + Currency;
            output += "\nModel: " + Model;
            output += "\nPoziv na broj: " + Number;
            output += "\nOpis: " + Description;
            output += "\nDatum izvršenja: " + ExecutionDate;
            output += "\nDatum uplate: " + DateOnly.FromDateTime(DateTime.Now);
            return output;
        }
    }
}
