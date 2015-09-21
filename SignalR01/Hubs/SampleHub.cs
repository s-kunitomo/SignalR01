using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR01.Hubs
{
    [HubName("sampleHub")]
    public class SampleHub : Hub
    {
        static int valueCount;

        public void GetValue()
        {
            valueCount += 1;
            base.Clients.All.onUpdate(valueCount);
        }
    }
}