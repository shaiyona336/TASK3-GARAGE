using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : base(i_Message)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : this($"The given value must be a number between {i_MinValue} and {i_MaxValue}.", i_MinValue, i_MaxValue)
        {
        }

        public ValueOutOfRangeException(string i_Message, Exception i_InnerException,
            float i_MinValue, float i_MaxValue) : base(i_Message, i_InnerException)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
