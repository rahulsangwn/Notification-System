using System;

namespace ClientSide.Data
{
    public interface INotificationEntity
    {
        DateTime Date { get; set; }
        int Id { get; set; }
        string Notification { get; set; }
        string Type { get; set; }
    }
}