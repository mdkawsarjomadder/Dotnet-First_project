using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", () =>"API single Method");

app.MapGet("/products",() =>
     {
      var products = new List<productsDto>(){
           new productsDto ("redmi note 12",12000),
           new productsDto ("redmi note 14",15000),
      };
   return  Results.Ok(products) ; //200
     });

app.Run();

public record productsDto(string name, decimal price);







// app.MapGet("/hello",() =>
//     {
  // var response =  new { Message = "MapGat single Method", success= true};
                       //html create
//    return  Results.Content("<h1>Hello World!</h1>", "text/html") ; //200
//      });

//      app.MapPost("/hello", () =>{
//           return  Results.Created();   // new create......... 201
//      });

//      app.MapPut("/hello", () =>{
//         return Results.NoContent();//204 
//      });

//      app.MapDelete("/hello", () =>{
//            return Results.NoContent(); //204
//      });

// app.MapPut("/hello",() =>
//     {
//   var response =  new { Message = "MapPut single Method", success= true};
//    return response;
//      });

// app.MapPost("/hello",() =>
//     {
//   var response =  new { Message = "Map Post single Method", success= true};
//    return response;
//      });
 


//   app.MapDelete("/hello",() =>{
//     var response = new { message = "Map Delete json Method",success = true};
//     return response;
//   });


