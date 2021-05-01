using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecompressCosturaFody
{
    class Func
    { 
        // This are rewritten/Copied functions from Costura/Fody 
        public static Stream Decompress(string fullname)
        {
            try
            {
                using (var manifestResourceStream = File.Open(fullname, FileMode.Open, FileAccess.ReadWrite))
                {
                    using (var deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
                    {
                        var memoryStream = new MemoryStream();
                        CopyTo(deflateStream, memoryStream);
                        memoryStream.Position = 0L;
                        return memoryStream;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This file is not capable of being decompresed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return null;
            }
        }

        public static byte[] ReadStream(Stream stream)
        {
            var array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            return array;
        }

        public static void makeFile(string newFileName, byte[] fileBytes)
        {
            using (var fs = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Flush();
                fs.Close();
            }
        }

        private static void CopyTo(Stream source, Stream destination)
        {
            var array = new byte[81920];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
                destination.Write(array, 0, count);
        }
    }
}
