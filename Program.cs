using System.Collections.Frozen;
using System.Net.Security;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//add services to the contralller..............!
builder.Services.AddControllers();  //step number one.............!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
app.UseSwagger();
app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", () =>"API single Method");
app.MapControllers();
app.Run();





/*//GET /api/categories => read Category
  app.MapGet("/api/categories",() =>
    {
    //Console.WriteLine($"{searchProducts}");
      if( !String.IsNullOrEmpty(searchProducts)){
              Console.WriteLine($"{searchProducts}");
      var searchCategories = categories.Where( c => c.Name.Contains(searchProducts, StringComparison.OrdinalIgnoreCase)).ToList();
      return Results.Ok(searchCategories);        
           }
      
  return  Results.Ok(categories); //200
    });*/
 /*   // post /api/categories => create a Category------------comment
  app.MapPost("/api/categories", ([FromBody] Category CategoryData) => 
  {
    //Console.WriteLine($"{CategoryData}");
    
    if(string.IsNullOrEmpty(CategoryData.Name)){
      return Results.BadRequest("Category Name is required and can not be empty.!");
    }
    var NewCategory = new Category{
        //CategoryId = Guid.Parse("Cf566f82-e4ae-4b95-b939-b29a0033db35"),
        CategoryId = Guid.NewGuid(),
        Name = CategoryData.Name,
        Description = CategoryData.Description,
        CreatedAt = DateTime.UtcNow
    }; 
    categories.Add(NewCategory);
    return Results.Created($"/api/categories/{NewCategory.CategoryId}",NewCategory);
    });*/

   /* //Delete /api/categories => Delete a Category
  app.MapDelete("/api/categories/{IdCategory:guid}",(Guid IdCategory ) =>
      {
        var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return Results.NotFound("Category with this id dosenot not exist");
         }
      categories.Remove(foundCategory);
      return Results.NoContent();
      });*/
   /* //Update /api/categories => Update a Category
  app.MapPut("/api/categories/{IdCategory:guid}",(Guid IdCategory, [FromBody] Category CategoryData) =>
      {
        var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return Results.NotFound("Category with this id dosenot not exist");
         }
         if(CategoryData == null){
          return Results.BadRequest("Category is Data in Missing...!");
         }
        ------------foundCategory.Name = CategoryData.Name ?? foundCategory.Name;
         foundCategory.Description = CategoryData.Description ?? foundCategory.Description;-------------------
        if(!string.IsNullOrEmpty(CategoryData.Name)){
          if(foundCategory.Name.Length >= 2){
              foundCategory.Name = CategoryData.Name;
          }else{
            return Results.BadRequest("Categriy bane must be atleast 2 Cgaracters in long");
           }
          }
        if(!string.IsNullOrWhiteSpace(CategoryData.Description)){
          foundCategory.Description = CategoryData.Description;
          }
        return Results.NoContent();
      });*/

 