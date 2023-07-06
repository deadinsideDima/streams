namespace Streams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            if (stringReader.Peek() != -1)
            {
                currentChar = (char)stringReader.Read();
                return true;
            }

            currentChar = ' ';
            return false;
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            if (stringReader.Peek() != -1)
            {
                currentChar = (char)stringReader.Peek();
                return true;
            }

            currentChar = ' ';
            return false;
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            List<char> buffer = new List<char>();
            int i = 0;
            while (i < count && stringReader.Peek() != -1)
            {
                buffer.Add((char)stringReader.Read());
                i++;
            }

            return buffer.ToArray();
        }
    }
}
