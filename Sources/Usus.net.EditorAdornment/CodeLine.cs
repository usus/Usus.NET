using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View.ViewModels.Current;

namespace andrena.Usus_net_EditorAdornment
{
    public static class CodeLine
    {
        //"^(private |protected |public |internal )?(static |virtual new |virtual |new |override |override sealed )?([_a-zA-Z]+[\._a-zA-Z0-9\[\]]*(<.*>)?) ([_a-zA-Z]+[\._a-zA-Z0-9\[\]]*(<.*>)?)\((((out |ref |this |params )?([_a-zA-Z]+[\._a-zA-Z0-9\[\]]*(<.*>)?) ([_a-zA-Z]+[_a-zA-Z0-9]*([ ]?=[ ]?[^,<> ]*)?))?(,[ ]?(out |ref |params )?([_a-zA-Z]+[\._a-zA-Z0-9\[\]]*(<.*>)?) ([_a-zA-Z]+[_a-zA-Z0-9]*([ ]?=[ ]?[^,<> ]*)?))*)\)$"
        static Regex methodMatcher = new Regex(string.Format("^{0}{1} {1}\\((((out |ref |this |params )?{1} {2})?(,[ ]?(out |ref |params )?{1} {2})*)\\)$", "(private |protected |public |internal )?(static |virtual new |virtual |new |override |override sealed )?", "([_a-zA-Z]+[\\._a-zA-Z0-9\\[\\]]*(<.*>)?)", "([_a-zA-Z]+[_a-zA-Z0-9]*([ ]?=[ ]?[^,<> ]*)?)"));
        public static bool IsMethodDefinition(this string line)
        {
            return methodMatcher.IsMatch(line.Trim());
        }

        public static UIElement ElementAt(int line, Func<string> file)
        {
            Image image = new Image() { Source = GetCodeTagBitmap(), Width = 10, Height = 10 };
            Button button = new Button() { Content = image };
            button.Click += (s, e) => DisplayMethodInfo(file, line);
            return button;
        }

        static BitmapImage codeTagImage;
        private static BitmapImage GetCodeTagBitmap()
        {
            if (codeTagImage == null)
                codeTagImage = new BitmapImage(new Uri("pack://application:,,,/Usus.net.EditorAdornment;component/Resources/metricstag.bmp"));
            return codeTagImage;
        }

        private static void DisplayMethodInfo(Func<string> file, int line)
        {
            GlobalEventManager.Instance.FireEvent(UsusNetWindow.Current, 
                new LineLocation { Line = line, File = file() });
        }
    }
}
