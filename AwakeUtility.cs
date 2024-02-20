using Espresso.Properties;
using System.Runtime.InteropServices;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Espresso
{
    internal class AwakeUtility
    {
        public const string STATE_OFF = "off";
        public const string STATE_ON = "on";
        public static string state = STATE_OFF;

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static void enableEspresso()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
            ProcessIcon.updateIcon();
            state = STATE_ON;
        }

        public static void disableEspresso()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            ProcessIcon.updateIcon();
            state = STATE_OFF;
        }

        public static void enableEspressoForTime(int timeSelected)
        {
            if (timeSelected > 0)
            {
                Timer timer = new Timer();
                timer.Elapsed += new ElapsedEventHandler(handleTimerElapsed);
                timer.Interval = timeSelected;
                timer.AutoReset = false; // run once
                timer.Enabled = true;

                enableEspresso();
            }
        }

        private static void handleTimerElapsed(object source, ElapsedEventArgs e)
        {
            disableEspresso();
        }
    }
}
