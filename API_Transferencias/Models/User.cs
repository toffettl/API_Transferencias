namespace API_Transferencias.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public decimal Wallet { get; set; }
    public string Password { get; set; }

    public ICollection<Transfers> SentTransfers { get; set; }
    public ICollection<Transfers> IncomingTransfers { get; set; }
}
