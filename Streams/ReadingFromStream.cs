using System.Text;

namespace Streams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            List<string> lines = new List<string>();
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            string temp = streamReader.ReadLine();
            while (temp != null)
            {
                lines.Add(temp);
                temp = streamReader.ReadLine();
            }

            return lines.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            string temp = string.Empty;
            while (streamReader.Peek() != -1 && streamReader.Peek() != ' ' && streamReader.Peek() != ':' && streamReader.Peek() != '"' && streamReader.Peek() != ',' && streamReader.Peek() != '-')
            {
                temp = new string(temp + (char)streamReader.Read());
            }

            return new StringBuilder(temp);
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            List<char[]> chars = new List<char[]>();
            List<char> charsTemp = new List<char>();
            while (streamReader.Peek() != -1)
            {
                charsTemp.Add((char)streamReader.Read());
                if (charsTemp.Count == arraySize)
                {
                    chars.Add(charsTemp.ToArray());
                    charsTemp = new List<char>();
                }
            }

            if (charsTemp.Count > 0)
            {
                chars.Add(charsTemp.ToArray());
            }

            return chars.ToArray();
        }
    }
}
