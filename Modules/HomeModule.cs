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
        return View["index.cshtml"];
      };
      Get["/albums"] = _ => {
        var allAlbums = Album.GetAllAlbums();
        return View["albums.cshtml", allAlbums];
      }
      Get["/albums/{id}"] = parameters => {
        var selectedAlbum = Album.Find(parameters.id);
        return View["album.cshtml", selectedAlbum];
      }
    }
  }
}
