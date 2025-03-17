using System.Collections.Frozen;
using System.Net.Security;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
app.UseSwagger();
app.UseSwaggerUI();
}
app.UseHttpsRedirection();

List<Category> categories = new List<Category>();
app.MapGet("/", () =>"API single Method");

//GET /api/categories => read Category
app.MapGet("/api/categories",([FromQuery]string searchProducts = "") =>
    {
      //Console.WriteLine($"{searchProducts}");
      if( !String.IsNullOrEmpty(searchProducts)){
              Console.WriteLine($"{searchProducts}");
      var searchCategories = categories.Where( c => c.Name.Contains(searchProducts, StringComparison.OrdinalIgnoreCase)).ToList();
      return Results.Ok(searchCategories);        
           }
      
  return  Results.Ok(categories); //200
    });
    // post /api/categories => create a Category
  app.MapPost("/api/categories", ([FromBody] Category CategoryData) => 
  {
    //Console.WriteLine($"{CategoryData}");
    
    var NewCategory = new Category{
        //CategoryId = Guid.Parse("Cf566f82-e4ae-4b95-b939-b29a0033db35"),
        CategoryId = Guid.NewGuid(),
        Name = CategoryData.Name,
        Description = CategoryData.Description,
        CreatedAt = DateTime.UtcNow
    }; 
    categories.Add(NewCategory);
    return Results.Created($"/api/categories/{NewCategory.CategoryId}",NewCategory);
    });

    //Delete /api/categories => Delete a Category
  app.MapDelete("/api/categories/{IdCategory}",(Guid IdCategory) =>
      {
        var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return Results.NotFound("Category with this id dosenot not exist");
         }
      categories.Remove(foundCategory);
      return Results.NoContent();
      });
    //Update /api/categories => Update a Category
  app.MapPut("/api/categories/{IdCategory}",(Guid IdCategory, [FromBody] Category CategoryData) =>
      {
        var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return Results.NotFound("Category with this id dosenot not exist");
         }
         foundCategory.Name = CategoryData.Name;
         foundCategory.Description = CategoryData.Description;
        return Results.NoContent();
      });


app.Run();


public record Category
{
  public Guid CategoryId { get; set;}
  public string Name {get; set;}
  public string? Description {get; set;}
  public DateTime CreatedAt {get; set;}
};







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


