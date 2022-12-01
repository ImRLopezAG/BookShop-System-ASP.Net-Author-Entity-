
using BookShopSystem.web.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShopSystem.web.Extensions {
  public static class AuthorExtension {

    public static List<AuthorModel> ConvertToAuthorModel(this List<BookShop.BLL.Model.AuthorModel> authorModel) {

      var myAuthors = authorModel.Select(author => new AuthorModel() {
        Id = author.Id,
        FirstName = author.FirstName,
        LastName = author.LastName,
        Biography = author.Biography,
        Email = author.Email,
      }).ToList();
      return myAuthors;
    }

    public static AuthorModel GetModel(this BookShop.BLL.Model.AuthorModel authorModel) {
      return new AuthorModel() {
        Id = authorModel.Id,
        FirstName = authorModel.FirstName,
        LastName = authorModel.LastName,
        Biography = authorModel.Biography,
        Email = authorModel.Email,
      };
    }

  }
}

