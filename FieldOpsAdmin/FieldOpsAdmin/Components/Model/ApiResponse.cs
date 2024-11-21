namespace FieldOpsAdmin.Components.Model
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponseBank<T>
    {
        public List<T> Result { get; set; }  
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResponseDto
    {
        public AuthResponseDto? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public float? YearOfExperience { get; set; }
        public int? Rating { get; set; }
        public string ProfileUrl { get; set; }
        public decimal? TotalMoneySpent { get; set; }
        public int ServicesRequested { get; set; }
        public int TotalServiceDelivered { get; set; }
        public int DomainId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsOnline { get; set; }
        public List<string> Reviews { get; set; }
    }

}
