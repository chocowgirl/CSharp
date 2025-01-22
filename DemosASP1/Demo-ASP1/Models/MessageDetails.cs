namespace Demo_ASP1.Models
{
    public class MessageDetails
    {
        public PersonneDetails Sender { get; set; }
        public PersonneDetails Receiver { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsReceived { get; set; }
        public string Content { get; set; }
    }



}
