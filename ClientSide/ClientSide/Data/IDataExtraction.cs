using System;

namespace ClientSide.Data
{
    public interface IDataExtraction
    {
        event EventHandler<INotificationEntity> NewNotification;
    }
}