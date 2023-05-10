using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace MES.RTBLOGGER
{
    public class MrtbLogger
    {
        private System.Windows.Forms.RichTextBox TextEventLog;
        public void setLogger(RichTextBox Rtb)
        {
            TextEventLog = Rtb;
        }

        //public Color Cinfo { get; set; } = Color.LightGray;
        //public Color Cerror { get; set; } = Color.Red;
        //public Color Cwarn { get; set; } = Color.Orange;
        //public Color Cpass { get; set; } = Color.LightGreen;

        public Color Cinfo { get; set; }    = Color.Black;
        public Color Cerror { get; set; }   = Color.Red;
        public Color Cwarn { get; set; }    = Color.Orange;
        public Color Cpass { get; set; }    = Color.Green;

        //standard objects for text size
        public string familyName { get; set; } = "Arial";
        public float emSize { get; set; } = 11;
        public float emSizeBig { get; set; } = 22;
        public FontStyle style { get; set; } = FontStyle.Regular;


        public bool AutoScroll { get; set; } = true;

        public void Log(Color TextColor, string EventText, Font _font)
        {
            if(TextEventLog != null)
            {
                //Invoke if needed
                if (TextEventLog.InvokeRequired)
                {
                    TextEventLog.BeginInvoke(new Action(delegate {
                        Log(TextColor, EventText, _font);
                    }));
                    return;
                }

                //set selected font
                TextEventLog.SelectionFont = _font;

                string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

                // color text.
                TextEventLog.SelectionStart = TextEventLog.Text.Length;
                TextEventLog.SelectionColor = TextColor;

                // newline if first line, append if else.
                if (TextEventLog.Lines.Length == 0)
                {
                    TextEventLog.AppendText(nDateTime + EventText);
                    TextEventLog.ScrollToCaret();
                    TextEventLog.AppendText(System.Environment.NewLine);
                }
                else
                {
                    TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                    if (this.AutoScroll)
                    {
                        TextEventLog.ScrollToCaret();
                    }
                }
            }

        }


        public void Info(string text, bool big = false)
        {
            Font font = new Font(familyName, emSize, style);
            if (big) font = new Font(familyName, emSizeBig, style);
            Log(Cinfo, text, font);
        }

        public void Warn(string text, bool big = false)
        {
            Font font = new Font(familyName, emSize, style);
            if (big) font = new Font(familyName, emSizeBig, style);

            Log(Cwarn, text, font);
        }

        public void Error(string text, bool big = false)
        {
            Font font = new Font(familyName, emSize, style);
            if (big) font = new Font(familyName, emSizeBig, style);

            Log(Cerror, text, font);
        }

        public void Pass(string text, bool big = false)
        {
            Font font = new Font(familyName, emSize, style);
            Log(Cpass, text, font);
        }

        public void clear()
        {
            if (TextEventLog.InvokeRequired)
            {
                TextEventLog.BeginInvoke(new Action(delegate {
                    clear();
                }));
                return;
            }

            TextEventLog.Clear();
        }

        public static int SaveLoggedText(RichTextBox TextEventLog, string path)
        {
            TextWriter writer = new StreamWriter(path);
            try
            {
                writer.Write(TextEventLog.Text);
                writer.Close();
            }
            catch
            {
                writer.Close();
                return 1;
            }

            return 0;
        }
    }
}
