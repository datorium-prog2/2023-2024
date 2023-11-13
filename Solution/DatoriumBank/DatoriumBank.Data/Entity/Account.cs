using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace DatoriumBank.Data.Entity
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string IBAN { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
