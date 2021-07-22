using Task1.Models;

namespace Task1.Services
{
    class SongService : ISongService
    {
        public object GetSongData(Song song)
        {
            if (song is null)
                return null;

            return new
            {
                Title = song.Name,
                Minutes = song.Duration,
                AlbumYear = song.CreationDate.Year
            };
        }
    }
}
