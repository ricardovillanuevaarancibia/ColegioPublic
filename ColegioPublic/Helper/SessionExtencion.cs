using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ColegioPublic.Helper
{
   
    public static class SessionExtencion
    {
        public enum Datos
        {
            Rol,
            Correo,
            UsuarioId,
        }
        #region HttpSessionStateBase


          
            public static T Get<T>(this HttpSessionStateBase session, Datos key)
            {
                var obj = session[key.ToString()];

                if (obj != null)
                    return (T)obj;

                throw new Exception("Type '" + typeof(T).Name + "' doesn't match the type of the object retreived ('" + obj.GetType().Name + "').");
            }
            public static void Put<T>(this HttpSessionStateBase session, string name, object value) => session[name] = value;
        public static string GetRol(this HttpSessionStateBase session)
        {
            var obj = session[Datos.Rol.ToString()].ToString();
            return obj;
        }

        #endregion

        #region HttpSessionState
        public static string GetRol(this HttpSessionState session)
        {
            var obj = session[Datos.Rol.ToString()].ToString();
            return obj;
        }

        public static T Get<T>(this HttpSessionState session, Datos key)
            {
                var obj = session[key.ToString()];

                if (obj == null || typeof(T).IsAssignableFrom(obj.GetType()))
                    return (T)obj;

                throw new Exception("Type '" + typeof(T).Name + "' doesn't match the type of the object retreived ('" + obj.GetType().Name + "').");
            }

            public static void Put<T>(this HttpSessionState session, T obj, Datos key)
            {
                session[key.ToString()] = obj;
            }

            #endregion
            public static int GetUserId(this HttpSessionState session)
            {
              return Convert.ToInt32(session[Datos.UsuarioId.ToString()]);
            }
            public static bool IsLogin(this HttpSessionStateBase session)
            {

            try
            {
                if (String.IsNullOrEmpty(session[Datos.UsuarioId.ToString()].ToString()))
                {
                    
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }      
            }







    }
}