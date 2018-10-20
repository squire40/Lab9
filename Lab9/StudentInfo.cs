using System.Diagnostics;

namespace Lab9
{
    [DebuggerDisplay("Name {Name}, Hometown {Hometown}, FavoriteFood {FavoriteFood}, FavoriteAnimal {FavoriteAnimal}")]
    public class StudentInfo
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteAnimal { get; set; }
    }
}
