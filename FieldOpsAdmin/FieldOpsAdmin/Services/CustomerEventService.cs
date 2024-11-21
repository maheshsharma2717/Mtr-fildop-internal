namespace FieldOpsAdmin.Services
{
    public class CustomerEventService
    {
        public event Action OnCustomerAdded;

        public void NotifyCustomerAdded()
        {
            OnCustomerAdded?.Invoke();
        }
    }
}
