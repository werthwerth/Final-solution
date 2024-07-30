﻿using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.EFW.Entities;

namespace Final.Static.EntitiesScripts
{
    public class SessionScripts
    {
        public static bool Check(string _sessionId, Core.DB _db, User? _user)
        {
            if (_sessionId == null) 
            {
                return false;
            }
            else
            {
                return SessionEntity.Check(_sessionId, _db, _user);
            }
        }
        public static bool CheckById(string _sessionId, Core.DB _db)
        {
            if (_sessionId == null)
            {
                return false;
            }
            else
            {
                return SessionEntity.CheckBySessionId(_sessionId, _db);
            }
        }
        public static User? GetUserBySessionId(string _sessionId, Core.DB _db)
        {
            User? _user = SessionEntity.GetUserBySessionId(_sessionId, _db);
            if (_user == null)
            {
                return null;
            }
            else
            {
                return _user;
            }
        }
        public static string Start(Core.DB _db, User? _user)
        {
            string _newSessionId = RandomString.Generate();
            SessionEntity.Start(_newSessionId, _db, _user);
            return _newSessionId;
        }
        public static void End(string _sessionId, Core.DB _db)
        {
            SessionEntity.End(_sessionId, _db);
        }
    }
}
