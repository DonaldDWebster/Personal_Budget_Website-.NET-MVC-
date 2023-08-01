using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
