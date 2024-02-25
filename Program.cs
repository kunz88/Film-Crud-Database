using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
// --- > Cartella wwwroot
//Contiene asset statici, ad esempio file HTML, file JavaScript e file CSS. Per altre informazioni, vedere
//File .cshtml con markup HTML con codice C# usando la sintassi Razor .
//File .cshtml.cs con codice C# che gestisce gli eventi della pagina.

// -- > appsettings.json
//Contiene dati di configurazione, ad esempio stringa di connessione

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/* Il codice seguente illustra come selezionare il stringa di connessione SQLite 
in fase di sviluppo e SQL Server nell'ambiente di produzione. */
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext")));
}

/*  Il contesto "RazorPagesMovieContext" del database viene registrato con la Dependency Injection in Program.cs: */
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder
    .Configuration
    .GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();


// funzione di seeding del database vedi:MOdels/SeedData
using (var scope = app.Services.CreateScope()) 
/* Ottenere un'istanza del contesto di database dal contenitore di inserimento delle dipendenze.
Chiamare il metodo seedData.Initialize passando all'istanza del contesto del database.
Eliminare il contesto dopo che il metodo di inizializzazione è stato completato. 
L'istruzione using garantisce che il contesto venga eliminato. */
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Il codice seguente abilita vari middleware:

app.UseHttpsRedirection(); //reindirizza le richieste HTTP a HTTPS.
app.UseStaticFiles(); //consente la gestione di file statici, ad esempio HTML, CSS, immagini e JavaScript.

app.UseRouting();//aggiunge la corrispondenza della route alla pipeline middleware

app.UseAuthorization();

app.MapRazorPages();// configura il routing degli endpoint per Razor Pages.

app.Run();
