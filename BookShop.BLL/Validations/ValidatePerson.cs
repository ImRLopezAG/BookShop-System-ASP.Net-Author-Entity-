using BookShop.BLL.Core;
using BookShop.BLL.Core.DTOS;

namespace BookShop.BLL.Validations {
  public static class ValidatePerson {
    public static ServiceResult IsValidPerson(PersonBaseDto person) {
      ServiceResult result = new ServiceResult();

      if (string.IsNullOrEmpty(person.FirstName)) {
        result.Success = false;
        result.Message = "El nombre  deber ser requerido.";
        return result;
      }

      if (string.IsNullOrEmpty(person.LastName)) {
        result.Success = false;
        result.Message = "El apellido  deber ser requerido.";
        return result;
      }

      if (person.FirstName.Length > 25) {
        result.Success = false;
        result.Message = "La longitud del nombre deber ser menor de 25 caracteres.";
        return result;
      }

      if (person.LastName.Length > 25) {
        result.Success = false;
        result.Message = "La longitud del apellido deber ser menor de 25 caracteres.";
        return result;
      }
      if (string.IsNullOrEmpty(person.Email)) {
        result.Success = false;
        result.Message = "El correo es requerido";
        return result;
      }
      if (!person.Email.Contains("@")) {
        result.Success = false;
        result.Message = "Correo Invalido";
        return result;
      }

      return result;
    }

  }
}
