using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public decimal[]? NumOfPayments
        {
            get
            {
                decimal[]? numOfPayments;

                //need to change numOfPayyments to MonthlyPayment
                //this code is redundant and should be removed later, but exists now for testing purposes
                int totalPayments = 12 * LoanTermm;
                numOfPayments = new decimal[totalPayments];

                for (int paymentNum = 0; paymentNum < totalPayments; paymentNum++)
                {
                    decimal monthlyInterest = InterestRate / 12;

                    decimal monthlyPayment = (LoanAmount * monthlyInterest * (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments));

                    numOfPayments[paymentNum] = monthlyPayment;
                }

                return numOfPayments;
            }
         }
    }
}

