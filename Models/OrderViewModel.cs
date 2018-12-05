using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace braspag.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "O valor deve ser Informado")]
        [DisplayName("Valor da transação")]
        public float amount { get; set; }

        [Required(ErrorMessage = "O numero do cartão deve ser Informado")]
        [DisplayName("Numero do cartão")]
        [CreditCard(ErrorMessage = "Cartão Invalido")]
        public string cardNumber { get; set; }

        [Required(ErrorMessage = "O Nome impresso no cartão deve ser Informado")]
        [DisplayName("Nome Impresso no cartão")]
        public string holder { get; set; }

        [Required(ErrorMessage = "A data de vencimento do cartão deve ser Informada")]
        [DisplayName("Data de vencimento do cartão")]
        [RegularExpression(@"^\d{1,2}\/\d{4}$", 
         ErrorMessage = "Formato de data Invalido.")]
        public string expirationDate { get; set; }

        [Required(ErrorMessage = "O código de segurança do cartão deve ser Informado")]
        [DisplayName("Código de segurança do cartão")]
        [Range(100,999)]
        public string securityCode { get; set; }

        [Required(ErrorMessage = "A bandeira do cartão deve ser Informada")]
        [DisplayName("Bandeira do cartão")]
        public string brand { get; set; }

        public string toJson()
        {
            
            return JsonConvert.SerializeObject(new {
                MerchantOrderId= "ba6ce2f7-d8ab-4fb3-9065-d280736154fc",
                Customer= new {
                    Name= holder
                },
                Payment= new {
                    Provider= "Simulado",
                    Type= "CreditCard",
                    Amount= amount,
                    Capture= true,
                    Installments= 1,
                    CreditCard= new {
                        CardNumber= cardNumber,
                        Holder= holder,
                        ExpirationDate= expirationDate,
                        SecurityCode= securityCode,
                        Brand= brand
                    }
                }

            });
        }
    }
}