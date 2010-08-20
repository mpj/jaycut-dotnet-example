using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace JayCutExample
{
    public enum Method
    {   
        // ReSharper disable InconsistentNaming
        GET,
        POST,
        PUT, 
        DELETE
        // ReSharper restore InconsistentNaming
    }

    /// <summary>
    /// Example wrapper around the JayCut REST Service.
    /// </summary>
    public class JayCutter
    {
        public string JayCutApiSecret { get; set; }
        public string JayCutUriAuthority { get; set; }
        public string JayCutApiKey { get; set; }

        /// <summary>
        /// Constructs a Uri for a given jaycut API command, with authentication querystring added.
        /// </summary>
        /// <param name="command">The command path, beginning with a slash. Example: /Users/wayne.johnson</param>
        /// <param name="method">The method of the command. Example: PUT</param>
        /// <param name="doLogin">If this is set to true, the command uri will cause a session cookie to be set on the client, which means that further 
        /// commands from that client won't need the authentication string. An url with this set to true is required by the Flash Mixer.</param>
        /// <returns></returns>
        public string GetUri(string command, Method method, bool doLogin)
        {
            var expires = ToUnixTimestamp(DateTime.Now.AddDays(1));
            var signatureBase = JayCutApiSecret + method + command + expires;
            return "http://" + JayCutUriAuthority
                   + command +
                   "?login=" + doLogin +
                   "&api_key=" + JayCutApiKey +
                   "&signature=" + ToSHA1Hash(signatureBase) +
                   "&expires=" + expires +
                   "&_method=" + method;
                    // Some clients have a problem with PUT and DELETE, _method insures 
                    // that that there are no misunderstandings. 
        }

        /// <summary>
        /// The simplest of simplest implementation. It creates a new user
        /// and logs him in. This is really only useful when you want to give a non-logged in
        /// a demo of the editor.
        /// </summary>
        /// <returns></returns>
        public string JayCutLoginUriSimple()
        {
            // A POST to /users will create a new user on the JayCut REST API,
            // and if doLogin is set to true, sign that user in (which is needed by Flash Mixer)
            return GetUri("/users", Method.POST, true);
        }

        /// <summary>
        /// Get a login URI for user with a specific ID. This is a really handy method 
        /// for integrating the JayCut editor into your own community, using your own user database 
        /// and login system.
        /// </summary>
        /// <param name="userId">The id of the user you want to create on the Jaycut system.
        /// This can, for instance, be the id of the user in your own user database.
        /// <returns>An url that signs in (and creates, if needed) the user with userId.</returns>
        public string JayCutLogUriForUser(string userId)
        {
            var commandPath = "/users/" + userId;
            return GetUri(commandPath, Method.PUT, true);
        }




        #region Internal helper methods

        /// <summary>
        /// Converts a DateTime to a standard unix timestamp.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Unix timestamp as a long.</returns>
        private static long ToUnixTimestamp(DateTime dt)
        {
            var unixRef = new DateTime(1970, 1, 1, 0, 0, 0);
            return (dt.Ticks - unixRef.Ticks) / 10000000;
        }


        /// <summary>
        /// Calculates SHA1 sigurature from a string, 
        /// identical in functionality to the "sha1" function of PHP.
        /// </summary>
        /// <param name="text">input string</param>
        /// <returns>SHA1 hash</returns>
        private static string ToSHA1Hash(string text)
        {
            return ToSHA1Hash(text, Encoding.UTF8);
        }

        /// <summary>
        /// Calculates SHA1 sigurature from a string.
        /// </summary>
        /// <param name="text">input string</param>
        /// <param name="enc">Character encoding</param>
        /// <returns>SHA1 hash</returns>
        private static string ToSHA1Hash(string text, Encoding enc)
        {
            var hashBytes = SHA1.Create().ComputeHash(enc.GetBytes(text.Trim()));
            var hashBuilder = new StringBuilder();
            foreach (var hashByte in hashBytes)
                hashBuilder.Append(hashByte.ToString("x2", CultureInfo.InvariantCulture));
            return hashBuilder.ToString();
        }



        #endregion

    }


}
