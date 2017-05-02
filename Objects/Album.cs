using System.Collections.Generic;

namespace FavoriteMusic.Objects
{
  public class Album
  {
    private string _title;
    private string _artist;
    private int _albumId;
    private static List<Album> _albums = new List<Album> {};

    public Album(string title, string artist)
    {
      _title = title;
      _artist = artist;
      _albumId = _albums.Count;
      _albums.Add(this);
    }
    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }
    public string GetArtist()
    {
      return _artist;
    }
    public void SetArtist(string newArtist)
    {
      _artist = newArtist;
    }
    public int GetAlbumId()
    {
      return _albumId;
    }
    public static List<Album> GetAllAlbums()
    {
      return _albums;
    }
    public static Album Find(int searchID)
    {
      return _albums[searchID-1];
    }
  }
}
