using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Transferencias.Models;

public class Transfers
{
    [Key]
    public Guid TransferId { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public decimal Amount { get; set; }

    [JsonIgnore]
    public User? UserSubmitted { get; set; }
    [JsonIgnore]
    public User? UserReceived { get; set; }
}
