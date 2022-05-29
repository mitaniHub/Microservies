using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataLayer.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } 
    }
}
