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

    /// <summary>
    /// Represents the wpf control generator type.
    /// </summary>
    public static class WpfControlGenerator
    {
        /// <summary>
        /// Vertical colored list.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The vertical colored list result.</returns>
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

        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <returns>The log message result.</returns>
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

        /// <summary>
        /// Get grid with fixed width of column.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="widthColumn">The width column.</param>
        /// <returns>The get grid with fixed width of column result.</returns>
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

        /// <summary>
        /// List view with fixed header.
        /// </summary>
        /// <param name="ActualWidth">The actual width.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="header">The header.</param>
        /// <param name="widthColumn">The width column.</param>
        /// <returns>The list view with fixed header result.</returns>
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
                double columnWidth = widthColumn[index];
                if (columnWidth == 0)
                {
                    showColumns.Add(index, false);
                    items.Add(GridHelper.GetGridLength(0));
                }
                else
                {
                    if (koef != 0)
                    {
                        showColumns.Add(index, true);
                        items.Add(GridHelper.GetGridLength(columnWidth * koef));
                    }
                    else
                    {
                        showColumns.Add(index, true);
                        items.Add(GridHelper.GetGridLength(columnWidth));
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
