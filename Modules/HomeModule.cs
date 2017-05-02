using Nancy;
using FavoriteMusic.Objects;
using System.Collections.Generic;
using FavoriteMusic.Objects;

namespace FavoriteMusic
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
    }
  }
}
