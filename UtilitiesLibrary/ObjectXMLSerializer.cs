using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;

namespace UtilitiesLibrary
{
    namespace XML
    {
        
        namespace Serialization
        {
            /// <summary>
            /// Serialization format types.
            /// </summary>
            public enum SerializedFormat
            {
                /// <summary>
                /// Binary serialization format.
                /// </summary>
                Binary,

                /// <summary>
                /// Document serialization format.
                /// </summary>
                XmlDocument
            }

            /// <summary>
            /// Facade to XML serialization and deserialization of strongly typed objects to/from an XML file.
            /// Binary serialization is a technique used to obtain a binary representation of an object,
            /// and then rebuild that object from it back to a real instance in memory.
            /// Serialization is a process that permits to convert the state of an object into a form
            /// that can be stored into some durable medium (file, DB) to rebuild original object in the 
            /// future or to send the object to another process or computer through network channels.
            /// Xml Serialization in .net, has probably a wrong name, because it does not really serialize 
            /// an object, it only create an XML stream with the content of all the public properties, 
            /// it does not store private fields, and it is not meant to create a stream to save object
            /// state into some durable medium. Xml Serialization is meant as a technique to read and 
            /// write XML stream to and from an object model. If you have a schema file,
            /// you can use xsd.exe tool to generate a set of classes that can be used to create in memory
            /// an object representation of a xml file that satisfies that schema.
            /// A great hint that Xml serialization has little to share with binary serialization is
            /// that XmlSerializer can serialize a class that is not marked as serializable.
            /// This is possible because XmlSerializer does not really serialize the object 
            /// it simply create a xml stream. If you have a class that simply dumps whenever
            /// the default constructor is called
            /// <example>
            /// public class Test3
            /// {
            ///     public Test3()
            /// {
            ///     Console.WriteLine("Test3Constructor Call");
            /// }
            /// /// public String Property { get; set; }
            /// when you deserialize an object with XmlSerializer you can see that this constructor gets called.
            /// If you deserialize an object with a BinaryFormatter the constructor is not called. 
            /// This is perfectly reasonable, since serialization is meant to convert an object 
            /// to a binary stream and back, so you cannot call the default constructor during 
            /// deserialization because you can end in having a different object from the original one. 
            /// Try this object
            /// public class Test4
            /// {
            ///  public Test4()
            ///  {
            ///  }
            ///  public Test4(String privateString)
            ///  {
            ///  this.privateString = privateString;
            ///  }
            ///  public String Property { get; set; }
            ///  public String GetPrivateString()
            ///  {
            ///  return privateString;
            ///  }
            ///  private String privateString;
            ///  }
            ///  It has no business meaning, but if you run this code
            ///  Test4 t = new Test4("privatevalue");
            ///  Console.WriteLine("GetPrivateString = " + t.GetPrivateString());
            ///  MemoryStream xms = new MemoryStream();
            ///  XmlSerializer xs = new XmlSerializer(typeof(Test4));
            ///  xs.Serialize(xms, t);
            ///  xms.Position = 0;
            ///  Test4 des = (Test4)xs.Deserialize(xms);
            ///  Console.WriteLine("GetPrivateString = " + des.GetPrivateString());
            ///  You will find that the output is
            ///  GetPrivateString = privatevalue
            ///  GetPrivateString =
            ///  Thus the deserialized object is not the same of the serialized one, 
            ///  thus XML serialization does not guarantees that an entity would be the
            ///  same after deserialization as Marco commented in the previous post. 
            ///  A very different situation happens if you use binary serialization.
            ///   Test4 t = new Test4("privatevalue");
            ///   Console.WriteLine("GetPrivateString = " + t.GetPrivateString());
            ///   MemoryStream bms = new MemoryStream();
            ///   BinaryFormatter bf = new BinaryFormatter();
            ///   bf.Serialize(bms, t);
            ///   bms.Position = 0;
            ///   Test4 des = (Test4) bf.Deserialize(bms);
            ///   Console.WriteLine("GetPrivateString = " + t.GetPrivateString());
            ///   The output is
            ///   GetPrivateString = privatevalue
            ///   GetPrivateString = privatevalue
            ///   Thus showing that the deserialized object has the same state. 
            ///   But XmlSerialization have other problems, let’s serialize and deserialize this class
            ///    [Serializable]
            ///    public class Testcontainer
            ///    {
            ///     public Test test1 { get; set; }
            ///     public Test test2 { get; set; }
            ///    }
            ///    ...
            ///    Testcontainer t = new Testcontainer();
            ///    t.test1 = t.test2 = new Test() { Property = "Test"};
            ///    MemoryStream xms = new MemoryStream();
            ///    XmlSerializer xs = new XmlSerializer(typeof(Testcontainer));
            ///    xs.Serialize(xms, t);
            ///    xms.Position = 0;
            ///    Testcontainer des = (Testcontainer)xs.Deserialize(xms);
            ///    Console.WriteLine("t.test1 == t.test2 is {0}", des.test1 == des.test2);
            ///    MemoryStream bms = new MemoryStream();
            ///    BinaryFormatter bf = new BinaryFormatter();
            ///    bf.Serialize(bms, t);
            ///    bms.Position = 0;
            ///    des = (Testcontainer)bf.Deserialize(bms);
            ///    Console.WriteLine("t.test1 == t.test2 is {0}", des.test1 == des.test2);
            ///    The output shows you that with XML Serialization the condition des.test1 == des.test2 is false,
            ///    because Xml Serialization does not check for object identity , thus it throws exception 
            ///    if the object graph has a circular references.
            ///    Never use XmlSerialization to store an object into durable medium unless you are perfectly aware of what you are doing.
            /// </example>
            /// </summary>
            public static class ObjectXMLSerializer<T> where T : class // Specify that T must be a class.
            {

