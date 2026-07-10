using System;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.BroadcastChannel;

namespace Gyakorlas.Pages.Notification
{
    public class NotificationService : IAsyncDisposable
    {
        private readonly IBroadcastChannelService _broadcastChannelService;
        private IBroadcastChannel? _channel;

        public event Action<string>? OnNotificationReceived;

        public NotificationService(IBroadcastChannelService broadcastChannelService)
        {
            _broadcastChannelService = broadcastChannelService;
        }

        public async Task InitializeAsync()
        {
            if (_channel == null)
            {
                _channel = await _broadcastChannelService.CreateOrJoinAsync("notification_channel");
                _channel.Message += OnMessageReceived;
            }
        }

        private void OnMessageReceived(object? sender, BroadcastChannelMessageEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data is JsonElement jsonElement)
                {
                    var message = jsonElement.GetString();
                    if (message != null)
                    {
                        OnNotificationReceived?.Invoke(message);
                    }
                }
                else
                {
                    var message = e.Data.ToString();
                    if (message != null)
                    {
                        OnNotificationReceived?.Invoke(message);
                    }
                }
            }
        }

        public async Task SendNotificationAsync(string message)
        {
            OnNotificationReceived?.Invoke(message);
            if (_channel != null)
            {
                await _channel.PostMessageAsync(message);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_channel != null)
            {
                _channel.Message -= OnMessageReceived;
                await _channel.DisposeAsync();
            }
        }
    }
}

/*
using System;

//az új cucchoz: https://www.nuget.org/packages/Blazor.BroadcastChannel

namespace Gyakorlas.Pages.Notification
{
    public class NotificationService
    {
        public event Action<string>? OnNotificationReceived;
        public event Action<TodoItem>? OnTodoChanged;

        public void SendNotification(string message)
        {
            OnNotificationReceived?.Invoke(message);
        }

        public void SendTodoChanged(TodoItem item)
        {
            OnTodoChanged?.Invoke(item);
        }
    }
}
*/