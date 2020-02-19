using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class LanguageCrudFactory : CrudFactory
    {
        LanguageMapper mapper;

        public LanguageCrudFactory() : base()
        {
            mapper = new LanguageMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var language = (Language)entity;
            var sqlOperation = mapper.GetCreateStatement(language);
            dao.ExecuteProcedure(sqlOperation);
        }



        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstLanguages = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLanguages.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLanguages;
        }

        public override void Update(BaseEntity entity)
        {
            var language = (Language)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(language));
        }

        public override void Delete(BaseEntity entity)
        {
            var language = (Language)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(language));
        }
    }
}
