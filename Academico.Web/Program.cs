using Academico.Web.Components;
using Academico.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure HttpClient pointing to backend WebAPI
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5206/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Register HttpClient Services for Frontend
builder.Services.AddScoped<IProfessorService, ProfessorHttpClient>();
builder.Services.AddScoped<ICursoService, CursoHttpClient>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaHttpClient>();
builder.Services.AddScoped<IAlunoService, AlunoHttpClient>();
builder.Services.AddScoped<IMatriculaService, MatriculaHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
