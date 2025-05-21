namespace Satellites
{
    public class Socket
    {
        public Aerial ConnectedAerial { get; private set; }

        public void Connect(Aerial aerial)
        {
            ConnectedAerial = aerial;
        }

        public void SendMessage(string message)
        {
            ConnectedAerial?.ReceiveMessage(message);
        }
    }
}