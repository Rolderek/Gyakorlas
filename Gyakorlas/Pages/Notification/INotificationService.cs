using System;
using System.Threading.Tasks;

namespace Gyakorlas.Pages.Notification
{
    public interface INotificationService
    {
        event Action<string> OnNotificationReceived;
        event Action<TodoItem> OnTodoChanged;

        Task StartAsync();
        Task SendNotificationToAllAsync(string message);
        Task SendNotificationToUserAsync(string userId, string message);
        Task SendTodoChangedAsync(TodoItem item);
    }
}