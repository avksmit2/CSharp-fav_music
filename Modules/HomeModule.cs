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
    }
  }
}
