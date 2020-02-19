using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class TranslatedWordMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_FK_USER = "FK_USER";
        private const string DB_COL_FK_LANGUAGE = "FK_LANGUAGE";
        private const string DB_COL_FK_WORD = "FK_WORD";
        private const string DB_COL_DATE = "DATE";
        private const string DB_COL_TRANSLATE = "TRANSLATE";
        private const string DB_COL_POPULARITY = "POPULARITY";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRANSLATED_WORD_PR" };

            var c = (TranslatedWord)entity;
            operation.AddVarcharParam(DB_COL_FK_USER, c.User);
            operation.AddVarcharParam(DB_COL_FK_LANGUAGE, c.Language);
            operation.AddVarcharParam(DB_COL_FK_WORD, c.Word);
            operation.AddVarcharParam(DB_COL_DATE, c.Date);
            operation.AddVarcharParam(DB_COL_TRANSLATE, c.Translate);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSLATED_WORD_PR" };

            var c = (TranslatedWord)entity;
            operation.AddVarcharParam(DB_COL_FK_WORD, c.Word);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSLATED_WORD_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TRANSLATED_WORD_PR" };

            var c = (TranslatedWord)entity;
            operation.AddVarcharParam(DB_COL_FK_USER, c.User);
            operation.AddVarcharParam(DB_COL_FK_LANGUAGE, c.Language);
            operation.AddVarcharParam(DB_COL_FK_WORD, c.Word);
            operation.AddVarcharParam(DB_COL_DATE, c.Date);
            operation.AddVarcharParam(DB_COL_TRANSLATE, c.Translate);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_TRANSLATED_WORD_PR" };

            var c = (TranslatedWord)entity;
            operation.AddVarcharParam(DB_COL_FK_WORD, c.Word);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var translatedWord = BuildObject(row);
                lstResults.Add(translatedWord);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var translatedWord = new TranslatedWord
            {
                User = GetStringValue(row, DB_COL_FK_USER),
                Language = GetStringValue(row, DB_COL_FK_LANGUAGE),
                Word = GetStringValue(row, DB_COL_FK_WORD),
                Date = GetStringValue(row, DB_COL_DATE),
                Translate = GetStringValue(row, DB_COL_TRANSLATE),
                Popularity = GetIntValue(row, DB_COL_POPULARITY)
            };

            return translatedWord;
        }

    }
}
