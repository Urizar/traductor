using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TranslatedWord : BaseEntity
    {
        public string User { get; set; }
        public string Language { get; set; }
        public string Word { get; set; }
        public string Date { get; set; }
        public string Translate { get; set; }
        public int Popularity { get; set; }


        public TranslatedWord()
        {

        }

        public TranslatedWord(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 6)
            {
                User = infoArray[0];
                Language = infoArray[1];
                Word = infoArray[2];
                Date = infoArray[3];
                Translate = infoArray[4];
                var popularity = 0;
                if (Int32.TryParse(infoArray[5], out popularity))
                    Popularity = popularity;
                else throw new Exception("Age must be a number");


            }
            else
            {
                throw new Exception("All values are require[user,language,word,date,translate,popularity]");
            }

        }

    }
}
