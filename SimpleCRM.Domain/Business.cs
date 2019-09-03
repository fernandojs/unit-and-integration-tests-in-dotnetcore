using FluentValidation.Results;
using Simple_CRM.Domain.Validations;


namespace Simple_CRM.Domain
{
    public class Business
    {
        public ValidationResult ValidationResult { get; protected set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public bool Status { get; set; }

        public Business(int Id, string Name, string Email, string Site, bool Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Site = Site;
            this.Status = Status;
        }

        public bool IsValid()
        {
            ValidationResult = new BusinessValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
