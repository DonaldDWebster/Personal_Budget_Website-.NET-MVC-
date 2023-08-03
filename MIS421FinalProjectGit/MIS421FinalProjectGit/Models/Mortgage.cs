using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MIS421FinalProjectGit.Models
{
    public class Mortgage
    {
        
        [Precision(14, 2)]
        public decimal HomePrice { get; set; }
        [Precision(14, 2)]
        public decimal DownPayment { get; set; }
        [Precision(14, 2)]
        public decimal LoanAmount { get; set; }
        [Precision(14, 2)]
        public decimal InterestRate { get; set; }
        [Precision(14, 2)]
        public int LoanTermm { get; set; }
        [Precision(14, 2)]
        public decimal AnnualInsurance { get; set; }
        [Precision(14, 2)]
        public decimal PropertyTaxes { get; set; }
        [Precision(14, 2)]
        //Monthly Home Owner's Association Fee
        public decimal MonthlyHOA { get; set; }
        [Precision(14, 2)]
        //An extra payment given on every 6th month (July 1st)
        public decimal ExtraPayment { get; set; }

        [Required]
        //This entity (Mortgage) has a 1-1 relationship with ApplicationUser, and therefore it has the primary and foreign key as the s
        [Key]
        public Guid ApplicationUserID { get; set; }

        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }

       
        [Precision(14, 2)]
        [NotMapped]

        //(decimal[] monthlyPayments, decimal remainingBalance) 
        public (decimal[] monthlyPayments, decimal[] remainingBalance) monthlyPayments
        {
            

        get
            {
                (decimal[] monthlyPayments, decimal[] remainingBalance) outputTuple = (null, null);
                //rename the below variable to Monthly Payments soon
          

                //need to change numOfPayyments to MonthlyPayment
                //this code is redundant and should be removed later, but exists now for testing purposes
                int totalPayments = 12 * LoanTermm;
                decimal[]? monthlyPayments = new decimal[totalPayments];
                decimal[]? remainingBalance = new decimal[totalPayments];
                //interest Rate is divded by 100 to convert from percentage, and then divided by 12 to find the monthly rate
                decimal monthlyInterest = InterestRate / (100*12);
                double testing= Math.Pow((double)(1 + monthlyInterest), (double)totalPayments);
                decimal testing2 = (decimal)testing;

                decimal monthlyPayment = (LoanAmount * monthlyInterest * (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments))
                                         /
                                         ( (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments) -1);

                for (int paymentNum = 0; paymentNum < totalPayments; paymentNum++)
                { 
                    monthlyPayments[paymentNum] = monthlyPayment;
                    //remove below line later
                    remainingBalance[paymentNum] = monthlyPayment;
                }

                outputTuple.monthlyPayments= monthlyPayments;
                outputTuple.remainingBalance = remainingBalance;
                //outputTuple.remainingBalance = (decimal) 1.23456;
                return outputTuple;
            }
         }
    }
}

