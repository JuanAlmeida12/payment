using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace braspag.Models
{
    public class HomeForm
    {
        [Required(ErrorMessage = "Id deve ser informado")]
        [DisplayName("Id do pagamento")]
        public string paymentId { get; set; }

    }
}