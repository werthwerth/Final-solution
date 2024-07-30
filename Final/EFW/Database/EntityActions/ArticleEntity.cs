using Final.EFW.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final.EFW.Database.EntityActions
{
    public class ArticleEntity
    {
        protected internal static Article? Add(Core.DB _db, string _subject, string _text, User _user)
        {
            Article _article = new Article();
            _article.Var(_subject, _text, _user);
            _db.context.Articles.Add(_article);
            _db.context.SaveChanges();
            return _article;
        }
        protected internal static Article? Add(Core.DB _db, string _subject, string _text, string _userId)
        {
            var _user = UserEntity.GetById(_userId);
            if (_user != null)
            {
                return Add(_db, _subject, _text, _userId);
            }
            else
            {
                return null;
            }
        }
        public static Article? Add(string _subject, string _text, string _userId)
        {
            Core.DB _db = new Core.DB();
            return Add(_db, _subject, _text, _userId);
        }
        protected internal static Article? GetByid(Core.DB _db, string? _id)
        {
            if (_id == null)
            {
                return null;
            }
            else
            {
                Article? _article = _db.context.Articles.FirstOrDefault(a => a.Id == _id);
                return _article;
            }
        }
        public static Article? GetByid(string _id)
        {
            Core.DB _db = new Core.DB();
            return GetByid(_db, _id);
        }
        protected internal static void Update(Core.DB _db, Article? _article, string _subject, string _text)
        {
            if (_article != null)
            {
                _article.Text = _text;
                _article.Subject = _subject;
                _db.context.Articles.Update(_article);
                _db.context.SaveChanges();
            }

        }
        protected internal static List<Article> GetAll(Core.DB _db)
        {
            return _db.context.Articles.ToList();
        }
        public static List<Article> GetAll()
        {
            Core.DB _db = new Core.DB();
            return GetAll(_db);
        }
        protected internal static void DeleteById(Core.DB _db, string? _id)
        {
            if (_id != null)
            {
                _db.context.Articles.Where(x => x.Id == _id).ExecuteDelete();
                _db.context.SaveChanges();
            }
        }
        protected internal static void Update(Core.DB _db, string _articleId, string _subject, string _text)
        {
            Update(_db, ArticleEntity.GetByid(_db, _articleId), _subject, _text);
        }
        public static void Update( string _articleId, string _subject, string _text)
        {
            Core.DB _db = new Core.DB();
            Update(_db, _articleId, _subject, _text);
        }
        protected internal static void Delete(Core.DB _db, Article _article)
        {
            _db.context.Articles.Where(x => x == _article).ExecuteDelete();
            _db.context.SaveChanges();
        }
        protected internal static void Delete(Core.DB _db, string _articleId)
        {
            Delete(_db, GetByid(_db, _articleId));
        }
        public static void Delete(string _articleId)
        {
            Core.DB _db = new Core.DB();
            Delete(_db, _articleId);
        }
    }
}