using BookShop.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.DAL.Entities {
  [Table("Authors", Schema = "dbo")]
  public class Author : BasePerson {
    public string? Biography { get; set; }
  }

}
