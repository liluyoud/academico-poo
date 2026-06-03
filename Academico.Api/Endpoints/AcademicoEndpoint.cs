using Academico.Shared.Entities;
using Academico.Shared.Services;

namespace Academico.Api.Endpoints;

public static class AcademicoEndpoint
{
    public static void MapAcademicoEndpoints(this IEndpointRouteBuilder routes)
    {
        // ------------------ PROFESSORES ------------------
        var professoresGroup = routes.MapGroup("/api/professores").WithTags("Professores");

        professoresGroup.MapGet("/", async (IProfessorService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        }).WithSummary("Listar Professores");

        professoresGroup.MapGet("/{id:int}", async (int id, IProfessorService service) =>
        {
            var p = await service.GetByIdAsync(id);
            return p is not null ? Results.Ok(p) : Results.NotFound("Professor não encontrado.");
        }).WithSummary("Obter Professor por ID");

        professoresGroup.MapPost("/", async (Professor professor, IProfessorService service) =>
        {
            var created = await service.CreateAsync(professor);
            return Results.Created($"/api/professores/{created.Id}", created);
        }).WithSummary("Criar Professor");

        professoresGroup.MapPut("/{id:int}", async (int id, Professor professor, IProfessorService service) =>
        {
            var updated = await service.UpdateAsync(id, professor);
            return updated ? Results.NoContent() : Results.NotFound("Professor não encontrado.");
        }).WithSummary("Atualizar Professor");

        professoresGroup.MapDelete("/{id:int}", async (int id, IProfessorService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Professor não encontrado.");
        }).WithSummary("Excluir Professor");


        // ------------------ CURSOS ------------------
        var cursosGroup = routes.MapGroup("/api/cursos").WithTags("Cursos");

        cursosGroup.MapGet("/", async (ICursoService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        }).WithSummary("Listar Cursos");

        cursosGroup.MapGet("/{id:int}", async (int id, ICursoService service) =>
        {
            var c = await service.GetByIdAsync(id);
            return c is not null ? Results.Ok(c) : Results.NotFound("Curso não encontrado.");
        }).WithSummary("Obter Curso por ID");

        cursosGroup.MapPost("/", async (Curso curso, ICursoService service) =>
        {
            var created = await service.CreateAsync(curso);
            return Results.Created($"/api/cursos/{created.Id}", created);
        }).WithSummary("Criar Curso");

        cursosGroup.MapPut("/{id:int}", async (int id, Curso curso, ICursoService service) =>
        {
            var updated = await service.UpdateAsync(id, curso);
            return updated ? Results.NoContent() : Results.NotFound("Curso não encontrado.");
        }).WithSummary("Atualizar Curso");

        cursosGroup.MapDelete("/{id:int}", async (int id, ICursoService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Curso não encontrado.");
        }).WithSummary("Excluir Curso");


        // ------------------ DISCIPLINAS ------------------
        var disciplinasGroup = routes.MapGroup("/api/disciplinas").WithTags("Disciplinas");

        disciplinasGroup.MapGet("/", async (IDisciplinaService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        }).WithSummary("Listar Disciplinas");

        disciplinasGroup.MapGet("/{id:int}", async (int id, IDisciplinaService service) =>
        {
            var d = await service.GetByIdAsync(id);
            return d is not null ? Results.Ok(d) : Results.NotFound("Disciplina não encontrada.");
        }).WithSummary("Obter Disciplina por ID");

        disciplinasGroup.MapPost("/", async (Disciplina disciplina, IDisciplinaService service) =>
        {
            var created = await service.CreateAsync(disciplina);
            return Results.Created($"/api/disciplinas/{created.Id}", created);
        }).WithSummary("Criar Disciplina");

        disciplinasGroup.MapPut("/{id:int}", async (int id, Disciplina disciplina, IDisciplinaService service) =>
        {
            var updated = await service.UpdateAsync(id, disciplina);
            return updated ? Results.NoContent() : Results.NotFound("Disciplina não encontrada.");
        }).WithSummary("Atualizar Disciplina");

        disciplinasGroup.MapDelete("/{id:int}", async (int id, IDisciplinaService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Disciplina não encontrada.");
        }).WithSummary("Excluir Disciplina");


        // ------------------ ALUNOS ------------------
        var alunosGroup = routes.MapGroup("/api/alunos").WithTags("Alunos");

        alunosGroup.MapGet("/", async (IAlunoService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        }).WithSummary("Listar Alunos");

        alunosGroup.MapGet("/{id:int}", async (int id, IAlunoService service) =>
        {
            var a = await service.GetByIdAsync(id);
            return a is not null ? Results.Ok(a) : Results.NotFound("Aluno não encontrado.");
        }).WithSummary("Obter Aluno por ID");

        alunosGroup.MapPost("/", async (Aluno aluno, IAlunoService service) =>
        {
            var created = await service.CreateAsync(aluno);
            return Results.Created($"/api/alunos/{created.Id}", created);
        }).WithSummary("Criar Aluno");

        alunosGroup.MapPut("/{id:int}", async (int id, Aluno aluno, IAlunoService service) =>
        {
            var updated = await service.UpdateAsync(id, aluno);
            return updated ? Results.NoContent() : Results.NotFound("Aluno não encontrado.");
        }).WithSummary("Atualizar Aluno");

        alunosGroup.MapDelete("/{id:int}", async (int id, IAlunoService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Aluno não encontrado.");
        }).WithSummary("Excluir Aluno");


        // ------------------ MATRICULAS ------------------
        var matriculasGroup = routes.MapGroup("/api/matriculas").WithTags("Matrículas");

        matriculasGroup.MapGet("/", async (IMatriculaService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        }).WithSummary("Listar Matrículas");

        matriculasGroup.MapGet("/{id:int}", async (int id, IMatriculaService service) =>
        {
            var m = await service.GetByIdAsync(id);
            return m is not null ? Results.Ok(m) : Results.NotFound("Matrícula não encontrada.");
        }).WithSummary("Obter Matrícula por ID");

        matriculasGroup.MapPost("/", async (Matricula matricula, IMatriculaService service) =>
        {
            try
            {
                var created = await service.CreateAsync(matricula);
                return Results.Created($"/api/matriculas/{created.Id}", created);
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Erro ao criar matrícula: {ex.Message}");
            }
        }).WithSummary("Criar Matrícula");

        matriculasGroup.MapPut("/{id:int}", async (int id, Matricula matricula, IMatriculaService service) =>
        {
            var updated = await service.UpdateAsync(id, matricula);
            return updated ? Results.NoContent() : Results.NotFound("Matrícula não encontrada.");
        }).WithSummary("Atualizar Matrícula");

        matriculasGroup.MapDelete("/{id:int}", async (int id, IMatriculaService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Matrícula não encontrada.");
        }).WithSummary("Excluir Matrícula");
    }
}
