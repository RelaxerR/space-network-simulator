namespace Satellites
{
    public class Aerial
    {
        public Socket Socket { get; } = new Socket();

        public void ReceiveMessage(string message)
        {
            // Handle received message (for now, just log or store)
            UnityEngine.Debug.Log($"Aerial received: {message}");
        }
    }
}