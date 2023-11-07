using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Client
{
    [Key]
    [Column("ClientId")]
    public int Id { get; set; }
    [Column("ClientName")]
    public string Name { get; set; }
    [Column("ClientSurname")]
    public string Surname { get; set; }
    [Column("ClientEmail")]
    public string Email { get; set; }

    public Client(string name, string surname, string email)
    {
        Name = name;
        Surname = surname;
        Email = email;
    }
}