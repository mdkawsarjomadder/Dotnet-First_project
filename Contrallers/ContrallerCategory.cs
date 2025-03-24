using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.DTOs;
using asp_net_ecommerce_web_api.Models;
using Microsoft.AspNetCore.Mvc;
namespace asp_net_ecommerce_web_api.contrallers
{
  [ApiController]
  [Route("api/categories/")]
  public class ContrallerCategory : ControllerBase
  {
   private static List<Category> categories = new List<Category>();

   //GET:/api/categories => Read categories
   [HttpGet]
   public IActionResult GetCategories([FromQuery]string searchProducts = ""){
        /*if( !String.IsNullOrEmpty(searchProducts)){
              Console.WriteLine($"{searchProducts}");
      var searchCategories = categories.Where( c => c.Name.Contains(searchProducts, StringComparison.OrdinalIgnoreCase)).ToList();
      return Ok(searchCategories);        
           }*/
     var categoryList = categories.Select(c => new categoryReadDto{
        CategoryId = c.CategoryId,
        Name = c.Name,
        Description = c.Description,
        CreatedAt = c.CreatedAt,
      }).ToList();
      
  return Ok(categoryList); //200
   }
      //POST:/api/categories => Create a category
   [HttpPost]
   public IActionResult CreateCategory([FromBody] createCategoryDTOs  CategoryData){
        //Console.WriteLine($"{CategoryData}");
    
    if(string.IsNullOrEmpty(CategoryData.Name)){
      return BadRequest("Category Name is required and can not be empty.!");
    }
    
    if(CategoryData.Name.Length < 2){
      return BadRequest("Category Name is required and can not 2 characters loge");
    }
    var NewCategory = new Category{
        //CategoryId = Guid.Parse("Cf566f82-e4ae-4b95-b939-b29a0033db35"),
        CategoryId = Guid.NewGuid(),
        Name = CategoryData.Name,
        Description = CategoryData.Description,
        CreatedAt = DateTime.UtcNow
    }; 
    categories.Add(NewCategory);
    var CategoryReadDto = new categoryReadDto{
      CategoryId = NewCategory.CategoryId,
      Name = NewCategory.Name,
      Description = NewCategory.Description,
      CreatedAt = NewCategory.CreatedAt,
    };
    return Created($"/api/categories/{NewCategory.CategoryId}",CategoryReadDto);
  
   }
   //PUT:/api/categories/{categoryId } => The category in update.......
   [HttpPut("{IdCategory:guid}")]
   public IActionResult UpdateIsCategoryById(Guid IdCategory, [FromBody] categoryInUpdateDTOs CategoryData){
         {
          var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return NotFound("Category with this id dosenot not exist");
         }
         if(CategoryData == null){
          return BadRequest("Category is Data in Missing...!");
         }
         /*foundCategory.Name = CategoryData.Name ?? foundCategory.Name;
         foundCategory.Description = CategoryData.Description ?? foundCategory.Description;*/
        if(!string.IsNullOrEmpty(CategoryData.Name)){
          if(foundCategory.Name.Length >= 2){
              foundCategory.Name = CategoryData.Name;
          }else{
            return BadRequest("Categriy bane must be atleast 2 Cgaracters in long");
           }
          }
        if(!string.IsNullOrWhiteSpace(CategoryData.Description)){
          foundCategory.Description = CategoryData.Description;
          }
        return NoContent();
   }
   
      
   }
   //DELETE:/api/categories => Delete a category in Id....
   [HttpDelete("{IdCategory:guid}")]
   public IActionResult DeleteCategoryById(Guid IdCategory ){
         {
        var foundCategory = categories.FirstOrDefault(category => category.CategoryId == IdCategory);
         if(foundCategory == null){
          return NotFound("Category with this id dosenot not exist");
         }
      categories.Remove(foundCategory);
      return NoContent();
   }
      
   }
}
}
