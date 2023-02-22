namespace Restaurant.Services.Email.Modules
{
    public class EmailLog
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Log { get; set; }
        public DateTime EmailSent { get; set; }
    }
}
