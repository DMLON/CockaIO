using System;
using System.Collections.Generic;
using System.Text;
using CockaIO.Services;
using CockaIO.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace CockaIO_UnitTest
{
    [TestClass]
    public class TestDatabase : IDbContextService
    {

        public TestDatabase()
        {
            Cars = new List<Cars>(5);
            Users = new List<Users>(5);
            UserCar = new List<UserCar>(5);

            for (int i = 0; i < 5; ++i)
            {
                Cars.Add(new Cars { Idcar = i, Brand = $"TestBrand{i + 1}", Model = $"TestModel{i + 1}", UrlImage = $"URL{i + 1}", Year = 2000 + i });
                Users.Add(new Users {Iduser = i, Name = $"Name{i}",Lastname=$"Lastname{i}",Age=i+15 });
                UserCar.Add(new UserCar { Idcar = i,Iduser=i, CarColor="Red",Plate=$"AAA {i}{i}{i}"});
            }

        }

        public List<Cars> Cars { get; private set; }
        public List<Users> Users { get; private set; }
        public List<UserCar> UserCar { get; private set; }

        public bool CreateEntity<T>(T entity) where T : class
        {
            var property = this.GetType().GetProperty(typeof(T).Name).GetValue(this, null);
            
            if (property != null)
            {
                List<T> referenceToList = (List<T>)property;
                referenceToList.Add(entity);
                return true;
            }
            throw new ArgumentException($"Entity type {typeof(T)} not supported");
        }

        public bool DeleteEntity<T>(T entity) where T : class
        {
            var property = this.GetType().GetProperty(typeof(T).Name).GetValue(this, null);

            if (property != null)
            {
                List<T> referenceToList = (List<T>)property;
                return referenceToList.Remove(entity);
            }
            throw new ArgumentException($"Entity type {typeof(T)} not supported");
        }

        public IQueryable<T> GetAllEntities<T>() where T : class
        {
            var property = this.GetType().GetProperty(typeof(T).Name).GetValue(this, null);

            if (property != null)
            {
                return (IQueryable<T>)property;
            }
            throw new ArgumentException($"Entity type {typeof(T)} not supported");
        }

        public T GetById<T>(int id) where T : class
        {
            Console.WriteLine(this.GetType().ToString());
            var property = this.GetType().GetProperty(typeof(T).Name).GetValue(this);

            if (property != null)
            {
                List<T> referenceToList = (List<T>)property;
                var properties = typeof(T).GetProperties();
                int IdIndex = 0;
                for (int j = 0; j < properties.Length; ++j)
                {
                    //Look for property that starts with Id
                    if (properties[j].Name.StartsWith("Id"))
                    {
                        IdIndex = j;
                        break;
                    }
                }
                int Index = -1;
                for (int i = 0; i < referenceToList.Count; ++i)
                {
                    //If id of A.Id is equal to Id, it's the same element altered
                    if ((int)properties[IdIndex].GetValue(referenceToList[i]) == id)
                    {
                        Index = i;
                        break;
                    }
                }

                if (Index < 0)
                {
                    return null;
                }
                return referenceToList[Index];
            }
            throw new ArgumentException($"Entity type {typeof(T)} not supported");

        }

        public void SaveChanges()
        {
            return;
        }

        public bool UpdateEntity<T>(T entity) where T : class
        {
            Console.WriteLine(this.GetType().ToString());
            var property = this.GetType().GetProperty(typeof(T).Name).GetValue(this);

            if (property != null)
            {
                List<T> referenceToList = (List<T>)property;
                var properties = typeof(T).GetProperties();
                int IdIndex = 0;
                for (int j = 0; j < properties.Length; ++j)
                {
                    //Look for property that starts with Id
                    if (properties[j].Name.StartsWith("Id"))
                    {
                        IdIndex = j; 
                        break;
                    }
                }
                int Index = -1;
                for (int i = 0; i < referenceToList.Count; ++i)
                {
                    //If id of A is equal to B, it's the same element altered
                    if ((int)properties[IdIndex].GetValue(referenceToList[i]) == (int)properties[IdIndex].GetValue(referenceToList[i]))
                    {
                        Index = i;
                        break;
                    }
                }

                if (Index < 0)
                {
                    return false;
                }
                referenceToList[Index] = entity;
                return true;
            }
            throw new ArgumentException($"Entity type {typeof(T)} not supported");
        }
    }
}
