using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Track
    {


        public int ID { get; set; }
        
        [StringLength(80,ErrorMessage ="Not Valid String Length")]
        [Required]
        public string  Name {get;set;}


        [StringLength(250, ErrorMessage =",Not Valid String Length")]
        public string  Description {get;set;}


        public virtual ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
    }
}
