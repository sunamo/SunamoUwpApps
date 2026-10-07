namespace apps;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    public static class WpfControlGenerator
    {
        public static StackPanel VerticalColoredList(List<ILogMessage<Color, StorageFile>> items)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            foreach (var item in items)
            {
                Grid grid = new Grid();
                grid.Background = new SolidColorBrush( item.Bg);
                TextBlock textBlock = new TextBlock();
                textBlock.Text = item.Message;
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, 0);
                grid.Children.Add(textBlock);
                stackPanel.Children.Add(grid);
            }
            return stackPanel;
        }

        public static Grid LogMessage(ILogMessage<Color, StorageFile> logMessage)
        {
                Grid grid = new Grid();
                grid.Background = new SolidColorBrush(logMessage.Bg);
                TextBlock textBlock = new TextBlock();
                textBlock.Text = logMessage.Message;
            textBlock.TextWrapping = TextWrapping.WrapWholeWords;
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, 0);
                grid.Children.Add(textBlock);
            return grid;
        }

        /// <summary>
        /// První položka v každém řádku bude jednoznačné ID které se bude předávat do obsluhy příkazu když se klikne na položku
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="widthColumn"></param>
        public static ListViewItem GetListViewItemsWithFixedWidthOfColumn(List<string> rows, List<GridLength> widthColumn)
        {
            Grid grid = GetGridWithFixedWidthOfColumn(rows, widthColumn);

            ListViewItem lvi = new ListViewItem();
            lvi.Content = grid;
            return lvi;
            //return g;
        }

        public static Grid GetGridWithFixedWidthOfColumn(List<string> rows, List<GridLength> widthColumn)
        {
            Grid grid = new Grid();
            foreach (var item in widthColumn)
            {
                grid.ColumnDefinitions.Add(GridHelper.GetColumnDefinition( item));
            }
            for (int second = 0; second < rows.Count; second++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = rows[second];
                Grid.SetColumn(textBlock, second);
                grid.Children.Add(textBlock);
            }
            //}
            return grid;
        }

        public static UIElement ListViewWithFixedHeader(double ActualWidth, List<List<string>> rows, List<string> header, List<double> widthColumn)
        {
            SunamoDictionary<int, bool> showColumns = new SunamoDictionary<int, bool>();
            double sum = widthColumn.Sum();
            double koef = 0;
            if (sum > ActualWidth)
            {
                koef = (ActualWidth - sum);
            }
            else if (sum < ActualWidth)
            {
                koef = ActualWidth / sum;
            }

            List<GridLength> items = new List<GridLength>(showColumns.Count);
            for (int index = 0; index < widthColumn.Count; index++)
            {
                double value2 = widthColumn[index];
                if (value2 == 0)
                {
                    showColumns.Add(index, false);
                    items.Add(GridHelper.GetGridLength(0));
                }
                else
                {
                    if (koef != 0)
                    {
                        showColumns.Add(index, true);
                        items.Add(GridHelper.GetGridLength(value2 * koef));
                    }
                    else
                    {
                        showColumns.Add(index, true);
                        items.Add(GridHelper.GetGridLength(value2));
                    }
                }
            }

            VirtualizingStackPanel vsp = new VirtualizingStackPanel();

            //ObservableCollection<ListViewItem> lvi = new ObservableCollection<ListViewItem>();
            for (int itemIndex = 0; itemIndex < rows.Count; itemIndex++)
            {
                var lvi = GetListViewItemsWithFixedWidthOfColumn(rows[itemIndex], items);
                //lvi.Add( );
                vsp.Children.Add(lvi);
            }

            return vsp;
        }
    }
