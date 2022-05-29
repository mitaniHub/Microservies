using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataLayer.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int IdAccount { get; set; }
        public decimal Amount { get; set; }
        public int IdCustomer { get; set; }
    }
}
