using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public User()
        {

        }

        public User(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 1)
            {
                Name = infoArray[0];
            }
            else
            {
                throw new Exception("All values are require[name]");
            }

        }

    }
}
