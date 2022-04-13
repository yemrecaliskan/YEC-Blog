using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını boş bırakmayınız.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi boş bırakmayınız.")]
        public string Password { get; set; }
    }
}
