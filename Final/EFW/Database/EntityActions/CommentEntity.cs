

using Final.EFW.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static Final.EFW.Database.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Final.EFW.Database.EntityActions
{
    public class CommentEntity
    {
        protected internal static List<Comment> GetByArticle(DB _db, Article _article)
        {
            return _db.context.Comments.Where(x => x.Article == _article).ToList();
        }
        public static List<Comment> GetByArticleId(string _articleId)
        {
            DB _db = new DB();
            return GetByArticle(_db, ArticleEntity.GetByid(_db, _articleId));
        }
        protected internal static void Add(DB _db, Article _article, User _author, string _text)
        {
            _db.context.Comments.Add(new Comment {  Article = _article, Author = _author , Text = _text});
            _db.context.SaveChanges();
        }
        public static void AddByIds(string _articleId, string _authorId, string _text)
        {
            DB _db = new DB();
            Add(_db, ArticleEntity.GetByid(_db, _articleId), UserEntity.GetById(_authorId, _db), _text);
        }
        protected internal static Comment? GetById(DB _db, string _id)
        {
            return _db.context.Comments.FirstOrDefault(x => x.Id == _id);
        }
        protected internal static void Update(DB _db, Comment? _comment, string _text)
        {
            if (_comment != null)
            {
                _comment.Text = _text;
                _db.context.Comments.Update(_comment);
                _db.context.SaveChanges();
            }
        }
        protected internal static void Update(DB _db, string _commentid, string _text)
        {
            Update(_db, GetById(_db, _commentid), _text); 
        }
        public static void Update(string _commentid, string _text)
        {
            DB _db = new DB();
            Update(_db, _commentid, _text);
        }
        protected internal static void Delete(DB _db, Comment _comment)
        {
            _db.context.Comments.Where(x => x.Id == _comment.Id).ExecuteDelete();
            _db.context.SaveChanges();
        }
        protected internal static void Delete(DB _db, string _commentId)
        {
            _db.context.Comments.Where(x => x.Id == _commentId).ExecuteDelete();
            _db.context.SaveChanges();
        }
        public static void Delete(string _commentId)
        {
            DB _db = new DB();
            Delete(_db, _commentId);
        }
    }
}