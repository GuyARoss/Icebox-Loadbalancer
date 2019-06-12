using System;
using System.IO;
using System.Collections.Generic;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Icebox.Infrastructure
{
    public class PersistentDictionary<TValue> : IDisposable
    {
        private readonly Dictionary<int, TValue> _dict;
        private readonly string _dicName;

        public PersistentDictionary(string name) {
            _dicName = name;
            _dict = _deserialize();
        } 

        public TValue this[int idx]
        {
            get { return _dict[idx];  }
            set { _dict[idx] = value;  }
        }

        public int Count { get => _count(); }

        public void Add(int key, TValue value)
        {
            _dict.Add(key, value);
        }

        private int _count()
        {
            return _dict.Count;
        }

        private void _serialize()
        {
            var fs = new FileStream(string.Format("{0}.dat", _dicName), FileMode.Create);

            var formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, _dict);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
            }
        }

        private Dictionary<int, TValue> _deserialize()
        {
            var tempDic = new Dictionary<int, TValue>();

            string fileName = string.Format("{0}.dat", _dicName);


            if (!File.Exists(fileName))
            {
                using (var nFile = File.Create(fileName)) { }                
            } else
            {
                var fs = new FileStream(fileName, FileMode.Open);
                try
                {
                    var formatter = new BinaryFormatter();

                    tempDic = formatter.Deserialize(fs) as Dictionary<int, TValue>;
                }
                catch (SerializationException e)
                {
                    throw e;
                }
                finally
                {
                    fs.Close();
                }
            }


            return tempDic;
        }

        public void Dispose()
        {
            _serialize();
        }
    }
}
