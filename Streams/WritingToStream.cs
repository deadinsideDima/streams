using System.Globalization;
using System.Text;

namespace Streams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            int a;
            StringBuilder b = new StringBuilder(string.Empty);
            while ((a = streamReader.Read()) != -1)
            {
                string temp = string.Empty;
                while (a > 0)
                {
                    int n = a % 10;
                    temp = Convert.ToChar(n + '0') + temp;
                    a /= 10;
                }

                _ = b.Append(temp);
            }

            outputWriter.Write(b);
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            int character;
            while ((character = streamReader.Read()) != -1)
            {
                outputWriter.Write((char)character);
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            string str = string.Empty;
            while (contentReader.Peek() != -1)
            {
                outputWriter.Write("0" + Convert.ToString(contentReader.Read(), 16).ToUpper(CultureInfo.CurrentCulture));
                outputWriter.Flush();
            }

            outputWriter.Write(str);
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            string str = string.Empty;
#pragma warning disable CS8600
            string temp = contentReader.ReadLine();
            int i = 1;
            while (temp != null)
            {
                outputWriter.WriteLine("00" + i + " " + temp);
                outputWriter.Flush();
                temp = contentReader.ReadLine();
                i++;
            }

            outputWriter.Write(str);
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            string str = contentReader.ReadLine();
            StringBuilder sb = new StringBuilder(str);
            while (wordsReader.Peek() != -1)
            {
                string temp = wordsReader.ReadLine();
#pragma warning disable IDE0058
#pragma warning disable CS8604 //Возможный аргумент пустой ссылки для параметра.
                sb.Replace(temp, string.Empty);
            }

            outputWriter.Write(sb.ToString());
        }
    }
}
