using Bogus;
using Task_5.Models;

namespace Task_5.Services
{
    public class ErrorGenerator
    {
        private readonly Faker faker;
        private readonly string _region;
        private Alphabet alphabet;
        public ErrorGenerator(string region)
        {
            faker = new Faker(region);
            _region = region;
            alphabet = new Alphabet(region);
        }
        public UserModel MakeError(UserModel user, double countOfError)
        {
            string[] texts = new string[] { user.UserName, user.Address, user.PhoneNumber };
            if (countOfError == 0)
            {
                return user;
            }
            for(int i = 0; i <= countOfError; i++)
            {
                int textForError = ChooseText();
                if (((int)countOfError - i == 0) && (countOfError % 1 > 0))
                {
                    double chance = countOfError % 1;
                    texts[textForError] = RandomError(chance, texts[textForError]);
                }
                
                texts[textForError] = ChooseError(texts[textForError]);
            }
            user.UserName = texts[0];
            user.Address = texts[1];
            user.PhoneNumber = texts[2];
            return user;
        }

        private string ChangeChar(string text)
        {
            var listOflphabet = alphabet.GetAlphabet();


            int position = faker.Random.Int(0, text.Length - 1);
            int cha = faker.Random.Int(0, listOflphabet.Count- 1);
            char randomChar = listOflphabet.ElementAt(cha);
            text.Replace(text[position], randomChar);
            return text;
        }

        private string DeleteChar(string text)
        {
            int position = faker.Random.Int(0, text.Length - 1);
            text = text.Remove(position, 1);
            return text;
        }

        private string AddChar(string text)
        {
            var listOflphabet = alphabet.GetAlphabet();


            int position = faker.Random.Int(0, text.Length - 1);
            int cha = faker.Random.Int(0, listOflphabet.Count - 1);
            char randomChar = listOflphabet.ElementAt(cha);
            text = text.Insert(position, randomChar.ToString());
            return text;
        }

        private int ChooseText()
        {
            return faker.Random.Int(0, 2);
        }

        private string RandomError(double chanceOfError, string text)
        {
            if (chanceOfError >= faker.Random.Double(0, 0.99))
            {
                text = ChooseError(text);
            }

            return text;
        }

        private string ChooseError(string text)
        {

            if (text.Length < 7)
            {
                int numberOfError = faker.Random.Int(0, 1);
                if (numberOfError == 0)
                {
                    return AddChar(text);
                }
                else
                {
                    return ChangeChar(text);
                }
            }
            else if(text.Length > 30)
            {
                int numberOfError = faker.Random.Int(0, 1);
                if (numberOfError == 0)
                {
                    return DeleteChar(text);
                }
                else
                {
                    return ChangeChar(text);
                }
            }
            

            int error = faker.Random.Int(0, 2);
            if (error == 0)
            {
                return AddChar(text);
            }
            else if(error == 1)
            {
                return ChangeChar(text);
            }
            else
            {
                return DeleteChar(text);
            }


        }
    }
}
