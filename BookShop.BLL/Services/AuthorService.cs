using BookShop.BLL.Contracts;
using BookShop.BLL.Core;
using BookShop.BLL.DTOS.Author;
using BookShop.BLL.Model;
using BookShop.BLL.Responses.Author;
using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces;
using System;
using System.Linq;

namespace BookShop.BLL.Services {
  public class AuthorService : IAuthorService {
    private readonly IAuthorRepository authorRepository;
    private readonly ILoggerService<AuthorService> loggerService;
    public AuthorService(IAuthorRepository _authorRepository, ILoggerService<AuthorService> _loggerService) {
      this.authorRepository = _authorRepository;
      this.loggerService = _loggerService;
    }

    public ServiceResult AuthorBooks() {
      ServiceResult result = new ServiceResult();
      //try {
      //  var query = from author in authorRepository.GetEntities()
      //              join book in bookRepository.GetEntities() on author.Id equals book.AuthorId
      //              select new {
      //                author.Id,
      //                author.Name,
      //                author.Surname,
      //                author.BirthDate,
      //                book.Title,
      //                book.Stock
      //              };
      //} catch (Exception ex) {
      //  result.Success = false;
      //  result.Message = ex.Message;
      //  loggerService.LogError(ex.Message);
      //}
      return result;
    }

    public ServiceResult DeleteAuthor(AuthorDeleteDto deleteAuthor) {
      ServiceResult result = new ServiceResult();
      try {
        var query = from author in authorRepository.GetEntities()
                    where author.Id == deleteAuthor.Id
                    select author;
        var authorToDelete = query.FirstOrDefault();
        if (authorToDelete == null) {
          result.Message = "No se encontró el autor";
          return result;
        } else {
          authorRepository.Remove(authorToDelete);
          result.Success = true;
          result.Message = "Autor eliminado correctamente";
        }
        authorRepository.Remove(authorToDelete);
      } catch (Exception ex) {
        result.Message = "Error deleting author";
        loggerService.LogError(result.Message, ex);
      }
      return result;
    }

    public ServiceResult GetAll() {
      ServiceResult result = new ServiceResult();
      try {
        var query = (from author in authorRepository.GetEntities()
                     select new AuthorModel {
                       Id = author.Id,
                       FirstName = author.FirstName,
                       LastName = author.LastName,
                       Biography = author.Biography,
                     }).ToList();
        result.Data = query;
      } catch (Exception ex) {
        result.Success = false;
        result.Message = ex.Message;
        loggerService.LogError(ex.Message);
      }
      return result;
    }
    public ServiceResult GetById(int Id) {
      ServiceResult result = new ServiceResult();
      try {
        var query = (from author in authorRepository.GetEntities()
                     where author.Id == Id
                     select new AuthorModel {
                       Id = author.Id,
                       FirstName = author.FirstName,
                       LastName = author.LastName,
                       Biography = author.Biography,
                     }).FirstOrDefault();
        result.Data = query;
      } catch (Exception ex) {
        result.Success = false;
        result.Message = ex.Message;
        loggerService.LogError(ex.Message);
      }
      return result;
    }
    public AuthorSaveResponse SaveAuthor(AuthorSaveDto saveAuthor) {
      AuthorSaveResponse result = new AuthorSaveResponse();
      try {
        var resultIsValid = Validations.ValidatePerson.IsValidPerson(saveAuthor);
        if (resultIsValid.Success) {
          if (authorRepository.Exists(x => x.FirstName == saveAuthor.FirstName && x.LastName == saveAuthor.LastName)) {
            result.Success = false;
            result.Message = "El autor ya existe";
            return result;
          }
          Author author = new Author {
            FirstName = saveAuthor.FirstName,
            LastName = saveAuthor.LastName,
            Biography = saveAuthor.Biography,
          };
        } else {
          result.Success = false;
          result.Message = resultIsValid.Message;
          return result;
        }
      } catch (Exception ex) {
        result.Message = $"Error al guardar el autor: {ex.Message}";
        this.loggerService.LogError(result.Message, ex.ToString());
      }

      return result;
    }

    public AuthorUpdateResponse Update(AuthorUpdateDto updateAuthor) {
      AuthorUpdateResponse result = new AuthorUpdateResponse();
      try {
        var query = from author in authorRepository.GetEntities()
                    where author.Id == updateAuthor.Id
                    select author;
        var authorToUpdate = query.FirstOrDefault();
        if (authorToUpdate == null) {
          result.Message = "No se encontró el autor";
          return result;
        } else {
          authorToUpdate.FirstName = updateAuthor.FirstName;
          authorToUpdate.LastName = updateAuthor.LastName;
          authorToUpdate.Biography = updateAuthor.Biography;
          authorRepository.Update(authorToUpdate);
          result.Success = true;
          result.Message = "Autor actualizado correctamente";
        }
      } catch (Exception ex) {
        result.Message = "Error updating author";
        loggerService.LogError(result.Message, ex);
      }
      return result;
    }
  }
}
