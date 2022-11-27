using System;

namespace BookShop.DAL.Core {
  public abstract class BaseEntity {

    public BaseEntity() {
      this.CreationDate = DateTime.Now;
      this.IsDeleted = false;

    }

    public int Id { get; set; }
    public int CreationUser { get; set; }
    public DateTime CreationDate { get; set; }
    public int? ModificationUser { get; set; }
    public DateTime? ModificationDate { get; set; }
    public int? DeletionUser { get; set; }
    public DateTime? DeletionDate { get; set; }
    public bool IsDeleted { get; set; }

  }
}
