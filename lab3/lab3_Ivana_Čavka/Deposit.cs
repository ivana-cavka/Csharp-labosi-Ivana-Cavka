using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab3_Ivana_Čavka
{
    class Deposit
    {
        public Person Payer { get; set; } //platitelj
        public Person Payee { get; set; } //primatelj
        public string Currency { get; set; } //valuta
        public string Description { get; set; } //opis plaćanja
        public DateTime ExecutionDate { get; set; } //datum izvršenja

        public bool CheckPayer()
        {
            return (Payer.CheckIBAN() && Payer.CheckModel());
        }
        public bool CheckPayee()
        {
            return (Payee.CheckIBAN() && Payee.CheckModel());
        }
        public bool CheckCurrency()
        {
            string[] CurrencyOptions = { "HRK", "USD", "EUR", "GBP" };
            return CurrencyOptions.Contains(Currency);
        }
        public bool CheckDate()
        {
            return (ExecutionDate - DateTime.Now).TotalDays > 0;
        }
    }
}
