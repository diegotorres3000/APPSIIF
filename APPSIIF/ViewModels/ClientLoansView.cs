using System;
using System.Collections.Generic;
using APPSIIF.Models.Api;

namespace APPSIIF.ViewModels
{
    public class ClientLoansViewModel : BaseViewModel
    {
        public List<Loan> Loans { get; set; }

        public ClientLoansViewModel()
        {
            Loans = new List<Loan>
            {
                new Loan
                {
                    Number = "123456789",
                    Balance = "123,123,000.00"
                },
                new Loan
                {
                    Number = "123456789",
                    Balance = "123,123,000.00"
                },
                new Loan
                {
                    Number = "123456789",
                    Balance = "123,123,000.00"
                },
                new Loan
                {
                    Number = "123456789",
                    Balance = "123,123,000.00"
                }
            };
        }
    }
}
