using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class LanguageManagement
    {
        private LanguageCrudFactory crudLanguage;

        public LanguageManagement()
        {
            crudLanguage = new LanguageCrudFactory();
        }

        public void Create(Language language)
        {

            crudLanguage.Create(language);

        }


        public List<Language> RetrieveAll()
        {
            return crudLanguage.RetrieveAll<Language>();
        }

        public Language RetrieveById(Language language)
        {
            return crudLanguage.Retrieve<Language>(language);
        }

        internal void Update(Language language)
        {
            crudLanguage.Update(language);
        }

        internal void Delete(Language language)
        {
            crudLanguage.Delete(language);
        }
    }
}
