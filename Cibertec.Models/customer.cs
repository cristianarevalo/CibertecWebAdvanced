namespace Cibertec.Models
{
    public class customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        //el tipo String es un objeto y ocupa mas memoria
        //el tipo string solo almacena el valor y es un puntero en memoria
        //control punto enter para eliminar lo que no sirve
    }
}
