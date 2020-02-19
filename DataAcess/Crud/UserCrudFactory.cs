using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class UserCrudFactory : CrudFactory
    {
        UserMapper mapper;

        public UserCrudFactory() : base()
        {
            mapper = new UserMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var user = (User)entity;
            var sqlOperation = mapper.GetCreateStatement(user);
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
            var lstUsers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsers;
        }

        public override void Update(BaseEntity entity)
        {
            var user = (User)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(user));
        }

        public override void Delete(BaseEntity entity)
        {
            var user = (User)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(user));
        }
    }
}
