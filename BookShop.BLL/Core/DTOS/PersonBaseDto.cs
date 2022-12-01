using System;

namespace BookShop.BLL.Core.DTOS {
  public class PersonBaseDto {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime CreationDate { get; set; }

  }
}
