namespace FieldOpsAdmin.Models.Dto
{
    public class UserRequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public int DomainId { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int? ServiceCategoryId { get; set; }
        public float YearOfExperience { get; set; }
        public string ProfileUrl { get; set; }
        public IFormFile? ProfilePic { get; set; }
    }
}
