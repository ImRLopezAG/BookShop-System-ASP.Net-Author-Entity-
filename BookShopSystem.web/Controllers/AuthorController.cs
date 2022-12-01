using BookShop.BLL.Contracts;
using BookShop.BLL.DTOS.Author;
using BookShopSystem.web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookShopSystem.web.Controllers
{
  public class AuthorController : Controller
  {
    // GET: AuthorController
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
      _authorService = authorService;
    }

    public ActionResult Index()
    {
      var authorsArray = ((List<BookShop.BLL.Model.AuthorModel>)_authorService.GetAll().Data).ConvertToAuthorModel();
      return View(authorsArray);
    }
    public ActionResult EditAuthorList()
    {
      var authorsArray = ((List<BookShop.BLL.Model.AuthorModel>)_authorService.GetAll().Data).ConvertToAuthorModel();
      return View(authorsArray);
    }

    // GET: AuthorController/Details/5
    public ActionResult Details(int id)
    {
      var authorModel = ((BookShop.BLL.Model.AuthorModel)_authorService.GetById(id).Data).GetModel();
      return View(authorModel);
    }

    // GET: AuthorController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: AuthorController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        AuthorSaveDto saveAuthorDto = new AuthorSaveDto()
        {
          FirstName = collection["FirstName"],
          LastName = collection["LastName"],
          Email = collection["Email"],
          Biography = collection["Biography"],
          CreationDate = System.DateTime.Now,
        };
        _authorService.SaveAuthor(saveAuthorDto);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: AuthorController/Edit/5
    public ActionResult Edit(int id)
    {

      var authorModel = ((BookShop.BLL.Model.AuthorModel)_authorService.GetById(id).Data).GetModel();
      return View(authorModel);
    }

    // POST: AuthorController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        AuthorUpdateDto updateAuthorDto = new AuthorUpdateDto()
        {
          Id = id,
          FirstName = collection["FirstName"],
          LastName = collection["LastName"],
          Email = collection["Email"],
          Biography = collection["Biography"],

        };
        _authorService.Update(updateAuthorDto);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: AuthorController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: AuthorController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        AuthorDeleteDto deleteAuthorDto = new AuthorDeleteDto()
        {
          Id = id
        };
        _authorService.DeleteAuthor(deleteAuthorDto);
        return RedirectToAction(nameof(EditAuthorList));
      }
      catch
      {
        return View();
      }
    }
  }
}
