namespace Task_5.Services
{
    public class Alphabet
    {
        private readonly string _region;

        public Alphabet (string region)
        {
            _region = region;
        }

        public List<char> GetAlphabet()
        {
            var alphabet = new List<char>();
            if (_region == "uk")
            {
                alphabet = GetUkrainianAlphabet();
            }
            else if (_region == "ge")
            {
                alphabet = GetGeorgianAlphabet();
            }
            else if (_region == "en_US")
            {
                alphabet = GetEnglishAlphabet();
            }
            return alphabet;
        }

        private List<char> GetEnglishAlphabet()
        {
            List<char> alphabet = new List<char>();
            for(int i = 48; i <= 57; i++)
            {
                alphabet.Add((char)i);
            }

            for (int i = 65; i <= 90; i++)
            {
                alphabet.Add((char)i);
            }

            for (int j = 97; j <= 122; j++)
            {
                alphabet.Add((char)j);
            }

            return alphabet;
        }

        private List<char> GetUkrainianAlphabet()
        {
            List<char> alphabet = new List<char>();
            for (int i = 48; i <= 57; i++)
            {
                alphabet.Add((char)i);
            }
            for (int i = 1040; i <= 1103; i++)
            {
                if (i == 1066 || i == 1067 || i == 1069 || i == 1098 || i == 1099 || i == 1101)
                {
                    continue;
                }

                alphabet.Add((char)i);
            }

            return alphabet;
        }

        private List<char> GetGeorgianAlphabet()
        {
            List<char> alphabet = new List<char>();
            for (int i = 48; i <= 57; i++)
            {
                alphabet.Add((char)i);
            }
            for (int i = 4256; i <= 4256; i++)
            {
                alphabet.Add((char)i);
            }

            return alphabet;
        }
    }
}
