using System;
using System.Collections.Generic;

using System.Text;
using System.IO.Compression;
using System.IO;

namespace UtilitiesLibrary
{
    namespace Compression
    {
        public enum CompressionType
        {
            Deflate,
            GZip
        }
        /// <summary>
        /// 
        /// </summary>
        public class FileCompress
        {
            #region Compress and Decompress string

            /// <summary>
            /// 
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Compress(string text)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                MemoryStream ms = new MemoryStream();
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }

                ms.Position = 0;
                MemoryStream outStream = new MemoryStream();

                byte[] compressed = new byte[ms.Length];
                ms.Read(compressed, 0, compressed.Length);

                byte[] gzBuffer = new byte[compressed.Length + 4];
                System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
                System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
                return Convert.ToBase64String(gzBuffer);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="compressedText"></param>
            /// <returns></returns>
            public static string Decompress(string compressedText)
            {
                byte[] gzBuffer = Convert.FromBase64String(compressedText);
                using (MemoryStream ms = new MemoryStream())
                {
                    int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                    ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                    byte[] buffer = new byte[msgLength];

                    ms.Position = 0;
                    using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                    {
                        zip.Read(buffer, 0, buffer.Length);
                    }

                    return Encoding.UTF8.GetString(buffer);
                }
            }
            #endregion


            /// <summary>
            /// Compress and decompress file
            /// <code>
            /// public static void TestCompressNewFile()
            /// {
            ///    byte[] data = new byte[10000000];
            ///    for (int i = 0; i < 10000000; i++)
            ///        data[i] = 254;
            ///    using (FileStream fs = new FileStream(@"C:\NewCompressedFile.txt",
            ///           FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            ///        CompressFile(fs, data, CompressionType.Deflate);

            ///    using (FileStream fs = new FileStream(@"C:\NewCompressedFile.txt",
            ///           FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            ///    {
            ///        byte[] retData = DeCompressFile(fs, CompressionType.Deflate);
            ///        Console.WriteLine("Deflated file bytes count == " + retData.Length);
            ///    }

            ///    using (FileStream fs = new FileStream(@"C:\NewGZCompressedFile.txt",
            ///           FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            ///        CompressFile(fs, data, CompressionType.GZip);

            ///    using (FileStream fs = new FileStream(@"C:\NewGzCompressedFile.txt",
            ///           FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            ///    {
            ///        byte[] retData = DeCompressFile(fs, CompressionType.GZip);
            ///        Console.WriteLine("GZipped file bytes count == " + retData.Length);
            ///    }
            ///}
            /// </code>
            /// </summary>
            /// 
            #region Compress and Decompress File

            /// <summary>
            /// 
            /// </summary>
            /// <param name="strm"></param>
            /// <param name="data"></param>
            /// <param name="compressionType"></param>
            public static void CompressFile(Stream strm, byte[] data,
                                    CompressionType compressionType)
            {
                // Determine how to compress the file.
                Stream deflate = null;
                if (compressionType == CompressionType.Deflate)
                {
                    using (deflate = new DeflateStream(strm, CompressionMode.Compress))
                    {
                        // Write compressed data to the file.
                        deflate.Write(data, 0, data.Length);
                    }
                }
                else
                {
                    using (deflate = new GZipStream(strm, CompressionMode.Compress))
                    {
                        // Write compressed data to the file.
                        deflate.Write(data, 0, data.Length);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="strm"></param>
            /// <param name="compressionType"></param>
            /// <returns></returns>
            public static byte[] DeCompressFile(Stream strm,
                                                CompressionType compressionType)
            {
                // Determine how to decompress the file.
                Stream reInflate = null;

                if (compressionType == CompressionType.Deflate)
                {
                    using (reInflate = new DeflateStream(strm, CompressionMode.Decompress))
                    {
                        return (Decompress(reInflate));
                    }
                }
                else
                {
                    using (reInflate = new GZipStream(strm, CompressionMode.Decompress))
                    {
                        return (Decompress(reInflate));
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="reInflate"></param>
            /// <returns></returns>
            private static byte[] Decompress(Stream reInflate)
            {
                List<byte> data = new List<byte>();
                int retVal = 0;

                // Read all data in and uncompress it.
                while (retVal >= 0)
                {
                    retVal = reInflate.ReadByte();
                    if (retVal != -1)
                        data.Add((byte)retVal);
                }

                return (data.ToArray());
            }
            #endregion

        }
    }
}
