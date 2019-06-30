using System;
using System.ComponentModel;

namespace MarsRovers.Entities.Enums
{
    public enum Direction
    {
        [Description("0,1")]
        N,
        [Description("1,0")]
        E,
        [Description("0,-1")]
        S,
        [Description("-1,0")]
        W
    }
}
