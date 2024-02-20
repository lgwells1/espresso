using Espresso.Properties;

namespace Espresso
{
    class ProcessIcon : IDisposable
    {
        public static NotifyIcon notifyIcon;

        public ProcessIcon()
        {
            notifyIcon = new NotifyIcon();
        }

        public void Display()
        {
            notifyIcon.MouseClick += new MouseEventHandler(notifyIconClickHandler);
            notifyIcon.Icon = Resources.espresso_off;
            notifyIcon.Text = "Espresso";
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = new ContextMenus().Create();
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
        }

        public static void updateIcon()
        {
            notifyIcon.Icon = AwakeUtility.state == AwakeUtility.STATE_ON ? Resources.espresso_on : Resources.espresso_off;
        }

        void notifyIconClickHandler(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                if (AwakeUtility.state == AwakeUtility.STATE_OFF)
                {
                    AwakeUtility.enableEspresso();
                }
                else
                {
                    AwakeUtility.disableEspresso();
                }
            }
        }
    }
}
