namespace ApiWeb.Services.InputModels;

public class IncluiUsuarioInputModel
{
    public DateTime DtCriacao { get; set; } = DateTime.Now;
    public string? Nome {get;set;}
    public string? Email {get;set;}
    public string KeycloakId { get; set; }
}