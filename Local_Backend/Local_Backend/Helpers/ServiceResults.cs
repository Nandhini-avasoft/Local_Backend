namespace Local_Backend.Helpers
{
    public enum ServiceStatus
    {
        Success,
        Invalid,
        Failed
        
    }
    public class ServiceResults<T>
    {
        public ServiceStatus Status { get; set; }
        public string message { get; set; }
        public T content { get; set; }
    }
}
