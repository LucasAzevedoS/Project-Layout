using ApiWeb.Models;
using ApiWeb.Repositories;
using ApiWeb.Services.InputModels;

namespace ApiWeb.Services;

public class UsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public int? IncluirUsuario(IncluiUsuarioInputModel usuario)
    {
        return _usuarioRepository.IncluiUsuario(usuario);
    }

    public Usuario? BuscarPorKeycloakId(string keycloakId)
    {
        return _usuarioRepository.BuscarPorKeycloakId(keycloakId);
    }
}