                /// <summary>
                /// To cut down on the size of the xml being sent to the database, we'll strip
                /// out this extraneous xml.
                /// </summary>
                /// <param name="serializableObject"></param>
                /// <returns></returns>
                public static string SerializeToXml(T serializableObject)
                {
                    StringWriter Output = new StringWriter(new StringBuilder());
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(Output, serializableObject);
                    return Output.ToString();
                }
                              
                /// <summary>
                /// 
                /// </summary>
                /// <param name="xml"></param>
                /// <returns></returns>
                public static T DeserializeFromXml(string xml)
                {
                    T result;
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    using (TextReader tr = new StringReader(xml))
                    {
                        result = (T)ser.Deserialize(tr);
                    }
                    return result;
                }

                
                #region Load methods

                /// <summary>
                /// Loads an object from an XML file in Document format.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load(@"C:\XMLObjects.xml");
                /// </code>
                /// </example>
                /// <param name="path">Path of the file to load the object from.</param>
                /// <returns>Object loaded from an XML file in Document format.</returns>
                public static T Load(string path)
                {
                    T serializableObject = LoadFromDocumentFormat(null, path, null);
                    return serializableObject;
                }

                /// <summary>
                /// Loads an object from an XML file using a specified serialized format.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load(@"C:\XMLObjects.xml", SerializedFormat.Binary);
                /// </code>
                /// </example>		
                /// <param name="path">Path of the file to load the object from.</param>
                /// <param name="serializedFormat">XML serialized format used to load the object.</param>
                /// <returns>Object loaded from an XML file using the specified serialized format.</returns>
                public static T Load(string path, SerializedFormat serializedFormat)
                {
                    T serializableObject = null;

                    switch (serializedFormat)
                    {
                        case SerializedFormat.Binary:
                            serializableObject = LoadFromBinaryFormat(path, null);
                            break;

                        case SerializedFormat.XmlDocument:
                        default:
                            serializableObject = LoadFromDocumentFormat(null, path, null);
                            break;
                    }

                    return serializableObject;
                }

                /// <summary>
                /// Loads an object from an XML file in Document format, supplying extra data types to enable deserialization of custom types within the object.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load(@"C:\XMLObjects.xml", new Type[] { typeof(MyCustomType) });
                /// </code>
                /// </example>
                /// <param name="path">Path of the file to load the object from.</param>
                /// <param name="extraTypes">Extra data types to enable deserialization of custom types within the object.</param>
                /// <returns>Object loaded from an XML file in Document format.</returns>
                public static T Load(string path, System.Type[] extraTypes)
                {
                    T serializableObject = LoadFromDocumentFormat(extraTypes, path, null);
                    return serializableObject;
                }

                /// <summary>
                /// Loads an object from an XML file in Document format, located in a specified isolated storage area.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load("XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly());
                /// </code>
                /// </example>
                /// <param name="fileName">Name of the file in the isolated storage area to load the object from.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to load the object from.</param>
                /// <returns>Object loaded from an XML file in Document format located in a specified isolated storage area.</returns>
                public static T Load(string fileName, IsolatedStorageFile isolatedStorageDirectory)
                {
                    T serializableObject = LoadFromDocumentFormat(null, fileName, isolatedStorageDirectory);
                    return serializableObject;
                }

