using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JM_GluingSystem.Common
{
    class GridHelper
    {
        public static bool GetShowBorder(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowBorderProperty);
        }
        public static void SetShowBorder(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowBorderProperty, value);
        }
        public static readonly DependencyProperty ShowBorderProperty =
            DependencyProperty.RegisterAttached("ShowBorder", typeof(bool), typeof(GridHelper), new PropertyMetadata(OnShowBorderChanged));
        private static void OnShowBorderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as Grid;
            if ((bool)e.OldValue)
            {
                grid.Loaded -= (s, arg) => { };
            }
            if ((bool)e.NewValue)
            {
                grid.Loaded += (s, arg) =>
                {
                    //确定行数
                    var rows = grid.RowDefinitions.Count;
                    //每个格子添加一个Border进去
                    for (int i = 0; i < rows - 1; i++)
                    {
                        var border = new Border() { BorderBrush = new SolidColorBrush(Colors.Gray), BorderThickness = new Thickness(0, 0, 0, 0.5) };
                        Grid.SetRow(border, i);
                        grid.Children.Add(border);

                    }
                };
            }
        }
    }
}
