using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatoriumBank.Data.Entity
{
    //Many to many example
    public class BankTransaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Account ReceiverAccount { get; set; }
        public int ReceiverAccountId { get; set; }
        public Account SenderAccount { get; set; }
        public int SenderAccountId { get; set; }
        public bool IsDeleted { get; set; } //false
    }
}
