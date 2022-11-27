namespace BookShop.DAL.Core {
  public abstract class BasePerson : BaseEntity {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
  }
}

