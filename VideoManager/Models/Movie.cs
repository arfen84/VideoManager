using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoManager.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
    }

    public partial class VideoContext : DbContext
    {
        public VideoContext() : base("VideoDb")
        {
        }

        public DbSet<Movie> Movies { get; set; }

    }
}