namespace APPSIIF
{
    public class Constants
    {
        // url Services AS400
        public const string URLAS400 = "https://app.sistemasgyg.com.co/";

        //url base images
        public const string URLImg = "https://imgappgyg.s3-sa-east-1.amazonaws.com/";

        //NameSpace Paginas
        public const string NameSpace = "APPSIIF.Views";

        //Start Color Application
        public const string StartColor = "#20BDFF";

        //End Color Application
        public const string EndColor = "#5433FF";

        //Start Color Application
        public const string StartColorBack = "#79D7FF";

        //End Color Application
        public const string EndColorBack = "#DADEE8";

        //Start Color Application
        public const string BackColorLight = "#E6EBF7";

        //End Color Application
        public const string ItemColorLight = "#FFFFFF";

        //Start Color Application
        public const string BackColorDark = "#080B0A";

        //End Color Application
        public const string ItemColorDark = "#212626";

        //identity pool id for cognito credentials
        public const string IdentityPoolId = "us-west-2:985d522c-d846-4ed3-bc23-75e31439dd68";

        public const string IdentityPoolIdIos = "us-west-2:99868cb6-441e-4776-9919-be8fa0895568";

        //sns android platform arn
        public const string AndroidPlatformApplicationArn = "arn:aws:sns:us-west-2:541124734067:app/GCM/sns_siifmovil_android";

        //sns ios platform arn
        public const string iOSPlatformApplicationArn = "arn:aws:sns:us-west-2:541124734067:app/APNS_SANDBOX/sns_siifmovil_io2";

        //project id for android gcm
        public const string GoogleConsoleProjectId = "273073111012";

        //public static RegionEndpoint CognitoRegion = RegionEndpoint.USWest2;
        //public static RegionEndpoint SnsRegion = RegionEndpoint.USWest2;

        public const int MaxTransaction = 10000000;
        public const int MinTransaction = 10000;
        public const int AccountValue = 0;

    }
}
