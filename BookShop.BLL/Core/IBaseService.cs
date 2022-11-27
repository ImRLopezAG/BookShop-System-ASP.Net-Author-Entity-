namespace BookShop.BLL.Core {
  public interface IBaseService {
    ServiceResult GetAll();
    ServiceResult GetById(int id);
  }
}
