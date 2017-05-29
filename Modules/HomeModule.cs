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
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/albums/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Album> allAlbums = selectedCategory.GetAlbums();
        model.Add("category", selectedCategory);
        model.Add("albums", allAlbums);
        return View["category_albums_form.cshtml", model];
      };
      Post["/albums"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Album> categoryAlbums = selectedCategory.GetAlbums();
        string albumTitle = Request.Form["album-title"];
        string albumArtist = Request.Form["album-artist"];
        Album newAlbum = new Album(albumTitle, albumArtist);
        categoryAlbums.Add(newAlbum);
        model.Add("albums", categoryAlbums);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
      Get["/albums"] = _ => {
        var allAlbums = Album.GetAllAlbums();
        return View["albums.cshtml", allAlbums];
      };
      Get["/album/{id}"] = parameters => {
        var selectedAlbum = Album.Find(parameters.id);
        return View["album.cshtml", selectedAlbum];
      };
    }
  }
}
