using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    /// <summary>
    /// Класс описывает таблицу частот
    /// </summary>
    class FrequencyTable : IEnumerable<KeyValuePair<string, double>>
    {
        public Dictionary<string, double> Table;

        public FrequencyTable()
        {
            Table = new Dictionary<string, double>();
        }

        public FrequencyTable(Dictionary<string, double> dict)
        {
            Table = dict;
        }

        public void Add(string letter, double frequency)
        {
            Table.Add(letter, frequency);
        }

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, double>>)Table).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, double>>)Table).GetEnumerator();
        }
    }

    class InvalidKeyException : Exception
    {
        public string Value;
        public InvalidKeyException (string message, string value) : base(message)
        {
            this.Value = value;
        }
    }

}
