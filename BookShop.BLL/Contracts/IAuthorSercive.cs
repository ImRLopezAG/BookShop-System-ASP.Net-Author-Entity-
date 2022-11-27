using BookShop.BLL.Core;
using BookShop.BLL.DTOS.Author;
using BookShop.BLL.Responses.Author;

namespace BookShop.BLL.Contracts {
  public interface IAuthorService : IBaseService {

    AuthorSaveResponse SaveAuthor(AuthorSaveDto saveAuthor);
    ServiceResult DeleteAuthor(AuthorDeleteDto deleteAuthor);
    AuthorUpdateResponse Update(AuthorUpdateDto updateAuthor);

    ServiceResult AuthorBooks();
  }
}
