using BookShop.BLL.Core.DTOS;

namespace BookShop.BLL.DTOS.Author {
  public class AuthorDeleteDto : PersonBaseDto {
    public int UserId { get; set; }
  }
}
