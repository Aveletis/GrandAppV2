using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandAppV2.Models.Data
{
    public class Reservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите дату заезда")]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivaldateTime { get; set; }

        [Required(ErrorMessage = "Введите дату выезда")]
        [Display(Name = "Дату выезда")]
        public DateTime DeparturedateTime { get; set; }

        [Required(ErrorMessage = "Введите кол-во гостей")]
        [Display(Name = "Кол-во гостей")]
        public byte NumberGuests { get; set; }

        
        [Required]
        [Display(Name = "Номер")]
        public byte IdRoom { get; set; }

        [Display(Name = "Номер")]
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }


        [Required]
        [Display(Name = "Пользователь")]
        public string IdUser { get; set; }

        [Display(Name = "Пользователь")]
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
