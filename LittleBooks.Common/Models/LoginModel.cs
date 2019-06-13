using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.Common.Models
{
    public class LoginModel
    {
        [DisplayName("ელ.ფოსტა")]
        [DataType(DataType.EmailAddress, ErrorMessage = "შემოიტანეთ სწორი ელ.ფოსტა")]
        [Required(ErrorMessage = "შეიყვანეთ ელ.ფოსტა")]
        public string Email { get; set; }


        [DisplayName("პაროლი")]
        [Required(ErrorMessage = "შეიყვანეთ პაროლი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
