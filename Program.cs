using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DecompressCosturaFody
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask for the file name!
            Console.Write("What's the file name?: ");
            var fileName = Console.ReadLine();

            // Check if the file exists
            if (!File.Exists(fileName)) Console.WriteLine("File couldn't be found!");

            // Firstly Decompressing the file
            var decompressedFile = Func.Decompress(fileName);

            // Reading the bytes of the decompressed file!
            var getBytes = Func.ReadStream(decompressedFile);

            // Creating a new file containg these bytes
            Console.Write("What's the desired name (include the extension aswell): ");
            var desiredName = Console.ReadLine();
            Func.makeFile(desiredName, getBytes);

            Console.WriteLine($"New file: {desiredName}");

            Console.Read();
        }
    }
}
