using Academico.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Endpoints;

public static class AcademicoEndpoint
{
    public static void MapAcademicoEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/cursos").WithTags("Cursos");

        group.MapGet("/", async (AcademicoContext context) =>
        {
            var cursos = await context.Cursos.ToListAsync();
            return Results.Ok(cursos);
        })
        .WithSummary("Get Cursos")
        .WithDescription("Retorna a lista de cursos cadastrados");
    }
}
