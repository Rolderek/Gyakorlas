namespace Gyakorlas.Services
{
    public class StateService
    {
        private List<string> messages = new List<string>();

        public event Action OnChange;

        public IEnumerable<string> GetMessage() => messages;

        //ha változik akkor szóljál kérlek:
        private void NotifyStateChanged() => OnChange?.Invoke();

        //tedd bele a listába az új elemet és szóljál hogy változott:
        public void AddMessage(string m)
        {
            messages.Add(m);
            NotifyStateChanged();
        }
    }
}
