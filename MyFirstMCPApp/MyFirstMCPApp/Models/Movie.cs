using System.ComponentModel.DataAnnotations;


namespace MyFirstMCPApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public string MLanguage { get; set; }= string.Empty;
        public string Hero { get; set; }= string.Empty;
        public string Director { get; set; }= string.Empty;
        public string MusicDirector { get; set; }= string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Cost { get; set;}
        public int MCollection { get; set; }
        public String Review { get; set; }= string.Empty;




    }


}

