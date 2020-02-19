using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class TranslatedWordManagement
    {
        private TranslatedWordCrudFactory crudTranslatedWord;

        public TranslatedWordManagement()
        {
            crudTranslatedWord = new TranslatedWordCrudFactory();
        }

        public void Create(TranslatedWord translatedWord)
        {

            crudTranslatedWord.Create(translatedWord);

        }


        public List<TranslatedWord> RetrieveAll()
        {
            return crudTranslatedWord.RetrieveAll<TranslatedWord>();
        }

        public TranslatedWord RetrieveById(TranslatedWord translatedWord)
        {
            return crudTranslatedWord.Retrieve<TranslatedWord>(translatedWord);
        }

        internal void Update(TranslatedWord translatedWord)
        {
            crudTranslatedWord.Update(translatedWord);
        }

        internal void Delete(TranslatedWord translatedWord)
        {
            crudTranslatedWord.Delete(translatedWord);
        }
    }
}
