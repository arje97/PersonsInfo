using Core.Domain;
namespace Core.Application.Dtos
{
    public class PhoneNumberDto
    {
        public NumberType NumberType { get; set; }
       // public string NumberType { get; set; }
        public string Number { get; set; }
    }
}
