using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Invoices
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public char SerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SequenceNumber { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxAuthority { get; set; }
        public DateTime Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }


        public ICollection<InvoiceItem> invoiceItem { get; set; }
    }
}