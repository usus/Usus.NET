using System;

namespace andrena.Usus.net.View.ViewModels
{
    public abstract class ValueInTime
    {
        public bool GotLower { get; protected set; }
        public bool GotHigher { get; protected set; }
    }

    public class ValueInTime<T> : ValueInTime where T : IComparable
    {
        T _value;
        Func<T, string> _toString;

        public ValueInTime(T value)
            : this(value, n => n.ToString())
        { }

        public ValueInTime(T value, Func<T, string> toString)
        {
            _value = value;
            _toString = toString;
        }

        public void Update(T newValue)
        {
            GotLower = newValue.CompareTo(_value) < 0;
            GotHigher = newValue.CompareTo(_value) > 0;
            _value = newValue;
        }

        public override string ToString()
        {
            return _toString(_value);
        }
    }
}