using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Basic_Project_Generator.Interfaces
{
    public class TraceWriter : TextWriter
    {
        #region fields

        private readonly ListBox _list;
        private StringBuilder _content;
        private int _maxHorizontalSize;

        #endregion // fields

        #region ctor

        public TraceWriter(ListBox list)
        {
            _content = new StringBuilder();
            _list = list;
        }

        #endregion // ctor

        #region properties

        public override Encoding Encoding => Encoding.UTF8;

        #endregion // properties

        #region methods

        /// <summary>
        /// Writes a log message to trace output
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            base.Write(value);

            var input = ReplaceSpecialCharacters(value);
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            _content.Append(timeStamp + "\t" + input);
            _list.Items.Add(_content.ToString());
            _list.SelectedIndex = _list.Items.Count - 1;
            _content = new StringBuilder();

            DisplayHorizontalScroll();
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
        /// Replace special characters with space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ReplaceSpecialCharacters(string value)
        {
            var result = Regex.Replace(value, "\n|\r|\t", " ");

            return result;
        }

        #endregion // methods
    }
}
