using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace APPSIIF.Helpers
{ 
    /**
     * clase que persiste los diferentes ajustes
     * de la aplicacion
     */
    public static class Settings //PARA LA PERSISTENCIA DE DATOS
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private const string refreshToken = "refreshToken";
        private const string jwtToken = "jwtToken";
        private const string registerCode = "registerCode";
        private const string code = "code";
        private const string userName = "userName";
        private const string version = "version";
        private const string nickName = "nickName";
        private const string isRememberingUserName = "isRememberingUserName";

        private static readonly int intDefault;
        private static readonly double doubleDefault;
        private static readonly string stringDefault = string.Empty;
        private static readonly bool boolDefault;

        public static string RefreshToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(refreshToken, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(refreshToken, value);
            }
        }

        public static string JwtToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(jwtToken, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(jwtToken, value);
            }
        }

        public static string RegisterCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(registerCode, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(registerCode, value);
            }
        }

        public static string Code
        {
            get
            {
                return AppSettings.GetValueOrDefault(code, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(code, value);
            }
        }

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(userName, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userName, value);
            }
        }

        public static string Version
        {
            get
            {
                return AppSettings.GetValueOrDefault(version, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(version, value);
            }
        }

        public static string NickName
        {
            get
            {
                return AppSettings.GetValueOrDefault(nickName, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nickName, value);
            }
        }

        public static bool IsRememberingUserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRememberingUserName, boolDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRememberingUserName, value);
            }
        }


    }
}
