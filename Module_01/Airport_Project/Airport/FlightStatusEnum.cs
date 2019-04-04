using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Airport
{    public enum FlightStatus
    {
        [Description("Check In")]
        CHECK_IN,

        [Description("Gate Closed")]
        GATE_CLOSED,

        [Description("Arrived")]
        ARRIVED,

        [Description("Departed at")]
        DEPARTED_AT,

        [Description("Uknown")]
        UNKNOWN,

        [Description("Cancelled")]
        CANCELLED,

        [Description("Expected at")]
        EXPECTED_AT,

        [Description("Delayed")]
        DELAYED,

        [Description("In Flight")]
        IN_FLIGHT
    }
    
}
