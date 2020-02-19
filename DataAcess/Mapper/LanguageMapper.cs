using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class LanguageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_POPULARITY = "POPULARITY";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LANGUAGE_PR" };

            var c = (Language)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LANGUAGE_PR" };

            var c = (Language)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LANGUAGE_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LANGUAGE_PR" };

            var c = (Language)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LANGUAGE_PR" };

            var c = (Language)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_POPULARITY, c.Popularity);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var language = BuildObject(row);
                lstResults.Add(language);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var language = new Language
            {
                Name = GetStringValue(row, DB_COL_NAME),
            };

            return language;
        }

    }
}
