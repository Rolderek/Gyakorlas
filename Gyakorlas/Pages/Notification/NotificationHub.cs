using Microsoft.AspNetCore.SignalR;

namespace Gyakorlas.Pages.Notification

{
    public class NotificationHub : Hub
    {
        public async Task SendNotifitacion(TodoItem item)
        {
            await Clients.All.SendAsync("TodoChanged", item);
        }

    }
}
