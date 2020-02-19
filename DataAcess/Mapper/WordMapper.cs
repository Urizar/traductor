using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class WordMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_POPULARITY = "POPULARITY";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_WORD_PR" };

            var c = (Word)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_WORD_PR" };

            var c = (Word)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_WORD_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_WORD_PR" };

            var c = (Word)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_WORD_PR" };

            var c = (Word)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var word = BuildObject(row);
                lstResults.Add(word);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var word = new Word
            {
                Name = GetStringValue(row, DB_COL_NAME),
            };

            return word;
        }

    }
}
