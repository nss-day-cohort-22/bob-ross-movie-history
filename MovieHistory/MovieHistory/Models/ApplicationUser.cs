using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name ="First Name")]
        [StringLength(55, ErrorMessage ="Please enter your nickname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(55, ErrorMessage ="Sorry, too long")]
        public string LastName { get; set; }

        public virtual ICollection<Recommendation> Recommendations { get; set; }

        public virtual ICollection<MovieUser> MovieUsers { get; set; }
    }
}
