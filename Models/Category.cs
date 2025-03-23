using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace asp_net_ecommerce_web_api.Models
{
   public class Category{
  public Guid CategoryId { get; set;}
  public string Name {get; set;}
  public string Description {get; set;} = string.Empty;
  public DateTime CreatedAt {get; set;}
 };

   }
