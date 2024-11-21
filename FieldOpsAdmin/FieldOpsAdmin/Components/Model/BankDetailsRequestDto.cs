namespace FieldOpsAdmin.Components.Model
{
    public class BankDetailsRequestDto
    {
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public int? BankId { get; set; }
        public string OtherBankName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountType { get; set; }
        public string OtherAccountType { get; set; }

    }
}
