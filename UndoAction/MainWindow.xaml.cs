using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace UndoAction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<UndoClass> undoOps = new Stack<UndoClass>();
        readonly Random _rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private Brush GetRandomBrush()
        {
            byte[] rgb = new byte[3];
            _rng.NextBytes(rgb);

            return new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoClass(button1));
            button1.Background = GetRandomBrush();
            UpdateList();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoClass(button2));
            button2.Background = GetRandomBrush();
            UpdateList();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoClass(button3));
            button3.Background = GetRandomBrush();
            UpdateList();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (undoOps.Count > 0)
            {
                undoOps.Pop().Execute();
                UpdateList();
            }
        }

        private void UpdateList()
        {
            listBox1.Items.Clear();

            foreach (UndoClass action in undoOps)
            {
                listBox1.Items.Add(action.ToString());
            }
        }
    }
}
