using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        public int LoanTerm { get; set; }
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

        //(decimal[] monthlyPayments, decimal remainingBalances) 
        public (DateTime[]? paymentDates, decimal[]? principalPayments, decimal[]? interestPayments, decimal[] monthlyPayments, decimal[] remainingBalances, decimal[]? monthlyTotalCosts) monthlyPayments
        {
            

        get
            {
                (DateTime[] ? paymentDates, decimal[] ? principalPayments, decimal[] ? interestPayments, decimal[] monthlyPayments, decimal[] remainingBalances, decimal[]? monthlyTotalCosts) outputTuple = (null,null,null,null,null,null);
                //rename the below variable to Monthly Payments soon
          

                //need to change numOfPayyments to MonthlyPayment
                //this code is redundant and should be removed later, but exists now for testing purposes
                int totalPayments = 12 * LoanTerm;
               
                DateTime[]? paymentDates = new DateTime[totalPayments];
                decimal[]? principalPayments = new decimal[totalPayments];
                decimal[]? interestPayments = new decimal[totalPayments];
                decimal[]? monthlyPayments = new decimal[totalPayments];
                decimal[]? remainingBalances = new decimal[totalPayments];
                //total monthly cost = total payment + Home owners fee + taxes + etc
                decimal[]? monthlyTotalCosts = new decimal[totalPayments];

                DateTime loanStartDate = new DateTime(2024, 1, 1);
                //interest Rate is divded by 100 to convert from percentage, and then divided by 12 to find the monthly rate
                decimal monthlyInterest = InterestRate / (100*12);
        
                decimal monthlyPayment = (LoanAmount * monthlyInterest * (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments))
                                         /
                                         ( (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments) -1);

                for (int paymentNum = 0; paymentNum < totalPayments; paymentNum++)
                {
                    paymentDates[paymentNum] = loanStartDate.AddMonths(paymentNum);
                    monthlyPayments[paymentNum] = monthlyPayment;
                        //checks adds an additionaly payment every six month 
                        if ( (paymentNum+1) % 6 == 0)
                        {
                            monthlyPayments[paymentNum] += monthlyPayment;
                        }
                    if (paymentNum == 0)
                    {
                        interestPayments[paymentNum] = LoanAmount * monthlyInterest;
                        principalPayments[paymentNum] = monthlyPayments[paymentNum] - interestPayments[paymentNum];
                        remainingBalances[paymentNum] = LoanAmount - principalPayments[paymentNum];
                    }
                    else
                    {
                        interestPayments[paymentNum] = remainingBalances[paymentNum-1] * monthlyInterest;
                        principalPayments[paymentNum] = monthlyPayments[paymentNum] - interestPayments[paymentNum];
                        remainingBalances[paymentNum] = (remainingBalances[paymentNum - 1] - principalPayments[paymentNum]); 
                    }

                    monthlyTotalCosts[paymentNum] = monthlyPayments[paymentNum] + MonthlyHOA + (AnnualInsurance / 12) + (PropertyTaxes / 12);
                }
               
                outputTuple.paymentDates = paymentDates;
                outputTuple.principalPayments = principalPayments;
                outputTuple.interestPayments = interestPayments; 
                outputTuple.monthlyPayments= monthlyPayments;
                outputTuple.remainingBalances = remainingBalances;
                outputTuple.monthlyTotalCosts = monthlyTotalCosts;
   
                return outputTuple;
            }
         }
    }
}

