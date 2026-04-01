using ApiWeb.Services;
using ApiWeb.Models;
using ApiWeb.Services.InputModels;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiWeb.Repositories;

public class UsuarioRepository
{
    private readonly UtilService _utilService;

    public UsuarioRepository(UtilService utilService)
    {
        _utilService = utilService;
    }

    public int? IncluiUsuario(IncluiUsuarioInputModel usuario)
    {
        string query = @"exec stp_incluiUsuario 
             @KeycloakId = @KeycloakId,
             @Nome = @Nome,
             @Email = @Email,
             @DtCriacao = @DtCriacao";

        using (var conn = new SqlConnection(_utilService.SeviceConn()))
        {
            conn.Open();
            return conn.Query<int>(query, new
            {
                DtCriacao = usuario.DtCriacao,
                Nome = usuario.Nome,
                Email = usuario.Email,
                KeycloakId = usuario.KeycloakId
            }).FirstOrDefault();
        }
    }

    public Usuario? BuscarPorKeycloakId(string keycloakId)
    {
        const string query = "exec stp_buscaUsuarioPorKeycloakId @KeycloakId";

        using (var conn = new SqlConnection(_utilService.SeviceConn()))
        {
            conn.Open();
            return conn.QueryFirstOrDefault<Usuario>(query, new
            {
                KeycloakId = keycloakId
            });
        }
    }
}