using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballFlick.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CartSession = "CartSession";
        public static string PERMISSIONS_SESSION = "PERMISSIONS_SESSION";
        public static string CurrentCulture { set; get; }

        public static int JoinPoint = 10;
        public static int WinPoint = 50;
        public static int DrawPoint = 20;
        public static int GoalPoint = 10;

        public static int GoalMultiplier = 2;
        public static int AssistMultiplier = 1;
        public static int FairplayMultiplier = 1;

    }
}