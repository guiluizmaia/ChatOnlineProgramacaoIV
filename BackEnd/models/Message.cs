using System.ComponentModel.DataAnnotations;

namespace backend.models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo name é obrigatorio")]
        public string name { get; set; }

        [Required(ErrorMessage = "o campo nickname é obrigatorio")]
        public string nickname { get; set; }

        [Required(ErrorMessage = "o campo mail é obrigatorio")]
        public string mail { get; set; }

        [Required(ErrorMessage = "o campo msg é obrigatorio")]
        public string message { get; set; }

    }
}