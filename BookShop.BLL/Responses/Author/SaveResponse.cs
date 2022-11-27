using BookShop.BLL.Core;

namespace BookShop.BLL.Responses.Author {
  public class AuthorSaveResponse : ServiceResult {
    public int AuthorId { get; set; }
  }
}
