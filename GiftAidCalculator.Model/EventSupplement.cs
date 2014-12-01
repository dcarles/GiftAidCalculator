using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Model
{
    public class EventSupplement : IEntity
    {
        private readonly EventType _eventType;
        private readonly int _supplementRate;

        public EventType EventType { get { return _eventType; } }
        public int SupplementRate { get { return _supplementRate; } }


        private EventSupplement() { }  //the private constructor
        public EventSupplement(EventType eventType, int supplementRate)
        {
            _eventType = eventType;
            _supplementRate = supplementRate;
        }

        public override string ToString()
        {
            return _supplementRate + "% will be added to " + _eventType + " events";
        }

        #region IEntity Members

        public int Id { get; set; }

        #endregion
    }

    public enum EventType
    {
        Running = 1,
        Swimming = 2,
        Other = 3
    }
}
