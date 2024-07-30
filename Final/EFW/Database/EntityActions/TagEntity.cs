using Final.EFW.Entities;
using Microsoft.EntityFrameworkCore;
using static Final.EFW.Database.Core;
namespace Final.EFW.Database.EntityActions
{
    public class TagEntity
    {
        protected internal static void Add(User? _user, DB _db, string _tagName)
        {
            if (_user != null)
            {
                int _count = _db.context.Tags.Where(x => x.Text == _tagName).Count();
                if (_count < 1)
                {
                    Tag _tag = new Tag();
                    _tag.Var(_tagName, _user);
                    _db.context.Tags.Add(_tag);
                    _db.context.SaveChanges();
                }
            }
        }
        public static void Add(string _userId, string _tagName)
        {
            DB _db = new DB();
            Add(UserEntity.GetById(_userId, _db), _db, _tagName);
        }
        protected internal static Tag? GetById(DB _db, string _id)
        {
            return _db.context.Tags.FirstOrDefault(x => x.Id == _id);
        }
        public static Tag? GetById(string _id)
        {
            DB _db = new DB();
            return GetById(_db, _id);
        }
        protected internal static List<Tag>? GetAllTags(DB _db)
        {
            return _db.context.Tags.ToList();
        }
        public static List<Tag>? GetAllTags()
        {
            DB _db = new DB();
            return GetAllTags(_db);
        }

        protected internal static void UpdateById(DB _db, string _id, string _tagText)
        {
            Tag? _tempTag = _db.context.Tags.FirstOrDefault(x => x.Id == _id);
            if (_tempTag != null)
            {
                _tempTag.Text = _tagText;
                _db.context.Tags.Update(_tempTag);
                _db.context.SaveChanges();
            }
        }
        public static void UpdateById(string _id, string _tagText)
        {
            DB _db = new DB();
            UpdateById(_db, _id, _tagText);
        }
        protected internal static void DeleteById(DB _db, string _id)
        {
            _db.context.Tags.Where(x => x.Id == _id).ExecuteDelete();
            _db.context.SaveChanges();
        }
        public static void DeleteById( string _id)
        {
            DB _db = new DB();
            DeleteById(_db, _id);
        }
    }
}