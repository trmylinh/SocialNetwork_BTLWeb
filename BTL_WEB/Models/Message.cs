namespace BTL_WEB.Models;

public partial class Message
{
    public int Id { get; set; }

    public string Message1 { get; set; } = null!;

    public DateTime SentDatetime { get; set; }

    public int GroupId { get; set; }

    public int SenderId { get; set; }

    public virtual ChatGroup Group { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
