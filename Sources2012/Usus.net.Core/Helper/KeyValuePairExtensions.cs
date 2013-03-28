using System.Collections.Generic;

namespace andrena.Usus.net.Core.Helper
{
    public static class KeyValuePairExtensions
    {
        public static KeyValuePair<K, V> WithValue<K, V>(this K key, V value)
        {
            return new KeyValuePair<K, V>(key, value);
        }
    }
}