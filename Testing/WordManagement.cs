using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class WordManagement
    {
        private WordCrudFactory crudWord;

        public WordManagement()
        {
            crudWord = new WordCrudFactory();
        }

        public void Create(Word word)
        {

            crudWord.Create(word);

        }


        public List<Word> RetrieveAll()
        {
            return crudWord.RetrieveAll<Word>();
        }

        public Word RetrieveById(Word word)
        {
            return crudWord.Retrieve<Word>(word);
        }

        internal void Update(Word word)
        {
            crudWord.Update(word);
        }

        internal void Delete(Word word)
        {
            crudWord.Delete(word);
        }
    }
}
