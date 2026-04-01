namespace ApiWeb.Models;

public class Usuario
{
    public int Id { get; set; }
    public string KeycloakId { get; set; }
    public DateTime DtCriacao { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
}