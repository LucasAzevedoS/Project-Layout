using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiWeb.Repositories;
using ApiWeb.Services.InputModels;

namespace ApiWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuarioController : ControllerBase 
{
    private readonly UsuarioRepository _usuarioRepository; 
    public UsuarioController(UsuarioRepository usuarioRepository) 
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("primeiro-acesso")]
    public IActionResult PrimeiroAcesso()
    {
        // Debug temporário — lista todas as claims
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"Claim: {claim.Type} = {claim.Value}");
        }

        var keycloakId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Console.WriteLine($"KeycloakId: {keycloakId}");
        var email = User.FindFirst(ClaimTypes.Email)?.Value; 
        var nome = User.FindFirst("preferred_username")?.Value;

        var usuario = _usuarioRepository.BuscarPorKeycloakId(keycloakId);

        if (usuario != null)
        {
            return Ok(new
            {
                isFirstAccess = false,
                usuarioId = usuario.Id
            });
        }

        var input = new IncluiUsuarioInputModel
        {
            DtCriacao = DateTime.UtcNow,
            Nome = nome,
            Email = email,
            KeycloakId = keycloakId
        };

        var novoUsuarioId = _usuarioRepository.IncluiUsuario(input); 

        return Ok(new
        {
            isFirstAccess = true,
            usuarioId = novoUsuarioId
        });
    }
}