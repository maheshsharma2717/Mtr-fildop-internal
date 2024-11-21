namespace FieldOpsAdmin.Components.Model
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? ProfileUrl { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Rating { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public bool IsDeleted { get; set; }
        public string? Key { get; set; }

    }
}
