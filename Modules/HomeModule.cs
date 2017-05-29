using Nancy;
using FavoriteMusic.Objects;
using System.Collections.Generic;

namespace FavoriteMusic
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        var allCategories = Category.GetAllCategories();
        return View["index.cshtml", allCategories];
      };
      Get["/categories"] = _ => {
        var allCategories = Category.GetAllCategories();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["categories"] = _ => {
        var newCategory = new Category(Request.Form["category-name"]);
        var allCategories = Category.GetAllCategories();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryAlbums = selectedCategory.GetAlbums();
        model.Add("category", selectedCategory);
        model.Add("albums", categoryAlbums);
        return View["category.cshmtl", model];
      };
      Get["/albums"] = _ => {
        var allAlbums = Album.GetAllAlbums();
        return View["albums.cshtml", allAlbums];
      };
      Get["/albums/{id}"] = parameters => {
        var selectedAlbum = Album.Find(parameters.id);
        return View["album.cshtml", selectedAlbum];
      };
    }
  }
}
