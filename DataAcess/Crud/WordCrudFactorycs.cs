using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class WordCrudFactory : CrudFactory
    {
        WordMapper mapper;

        public WordCrudFactory() : base()
        {
            mapper = new WordMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var word = (Word)entity;
            var sqlOperation = mapper.GetCreateStatement(word);
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
            var lstWords = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstWords.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstWords;
        }

        public override void Update(BaseEntity entity)
        {
            var word = (Word)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(word));
        }

        public override void Delete(BaseEntity entity)
        {
            var word = (Word)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(word));
        }
    }
}
