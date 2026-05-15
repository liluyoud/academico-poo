using Academico.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Endpoints;

public static class AcademicoEndpoint
{
    public static void MapAcademicoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/testes").WithTags("Testes");

        group.MapGet("/aloapi", async () =>
        {
            return Results.Ok("Alo API WEB");
        });

        group.MapGet("/nome", async () =>
        {
            return Results.Ok("Meu nome é Lilo");
        });

        group.MapGet("/idade", async () =>
        {
            return Results.Ok("Tenho 52 anos");
        });

        group.MapGet("/endereco", async () =>
        {
            return Results.Ok("Moro em Porto Velho");
        });

        group.MapGet("/cursos", async (AcademicoContext context) =>
        {
            var cursos = await context.Cursos.ToListAsync();
            return Results.Ok(cursos);
        })
        .WithSummary("Get Cursos")
        .WithDescription("Retorna a lista de cursos cadastrados");
    }
}
