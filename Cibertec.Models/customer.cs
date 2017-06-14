using System.ComponentModel.DataAnnotations;

namespace Cibertec.Models
{
    public class customer
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        //el tipo String es un objeto y ocupa mas memoria
        //el tipo string solo almacena el valor y es un puntero en memoria
        //control punto enter para eliminar lo que no sirve
    }
}
