using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PaintCanvas : Window
    {
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            Paint.App app = new Paint.App();
            app.InitializeComponent();
            app.Run();
        }

        public PaintCanvas()
        {
            InitializeComponent();
            clear_button();
            CreateGrid();
        }

        private void ClearCanvasClick(object sender, EventArgs e)
        {
            canv.Strokes.Clear();
        }

        void ColorChange(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            canv.DefaultDrawingAttributes.Color = ((SolidColorBrush)button.Background).Color;
        }

        private void clear_button()
        {
            Button button = new Button();
            button.Content = "Clear";
            button.Width = 80;
            button.Height = 25;
            paintGrid.Children.Add(button);
            button.Margin = new Thickness(30,2,0,0);
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.Click += ClearCanvasClick;
        }

        private void CreateGrid()
        {
            ListBox c = CreateBox(MakeColorButtons()); 
            paintGrid.Children.Add(c);
        }

        private ListBox CreateBox(List<Button> b)
        {
            ListBox box = new ListBox();
            WrapPanel wrap = new WrapPanel();
            box.Width = 130;
            wrap.Width = 115;
            box.Height = 55;
            wrap.Height = 50;
            box.Margin = new Thickness(135,2,0,0);
            box.HorizontalAlignment = HorizontalAlignment.Left;
            box.VerticalAlignment = VerticalAlignment.Top;
            foreach (Button cb in b)
            {
                wrap.Children.Add(cb);
            }
            box.Items.Add(wrap);
            return box;
        }

        public Color GetColor(string hex)
        {
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            Color c = Color.FromArgb(a, r, g, b);
            return c;
        }
        
        private List<Button> MakeColorButtons()
        {
            List<Color> colors = new List<Color>();
            List<string> hexCol = new List<string>()
            {"FFE4321D", "FFE4811D", "FFF0F115", "FF38C729",
             "FF155FBF", "FF9C0F98", "FF000000"};
            List<Button> button = new List<Button>();
            hexCol.ForEach(el => colors.Add(GetColor(el)));
            for(int i = 0; i < 7; i++)
            {
                Button bu = new Button();
                bu.Background = new SolidColorBrush(colors[i]);
                bu.Width = 18;
                bu.Height = 18;
                bu.Margin = new Thickness(6, 1, 2, 1);
                bu.Click += new RoutedEventHandler(ColorChange);
                button.Add(bu);
            }
            return button;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            canv.DefaultDrawingAttributes.Width = 2;
            canv.DefaultDrawingAttributes.Height = 2;
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            canv.DefaultDrawingAttributes.Width = 1;
            canv.DefaultDrawingAttributes.Height = 1;
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            canv.DefaultDrawingAttributes.Width = 4;
            canv.DefaultDrawingAttributes.Height = 4;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            canv.DefaultDrawingAttributes.Width = 8;
            canv.DefaultDrawingAttributes.Height = 8;
        }
    }
}

