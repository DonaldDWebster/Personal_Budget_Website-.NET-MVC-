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
        [Display(Name = "Home Price")]
        public decimal HomePrice { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Down Payment")]
        public decimal DownPayment { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Loan Amount")]
        public decimal LoanAmount { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Loan Term")]
        public int LoanTerm { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Annual Insurance")]
        public decimal AnnualInsurance { get; set; }
        [Precision(14, 2)]
        [Display(Name = "Property Taxes")]
        public decimal PropertyTaxes { get; set; }
        [Precision(14, 2)]
        //Monthly Home Owner's Association Fee
        [Display(Name = "Monthly HOA Fee")]
        public decimal MonthlyHOA { get; set; }
        [Precision(14, 2)]
        //An extra payment given on every 6th month (July 1st)
        [Display(Name = "Extra payment every 6th Month")]
        public Boolean ExtraPayment { get; set; }

        [Required]
        //This entity (Mortgage) has a 1-1 relationship with ApplicationUser, and therefore it has the primary and foreign key as the s
        [Key]
        public Guid ApplicationUserID { get; set; }

        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }

       
        [Precision(14, 2)]
        [NotMapped]

        //(decimal[] monthlyPayments, decimal remainingBalances) 
        public (DateTime[]? paymentDates, decimal[]? principalPayments, decimal[]? interestPayments, decimal[] monthlyPayments, decimal[] remainingBalances, decimal[]? monthlyTotalCosts, int lastPaymentNum) monthlyPayments
        {
            

        get
            {
                (DateTime[] ? paymentDates, decimal[] ? principalPayments, decimal[] ? interestPayments, decimal[] monthlyPayments, decimal[] remainingBalances, decimal[]? monthlyTotalCosts, int lastPaymentNum) outputTuple = (null,null,null,null,null,null,0);
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
                int lastPaymentNum = 0;

                DateTime loanStartDate = new DateTime(2024, 1, 1);
                //interest Rate is divded by 100 to convert from percentage, and then divided by 12 to find the monthly rate
                decimal monthlyInterest = InterestRate / (100*12);
        
                decimal monthlyPayment = (LoanAmount * monthlyInterest * (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments))
                                         /
                                         ( (decimal)Math.Pow((double)(1 + monthlyInterest), (double)totalPayments) -1);

                for (int paymentNum = 0; paymentNum < totalPayments && lastPaymentNum == 0; paymentNum++)
                {
                    paymentDates[paymentNum] = loanStartDate.AddMonths(paymentNum);
                    monthlyPayments[paymentNum] = monthlyPayment;
                        //checks adds an additionaly payment every six month 
                        if ( ExtraPayment && ((paymentNum+1) % 6 == 0) )
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
                        interestPayments[paymentNum] = remainingBalances[paymentNum - 1] * monthlyInterest;
                        principalPayments[paymentNum] = monthlyPayments[paymentNum] - interestPayments[paymentNum];
                        remainingBalances[paymentNum] = (remainingBalances[paymentNum - 1] - principalPayments[paymentNum]);

                        //maybe add here
                        if( remainingBalances[paymentNum] <= 0 ) {

                        //reset the principal and monthly payements so that they pays off the remaining Balance but not more than the remaining balance
                        principalPayments[paymentNum] = remainingBalances[paymentNum-1];
                        monthlyPayments[paymentNum] = principalPayments[paymentNum] + interestPayments[paymentNum];

                        //set remainingBalance to 0
                        remainingBalances[paymentNum] = 0;

                            //log the curren payment so you know when the last payment is
                            //have some kind of trigger that ends the program
                            
                            lastPaymentNum = paymentNum;
                            //below line will trigger the end of the for loop
                            //paymentNum = totalPayments;
                            
                        }
                    }

                    monthlyTotalCosts[paymentNum] = monthlyPayments[paymentNum] + MonthlyHOA + (AnnualInsurance / 12) + (PropertyTaxes / 12);
                }
               
                outputTuple.paymentDates = paymentDates;
                outputTuple.principalPayments = principalPayments;
                outputTuple.interestPayments = interestPayments; 
                outputTuple.monthlyPayments= monthlyPayments;
                outputTuple.remainingBalances = remainingBalances;
                outputTuple.monthlyTotalCosts = monthlyTotalCosts;
                outputTuple.lastPaymentNum = lastPaymentNum;
   
                return outputTuple;
            }
         }
    }
}

