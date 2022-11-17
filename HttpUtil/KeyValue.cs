using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.HttpUtil
{
    class KeyValue
    {
        public string Key;
        public string Value;
        public string FilePath;
        public string ContentType = "*/*";

        public KeyValue(string key, string value, string filePath, string contentType)
        {
            Key = key;
            Value = value;
            FilePath = filePath;
            ContentType = contentType;
        }

        public KeyValue() { }

        public KeyValue(string key, string value, string filePath)
        {
            Key = key;
            Value = value;
            FilePath = filePath;
        }

        public KeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

}
