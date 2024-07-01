using Data_Base_Access;
using Data_Base_Access.Entities;
using Data_Base_Access.Repositories;
using Data_Base_Access.Repositories.UsersRepository;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using Data_Base_Access.Repositories.UserRepository;
using Data_Base_Access.Repositories.UsersRepository;
using Workout.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<WorkoutContext>();
builder.Services.AddScoped<IGenericRepository<Users>, UserRepository>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
