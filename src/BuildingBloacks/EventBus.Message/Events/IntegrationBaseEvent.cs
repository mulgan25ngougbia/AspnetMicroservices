using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedTime = DateTime.UtcNow;
        }
        public IntegrationBaseEvent(Guid guid, DateTime createdTime)
        {
            Id = guid;
            this.CreatedTime = createdTime;
        }
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }

        
    }
}
