var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", () =>{
return "API Method";
});

app.MapGet("/hello", () =>{
return "Get Mathode : Hello! MapGet";
});
 
app.MapPost("/hello", () =>{
return "Post Mathode : Hello! MapPost";
});

app.MapPut("/hello", () =>{
return "put Mathode : Hello! MapPut";
});

app.MapDelete("/hello", () =>{
return "Delete Mathode : Hello! MapDelete";
});



app.Run();

