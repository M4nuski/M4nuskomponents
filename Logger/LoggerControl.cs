using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class LoggerControl : UserControl
    {
        private StringBuilder _builder = new StringBuilder();
        //TODO add logfile
        //TODO add timestamps

        public LoggerControl()
        {
            InitializeComponent();
        }

        public void AddLine(string text)
        {
            _builder.AppendLine(text);
            OutputTextBox.Text = _builder.ToString();
        }

        public void AddText(string text)
        {
            _builder.Append(text);
            OutputTextBox.Text = _builder.ToString();
        }

        public void Clear()
        {
            _builder.Clear();
            OutputTextBox.Clear();
        }


    }
}
