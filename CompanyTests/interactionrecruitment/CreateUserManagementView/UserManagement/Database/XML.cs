using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace UserManagement.Database
{
    public static class XML
    {
        public static void Save<T>( T instance )
        {
            var classType = typeof(T);

            var className = typeof (T).IsSerializable
                ? $"ListOf{typeof(T).GetGenericArguments().First().Name}"
                : typeof (T).Name;

            var fileName = $@"Database\{className}.xml";

            Debug.WriteLine($"Info: Write to file: {fileName} from instance of: {classType}");

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                OmitXmlDeclaration = true
            };

            var xmlDictionary = new XmlDictionary();
            var settings2 = new DataContractSerializerSettings
            {
                RootName = xmlDictionary.Add(className),
                RootNamespace = xmlDictionary.Add("Data")
            };
            
            using (var w = XmlWriter.Create(fileName, settings))
            {
                var serializer = new DataContractSerializer(classType, settings2);

                serializer.WriteObject(w, instance);
            }
        }

        public static T Load<T>() where T : new()
        {
            var classType = typeof (T);

            var className = typeof (T).IsSerializable
                ? $"ListOf{typeof (T).GetGenericArguments().First().Name}"
                : typeof (T).Name;

            var fileName = $@"Database\{className}.xml";

            Debug.WriteLine($"Info: Read from file: {fileName} to instance of: {classType}");

            //verify readibility of xml, if failed reinstate
            if (File.Exists(fileName) == false)
            {
                Debug.WriteLine($"{fileName} does not exist. Saving initial class.");
                Save(new T());
            }

            var instance = default(T);

            var xmlDictionary = new XmlDictionary();
            var settings2 = new DataContractSerializerSettings
            {
                RootName = xmlDictionary.Add(className),
                RootNamespace = xmlDictionary.Add("Data")
            };
            
            using (var fs = File.Open(fileName, FileMode.Open))
            {
                var deserializer = new DataContractSerializer(classType, settings2);

                try
                {
                    instance = (T) deserializer.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                    //todo: handle errors while reading from file
                }    
        
                Debug.WriteLine(instance == null
                    ? $" Deserialized object is null (Nothing in VB)"
                    : $" Deserialized type: {instance.GetType()}");
            }

            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            return instance != null ? instance : new T();
        }
    }
}