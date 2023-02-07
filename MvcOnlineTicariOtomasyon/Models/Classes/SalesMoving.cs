using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesMoving
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }



        //public int ProductID { get; set; }
        public int CurrentID { get; set; }
        public int PersonnelID { get; set; }

        public virtual Products Products { get; set; }
        public virtual Current Currents { get; set; }
        public virtual Personnel Personnels { get; set; }
    }
}