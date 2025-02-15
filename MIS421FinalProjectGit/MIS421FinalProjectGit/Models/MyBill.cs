﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class MyBill
    {

        [Key]
        public Guid BillID { get; set; }
        public string BillType { get; set; }
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public DateTime DayPaid { get; set; }
        public string? Description { get; set; }

        [Required]
        public Guid ApplicationUserID { get; set; }
        [ForeignKey("ID")]


        public ApplicationUser? ApplicationUser { get; set; }


    }
}
