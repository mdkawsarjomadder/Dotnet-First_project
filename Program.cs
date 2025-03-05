var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
  app.UseHttpsRedirection();
 Console.WriteLine();
 
app.Run();