                /// <summary>
                /// Loads an object from an XML file located in a specified isolated storage area, using a specified serialized format.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load("XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly(), SerializedFormat.Binary);
                /// </code>
                /// </example>		
                /// <param name="fileName">Name of the file in the isolated storage area to load the object from.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to load the object from.</param>
                /// <param name="serializedFormat">XML serialized format used to load the object.</param>        
                /// <returns>Object loaded from an XML file located in a specified isolated storage area, using a specified serialized format.</returns>
                public static T Load(string fileName, IsolatedStorageFile isolatedStorageDirectory, SerializedFormat serializedFormat)
                {
                    T serializableObject = null;

                    switch (serializedFormat)
                    {
                        case SerializedFormat.Binary:
                            serializableObject = LoadFromBinaryFormat(fileName, isolatedStorageDirectory);
                            break;

                        case SerializedFormat.XmlDocument:
                        default:
                            serializableObject = LoadFromDocumentFormat(null, fileName, isolatedStorageDirectory);
                            break;
                    }

                    return serializableObject;
                }

                /// <summary>
                /// Loads an object from an XML file in Document format, located in a specified isolated storage area, and supplying extra data types to enable deserialization of custom types within the object.
                /// </summary>
                /// <example>
                /// <code>
                /// serializableObject = ObjectXMLSerializer&lt;SerializableObject&gt;.Load("XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly(), new Type[] { typeof(MyCustomType) });
                /// </code>
                /// </example>		
                /// <param name="fileName">Name of the file in the isolated storage area to load the object from.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to load the object from.</param>
                /// <param name="extraTypes">Extra data types to enable deserialization of custom types within the object.</param>
                /// <returns>Object loaded from an XML file located in a specified isolated storage area, using a specified serialized format.</returns>
                public static T Load(string fileName, IsolatedStorageFile isolatedStorageDirectory, System.Type[] extraTypes)
                {
                    T serializableObject = LoadFromDocumentFormat(null, fileName, isolatedStorageDirectory);
                    return serializableObject;
                }

                #endregion

                #region Save methods

                /// <summary>
                /// Saves an object to an XML file in Document format.
                /// </summary>
                /// <example>
                /// <code>        
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, @"C:\XMLObjects.xml");
                /// </code>
                /// </example>
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="path">Path of the file to save the object to.</param>
                public static void Save(T serializableObject, string path)
                {
                    SaveToDocumentFormat(serializableObject, null, path, null);
                }

                /// <summary>
                /// Saves an object to an XML file using a specified serialized format.
                /// </summary>
                /// <example>
                /// <code>
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, @"C:\XMLObjects.xml", SerializedFormat.Binary);
                /// </code>
                /// </example>
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="path">Path of the file to save the object to.</param>
                /// <param name="serializedFormat">XML serialized format used to save the object.</param>
                public static void Save(T serializableObject, string path, SerializedFormat serializedFormat)
                {
                    switch (serializedFormat)
                    {
                        case SerializedFormat.Binary:
                            SaveToBinaryFormat(serializableObject, path, null);
                            break;

                        case SerializedFormat.XmlDocument:
                        default:
                            SaveToDocumentFormat(serializableObject, null, path, null);
                            break;
                    }
                }

                /// <summary>
                /// Saves an object to an XML file in Document format, supplying extra data types to enable serialization of custom types within the object.
                /// </summary>
                /// <example>
                /// <code>        
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, @"C:\XMLObjects.xml", new Type[] { typeof(MyCustomType) });
                /// </code>
                /// </example>
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="path">Path of the file to save the object to.</param>
                /// <param name="extraTypes">Extra data types to enable serialization of custom types within the object.</param>
                public static void Save(T serializableObject, string path, System.Type[] extraTypes)
                {
                    SaveToDocumentFormat(serializableObject, extraTypes, path, null);
                }

                /// <summary>
                /// Saves an object to an XML file in Document format, located in a specified isolated storage area.
                /// </summary>
                /// <example>
                /// <code>        
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, "XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly());
                /// </code>
                /// </example>
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="fileName">Name of the file in the isolated storage area to save the object to.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to save the object to.</param>
                public static void Save(T serializableObject, string fileName, IsolatedStorageFile isolatedStorageDirectory)
                {
                    SaveToDocumentFormat(serializableObject, null, fileName, isolatedStorageDirectory);
                }

