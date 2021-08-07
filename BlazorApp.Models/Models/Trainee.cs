using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Trainee : ICloneable
    {

        public int ID { get; set; }

        [StringLength(40, ErrorMessage =",Not Valid String Length")]
        [Required]
        public string Name {get; set;}

        [Required]
        public Gender Gender {get; set;}

        [StringLength(40, ErrorMessage =",Not Valid email String Length")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email {get; set;}

        [StringLength(14, ErrorMessage =",Not Valid mobile String Length")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo {get; set;}


        public DateTime Birthdate {get; set;}
        
        
        public bool IsGraduated {get; set;}


        public int TrackId { get; set; }

        public Track Track { get; set; }

        public object Clone()
        {
            return new Trainee()
            {
                ID = this.ID,
                Name = this.Name,
                Gender = this.Gender,
                email = this.email,
                MobileNo = this.MobileNo,
                Birthdate = this.Birthdate,
                IsGraduated = this.IsGraduated,
                Track = this.Track,
            };
        }
    }
}
