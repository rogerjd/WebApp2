using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2.Models
{
    public class PayChk
    {
        public int ID { get; set; }
        public int EmoID { get; set; }
        public string Payee { get; set; }

        public virtual Emp Emp { get; set; }
    }
}