                /// <summary>
                /// Saves an object to an XML file located in a specified isolated storage area, using a specified serialized format.
                /// </summary>
                /// <example>
                /// <code>        
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, "XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly(), SerializedFormat.Binary);
                /// </code>
                /// </example>
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="fileName">Name of the file in the isolated storage area to save the object to.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to save the object to.</param>
                /// <param name="serializedFormat">XML serialized format used to save the object.</param>        
                public static void Save(T serializableObject, string fileName, IsolatedStorageFile isolatedStorageDirectory, SerializedFormat serializedFormat)
                {
                    switch (serializedFormat)
                    {
                        case SerializedFormat.Binary:
                            SaveToBinaryFormat(serializableObject, fileName, isolatedStorageDirectory);
                            break;

                        case SerializedFormat.XmlDocument:
                        default:
                            SaveToDocumentFormat(serializableObject, null, fileName, isolatedStorageDirectory);
                            break;
                    }
                }

                /// <summary>
                /// Saves an object to an XML file in Document format, located in a specified isolated storage area, and supplying extra data types to enable serialization of custom types within the object.
                /// </summary>
                /// <example>
                /// <code>
                /// SerializableObject serializableObject = new SerializableObject();
                /// 
                /// ObjectXMLSerializer&lt;SerializableObject&gt;.Save(serializableObject, "XMLObjects.xml", IsolatedStorageFile.GetUserStoreForAssembly(), new Type[] { typeof(MyCustomType) });
                /// </code>
                /// </example>		
                /// <param name="serializableObject">Serializable object to be saved to file.</param>
                /// <param name="fileName">Name of the file in the isolated storage area to save the object to.</param>
                /// <param name="isolatedStorageDirectory">Isolated storage area directory containing the XML file to save the object to.</param>
                /// <param name="extraTypes">Extra data types to enable serialization of custom types within the object.</param>
                public static void Save(T serializableObject, string fileName, IsolatedStorageFile isolatedStorageDirectory, System.Type[] extraTypes)
                {
                    SaveToDocumentFormat(serializableObject, null, fileName, isolatedStorageDirectory);
                }

                #endregion


                
                #region Private

                private static FileStream CreateFileStream(IsolatedStorageFile isolatedStorageFolder, string path)
                {
                    FileStream fileStream = null;

                    if (isolatedStorageFolder == null)
                        fileStream = new FileStream(path, FileMode.OpenOrCreate);
                    else
                        fileStream = new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder);

                    return fileStream;
                }

                private static T LoadFromBinaryFormat(string path, IsolatedStorageFile isolatedStorageFolder)
                {
                    T serializableObject = null;

                    using (FileStream fileStream = CreateFileStream(isolatedStorageFolder, path))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        serializableObject = binaryFormatter.Deserialize(fileStream) as T;
                    }

                    return serializableObject;
                }

                private static T LoadFromDocumentFormat(System.Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
                {
                    T serializableObject = null;

                    using (TextReader textReader = CreateTextReader(isolatedStorageFolder, path))
                    {
                        XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                        serializableObject = xmlSerializer.Deserialize(textReader) as T;

                    }

                    return serializableObject;
                }

                private static TextReader CreateTextReader(IsolatedStorageFile isolatedStorageFolder, string path)
                {
                    TextReader textReader = null;

                    if (isolatedStorageFolder == null)
                        textReader = new StreamReader(path);
                    else
                        textReader = new StreamReader(new IsolatedStorageFileStream(path, FileMode.Open, isolatedStorageFolder));

                    return textReader;
                }

                private static TextWriter CreateTextWriter(IsolatedStorageFile isolatedStorageFolder, string path)
                {
                    TextWriter textWriter = null;

                    if (isolatedStorageFolder == null)
                        textWriter = new StreamWriter(path);
                    else
                        textWriter = new StreamWriter(new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder));

                    return textWriter;
                }

                private static XmlSerializer CreateXmlSerializer(System.Type[] extraTypes)
                {
                    Type ObjectType = typeof(T);

                    XmlSerializer xmlSerializer = null;

                    if (extraTypes != null)
                        xmlSerializer = new XmlSerializer(ObjectType, extraTypes);
                    else
                        xmlSerializer = new XmlSerializer(ObjectType);

                    return xmlSerializer;
                }

                private static void SaveToDocumentFormat(T serializableObject, System.Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
                {
                    using (TextWriter textWriter = CreateTextWriter(isolatedStorageFolder, path))
                    {
                        XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                        xmlSerializer.Serialize(textWriter, serializableObject);
                        
                    }
                    
                }

                private static void SaveToBinaryFormat(T serializableObject, string path, IsolatedStorageFile isolatedStorageFolder)
                {
                    using (FileStream fileStream = CreateFileStream(isolatedStorageFolder, path))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, serializableObject);
                    }
                }

                #endregion
            }
        }
    }
}
