namespace API_Transferencias.Models;

public class Transfers
{
    public Guid TransferId { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public decimal Amount { get; set; }

    public User UserSubmitted { get; set; }
    public User UserReceived { get; set; }
}
