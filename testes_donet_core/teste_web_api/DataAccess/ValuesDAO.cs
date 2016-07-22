using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using teste_web_api.Models;

namespace teste_web_api.DataAccess
{
    public class ValuesDAO
    {
        private class ValuesModelComparer : System.Collections.Generic.IEqualityComparer<ValuesModel>
        {
            public bool Equals(ValuesModel x, ValuesModel y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(ValuesModel obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public void Add(ValuesModel value)
        {
            using(var context = new WebApiContext())
            {
                context.Values.Add(value);
                context.SaveChanges();
            }
        }

        public List<ValuesModel> GetAll()
        {
            using(var context = new WebApiContext())
            {
                return context.Values.ToList();
            }
        }

        public ValuesModel GetById(int id)
        {
            using(var context = new WebApiContext())
            {
                return context.Values.FirstOrDefault(v => v.Id == id);
            }
        }

        public void Update(ValuesModel value)
        {
            using(var context = new WebApiContext())
            {
                //context.Entry(value).State = EntityState.Modified;
                var a = context.Values.Update(value);
                context.SaveChanges();
            }
        }

        public void Delete(ValuesModel value)
        {
            using(var context = new WebApiContext())
            {
                context.Values.Remove(value);
                context.SaveChanges();
            }
        }
    }
}
