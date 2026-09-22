using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Basic_Project_Generator.Interfaces
{
    /// <summary>Una riga di log con il colore con cui va disegnata nella ListBox.</summary>
    public class TraceLine
    {
        public string Text { get; }
        public Color Color { get; }

        public TraceLine(string text, Color color)
        {
            Text = text;
            Color = color;
        }

        public override string ToString() => Text;
    }

    public class TraceWriter : TextWriter
    {
        #region fields

        private readonly ListBox _list;
        private readonly CheckBox _showError;
        private readonly CheckBox _showWarning;
        private readonly CheckBox _showInfo;


        private int _maxHorizontalSize;

        #endregion // fields

        #region ctor

        public TraceWriter(ListBox list, CheckBox showError, CheckBox showWarning, CheckBox showInfo)
        {
            _list = list;
            _showError = showError;
            _showWarning = showWarning;
            _showInfo = showInfo;
        }

        #endregion // ctor

        #region properties

        public override Encoding Encoding => Encoding.UTF8;

        #endregion // properties

        #region methods

        /// <summary>
        /// Writes a log message to trace output, con colore di default.
        /// </summary>
        public override void Write(string value)
        {
            Write(value, TraceColors.Default);
        }

        /// <summary>
        /// Writes a log message to trace output con un colore esplicito
        /// (es. TraceColors.Ok, TraceColors.Warning, TraceColors.Error).
        /// </summary>
        public void Write(string value, Color color)
        {

            if (_showError.Checked && color == TraceColors.Error ||
                _showWarning.Checked && color == TraceColors.Warning ||
                _showInfo.Checked && color == TraceColors.Ok) 
                {

                    base.Write(value);

                    var input = ReplaceSpecialCharacters(value);
                    var timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    var text = timeStamp + "\t" + input;

                    _list.Items.Add(new TraceLine(text, color));
                    _list.SelectedIndex = _list.Items.Count - 1;

                    DisplayHorizontalScroll();

                }
            }

        /// <summary>
        /// Activates the horizontal scroll bar if the message is too long for the trace output
        /// </summary>
        private void DisplayHorizontalScroll()
        {
            _list.IntegralHeight = true;
            _list.HorizontalScrollbar = true;

            var graphics = _list.CreateGraphics();

            var horizontalSize = (int)graphics.MeasureString(_list.Items[_list.Items.Count - 1].ToString(), _list.Font).Width;

            if (horizontalSize > _maxHorizontalSize)
            {
                _maxHorizontalSize = horizontalSize;
            }

            if (_list != null) _list.HorizontalExtent = _maxHorizontalSize;
        }

        /// <summary>
        /// Cancella il contenuto della ListBox e azzera lo scroll orizzontale.
        /// </summary>
        public void Clear()
        {
            _list.Items.Clear();
            _maxHorizontalSize = 0;
            _list.HorizontalExtent = 0;
        }

        /// <summary>
        /// Replace special characters with space
        /// </summary>
        private static string ReplaceSpecialCharacters(string value)
        {
            var result = Regex.Replace(value, "\n|\r|\t", " ");

            return result;
        }

        #endregion // methods
    }
}