var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
services.AddSignalR(optionsHub =>
{
    optionsHub.EnableDetailedErrors = true;
});  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<MessageBrokerHub>("/messagebroker");

app.Run();
