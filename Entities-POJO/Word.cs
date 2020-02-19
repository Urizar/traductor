using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Word : BaseEntity
    {
        public string Name { get; set; }
        public int Popularity { get; set; }

        public Word()
        {

        }

        public Word(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                Name = infoArray[0];
                var popularity = 0;
                if (Int32.TryParse(infoArray[1], out popularity))
                    Popularity = popularity;
                else
                    throw new Exception("Popularity must be a number");
            }
            else
            {
                throw new Exception("All values are require[name]");
            }

        }

    }
}
