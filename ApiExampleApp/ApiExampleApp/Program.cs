using ApiExampleApp.Client.Pages;
using ApiExampleApp.Components;
using ApiExampleApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    /* I'm 90% sure making the main app a server is a bad work around */
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    /* I'm 90% sure making the main app a server is a bad work around */
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ApiExampleApp.Client._Imports).Assembly);

app.Run();
