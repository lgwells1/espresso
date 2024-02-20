using System.Diagnostics;

namespace Espresso
{
    internal class ContextMenus
    {
        const string thirtyMinutes = "30 Minutes";
        const string oneHour = "1 Hour";
        const string twoHours = "2 Hours";
        const string fourHours = "4 Hours";
        const string eightHours = "8 Hours";

        // Key mapping for tooltip text to time in milliseconds
        Dictionary<string, int> timerMap = new Dictionary<string, int> {
            {thirtyMinutes, 1800000},
            {oneHour, 3600000},
            {twoHours, 7200000},
            {fourHours, 14400000},
            {eightHours, 28800000},
        };

        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            ToolStripLabel lbl = new ToolStripLabel();
            lbl.Text = "Timers";
            menu.Items.Add(lbl);

            item = new ToolStripMenuItem();
            item.Text = thirtyMinutes;
            item.Click += new EventHandler(timerClickedHandler);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = oneHour;
            item.Click += new EventHandler(timerClickedHandler);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = twoHours;
            item.Click += new EventHandler(timerClickedHandler);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = fourHours;
            item.Click += new EventHandler(timerClickedHandler);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = eightHours;
            item.Click += new EventHandler(timerClickedHandler);
            menu.Items.Add(item);

            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new EventHandler(exitClickedHandler);
            menu.Items.Add(item); 

            return menu;
        }

        void timerClickedHandler(object sender, EventArgs e)
        {
            int timeSelected = sender != null ? (int)timerMap[sender.ToString()] : 0;
            AwakeUtility.enableEspressoForTime(timeSelected);
        }

        void exitClickedHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
