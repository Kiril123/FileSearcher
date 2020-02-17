using System;
using System.IO;
using System.Xml.Serialization;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Saves given objects to xml file.
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class XMLSaver<T>
    {
        /// <summary>
        /// Saves the object to xml.
        /// </summary>
        /// <param name="obj">Object to save.</param>
        /// <param name="path">Path to file.</param>
        public void Save(T obj,string path)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, obj);
            }
        }
        /// <summary>
        /// Loads the object from an xml file.
        /// </summary>
        /// <returns>Loaded object.</returns>
        public T Load(string path)
        {
            T result = default(T);
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    object data = deserializer.Deserialize(file);
                    if (data != null && data is T)
                    {
                        result = ((T)data);
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
