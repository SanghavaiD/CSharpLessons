using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.DayH8
{
    internal class StreamLesson
    {
        public static void TestOne()
        {
            char ch;
            Console.WriteLine("Press a akey bfollowed by ENTER:");
            int x= Console.Read();
            ch = (char)x; //get a char
            Console.WriteLine("\n "+x+"Your key is :"+ ch);

        }
        public static void TestTwo()
        {
            char ch = ' ';
            Console.WriteLine("Press a akey q by exit:");
            while (ch != 'q')
            {
                ch = (char)Console.Read();
                Console.WriteLine("Your key is :"+ch);
            }


        }
        public static void TestThree()
        {
            Console.Out.WriteLine("Enter a sentence");
            string? str = Console.ReadLine();
            Console.Out.WriteLine(" " + str);
        }
        public static void TestNullableTypes()
        {
            int? x = 0;
            x = null;
            if (x.HasValue)
            {
                Console.WriteLine(x.Value);
            }
            else
            { 
                Console.WriteLine(x.GetValueOrDefault()); 
            }
        }
        
    }
    class StreamReaderWriterLesson
    {
        static byte[] storage = new byte[255];
        static MemoryStream tempmemorystream = new MemoryStream(storage);
        public static void MemStreamWriter()
        {
            // Wrap tempmemorystream in a reader and a writer.
            StreamWriter streamwriter = null;
            // Write to storage, through streamwriter.
            String? inputString = String.Empty;
            try
            {
                Console.WriteLine("Enter a Sentence:");
                inputString = Console.ReadLine();
                streamwriter = new StreamWriter(tempmemorystream);
                streamwriter.WriteLine(inputString);
                // Put a period at the end.
                streamwriter.WriteLine(".");
                streamwriter.Flush();
                Console.WriteLine("tempmemorystream.Length " + tempmemorystream.Length);
                Console.WriteLine("tempmemorystream.Capacity " + tempmemorystream.Capacity);
                Console.WriteLine("tempmemorystream.Postion " + tempmemorystream.Position);
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR!!! " + err.Message);
            }
            finally
            {
                //streamwriter.Close();
            }
        }
        public static void MemStreamReader()
        {
            Console.WriteLine("memstrm.Postion " + tempmemorystream.Position);
            StreamReader memrdr = new StreamReader(tempmemorystream);
            try
            {
                Console.WriteLine("\nReading through memrdr: ");
                // Read from tempmemorystream using the stream reader.
                tempmemorystream.Seek(0, SeekOrigin.Begin); // reset file pointer
                Console.WriteLine("tempmemorystream.Postion After seek " + tempmemorystream.Position);
                string str = memrdr.ReadLine();
                while (str != null)
                {
                    Console.WriteLine(str);
                    //if (str.CompareTo(".") == 0) break;
                    str = memrdr.ReadLine();
                }
            }
            finally
            {
                memrdr.Close();
            }
        }






        static MemoryStream memoryStream = new MemoryStream();

        public static void WriteStringToMemoryStream()
        {
            Console.WriteLine("MemoryStream Length " + memoryStream.Length);
            Console.WriteLine("Enter a String ");
            String inputData = Console.ReadLine();
            if (inputData == null)
            {
                System.Console.WriteLine("INPUT IS EMPTY");
                return;
            }
            byte[] dataArray = System.Text.Encoding.ASCII.GetBytes(inputData);
            BinaryWriter binWriter = new BinaryWriter(memoryStream);
            // read data(the random numbers) from dataArray and write to MemoryStream
            binWriter.Write(dataArray);
            Console.WriteLine("Write Completed " + memoryStream.Length);
        }
        //Using BinaryReader to read string from MemoryStream
        public static void ReadStringFromMemoryStream()
        {
            if (memoryStream.Length == 0)
            {
                Console.WriteLine("Memory Stream is Empty");
                return;
            }
            // Create the reader using the stream from the writer.
            BinaryReader binReader = new BinaryReader(memoryStream);
            // Set Position to the beginning of the stream.
            binReader.BaseStream.Position = 0;
            // Read and verify the data.
            int arrayLength = (int)memoryStream.Length;
            // memoryStream.Length is Long but binReader.ReadBytes(int)
            byte[] verifyArray = binReader.ReadBytes(arrayLength);
            String stringOutput = Encoding.ASCII.GetString(verifyArray);
            Console.WriteLine(stringOutput);
        }



        public static void PeekAndReadCharacters()
        {
            string readerText = "Tom and Jerry is an American animated media franchise and series of comedy short films created in 1940 by William Hanna and Joseph Barbera.\n" +
                " Best known for its 161 theatrical short films by Metro-Goldwyn-Mayer, the series centers on the rivalry between the titular characters of a cat named Tom and a mouse named Jerry.\n " +
                "Many shorts also feature several recurring characters.";

            Console.WriteLine("Original text:\n\n{0}", readerText);
            Console.WriteLine("*****************************************");
            StringReader strReader = new StringReader(readerText);
            // Peek to see if the next character exists
            try
            {
                while (strReader.Peek() > -1)
                {
                    // Read a line from the Stream and display it on the console
                    Console.WriteLine(strReader.ReadLine() + "--");
                }
                Console.WriteLine("Data Read Complete!");
            }
            finally
            {
                //Close the stringReader
                strReader.Close();
            }
        }

    }


}
