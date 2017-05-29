using System.Collections.Generic;

namespace FavoriteMusic.Objects
{
  public class Category
  {
    private string _name;
    private int _categoryId;
    private static List<Category> _instances = new List<Category> {};
    private List<Album> _albums;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _categoryId = _instances.Count;
      _albums = new List<Album>{};
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _categoryId;
    }
    public List<Album> GetAlbums()
    {
      return _albums;
    }
    public void AddAlbum(Album album)
    {
      _albums.Add(album);
    }
    public static List<Category> GetAllCategories()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
