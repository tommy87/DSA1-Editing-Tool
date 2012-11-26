using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_1_Editing_Tool
{
    public class CDebugger
    {
        private static string DebugText = "";

        public static void addDebugLine(string text)
        {
            DebugText += (text + "\n");
            refreshDebugText(new DebugEventArgs(DebugText, text, DebugMessageTyp.newLine));
        }
        public static void addErrorLine(string text)
        {
            DebugText += (text + "\n");
            refreshDebugText(new DebugEventArgs(DebugText, text, DebugMessageTyp.error));
        }
        public static void clearDebugText()
        {
            DebugText = "";
            refreshDebugText(new DebugEventArgs("", "", DebugMessageTyp.clearMessage));
        }

        public static event EventHandler<DebugEventArgs> IncommingMessage;
        public class DebugEventArgs : EventArgs
        {
            public string text = "";
            public string newLine = "";
            public DebugMessageTyp messageTyp;
            //public SampleEventArgs(string s) { Text = s; }
            //public String Text {get; private set;} // readonly

            public DebugEventArgs(string text, string newLine, DebugMessageTyp messageTyp)
            {
                this.text = text;
                this.newLine = newLine;
                this.messageTyp = messageTyp;
            }
        }

        protected static void refreshDebugText(DebugEventArgs eventArgs)
        {
            if (IncommingMessage != null)
            {
                IncommingMessage(null, eventArgs);
            }
        }

        public enum DebugMessageTyp { newLine, error, clearMessage };
    }
}
