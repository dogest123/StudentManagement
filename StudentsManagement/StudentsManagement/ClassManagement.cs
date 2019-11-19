using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement
{
    class ClassManagement
    {
        public CLASS[] GetClasses()
        {
            var db = new OOPCSEntities();
            var classes = db.CLASSes.ToArray();
            return classes;
        }
        public void AddClass(string name, string description)
        {
            var newclass = new CLASS();
            newclass.Name = name;
            newclass.Description = description;

            var db = new OOPCSEntities();
            db.CLASSes.Add(newclass);
            db.SaveChanges();
        }
        public void EditClass(int id,string name,string description)
        {
            var db = new OOPCSEntities();
            var oldclass = db.CLASSes.Find(id);
            oldclass.Name = name;
            oldclass.Description = description;

            db.Entry(oldclass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteClass(int id)
        {
            var db = new OOPCSEntities();
            var @class = db.CLASSes.Find(id);
            db.CLASSes.Remove(@class);
            db.SaveChanges();
        }
        public CLASS GetClass(int id)
        {
            var db = new OOPCSEntities();
            var @class = db.CLASSes.Find(id);
            return @class;
        }
    }
}
