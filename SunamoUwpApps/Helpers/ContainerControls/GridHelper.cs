namespace apps.Helpers.ContainerControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class GridHelper
    {

        public static void SetColumnWidthToGrid(Grid grid, List<ColumnDefinition> cdn)
        {
            var cdo = grid.ColumnDefinitions;
            cdo.Clear();
            foreach (var item in cdn)
            {
                cdo.Add(item);
            }
        }

        public static void SetRowHeightToGrid(Grid grid, List<RowDefinition> cdn)
        {
            var cdo = grid.RowDefinitions;
            cdo.Clear();
            foreach (var item in cdn)
            {
                cdo.Add(item);
            }
        }

        public static List<double> SameWidthForAllColumnsDouble(double gridWidth, params bool[] columnsShow)
        {
            int columnsLength = columnsShow.Count();
            var visibleColumns = CA.CountOfValue<bool>(true, columnsShow);
            double forEach = NH.Average(gridWidth, visibleColumns);

            List<double> result = new List<double>(columnsLength);
            for (int index = 0; index < columnsLength; index++)
            {
                if (columnsShow[index])
                {
                    result.Add(forEach);
                }
                else
                {
                    result.Add(0);
                }
            }
            return result;
        }

        public static List<double> SameWidthForAllColumnsDouble(int columnsLength, double gridWidth)
        {
            double forEach = NH.Average(gridWidth, columnsLength);

            List<double> result = new List<double>(columnsLength);
            for (int index = 0; index < columnsLength; index++)
            {
                result.Add(forEach);
            }
            return result;
        }

        public static ColumnDefinition GetColumnDefinition(double oneC)
        {
            return GetColumnDefinition(GetGridLength(oneC));
        }

        public static RowDefinition GetRowDefinition(double oneC)
        {
            return GetRowDefinition(GetGridLength(oneC));
        }

        public static ColumnDefinition GetColumnDefinition(GridLength oneC)
        {
            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = oneC;
            return columnDefinition;
        }

        public static GridLength GetGridLength(double oneC, GridUnitType gut)
        {
            return new GridLength(oneC, gut);
        }

        public static GridLength GetGridLength(double oneC)
        {
            return GetGridLength(oneC, GridUnitType.Pixel);
        }

        /// <summary>
        /// Získané prvky pak aplikuj metodou GridHelper.SetColumnWidthToGrid nebo SetColumnHeightToGrid
        /// 
        /// </summary>
        /// <param name="columnsLength"></param>
        /// <param name="gridWidth"></param>
        public static List<GridLength> SameWidthForAllColumnsGridLength(int columnsLength, double gridWidth)
        {
            double forEach = NH.Average(gridWidth, columnsLength);
                
                List<GridLength> result = new List<GridLength>(columnsLength);
                for (int index = 0; index < columnsLength; index++)
                {
                    result.Add(new GridLength(forEach, GridUnitType.Pixel));
                }
                return result;
           
        }

        public static List<ColumnDefinition> GetColumnDefinitions(List<double> items)
        {
            List<ColumnDefinition> result = new List<ColumnDefinition>();
            foreach (var item in items)
            {
                result.Add(GetColumnDefinition(item));
            }
            return result;
        }

        public static List<RowDefinition> GetRowDefinitions(List<GridLength> items)
        {
            List<RowDefinition> result = new List<RowDefinition>();
            foreach (var item in items)
            {
                result.Add(GetRowDefinition(item));
            }
            return result;
        }

        public static List<ColumnDefinition> GetColumnDefinitions(List<GridLength> items)
        {
            List<ColumnDefinition> result = new List<ColumnDefinition>();
            foreach (var item in items)
            {
                result.Add(GetColumnDefinition(item));
            }
            return result;
        }

        public static Grid CreateGrid(int extentElementAtElement, ButtonWithAction[] bwas)
        {
            Grid grid = new Grid();
            for (int index = 0; index < bwas.Length; index++)
            {
                if (extentElementAtElement == index)
                {
                    grid.ColumnDefinitions.Add(GetColumnDefinition(new GridLength(1, GridUnitType.Star)));
                }
                else
                {
                    grid.ColumnDefinitions.Add(GetColumnDefinition(GridLength.Auto));
                }
            }
            

            for (int itemIndex = 0; itemIndex < bwas.Length; itemIndex++)
            {
                Grid.SetColumn(bwas[itemIndex], itemIndex);
                grid.Children.Add(bwas[itemIndex]);
            }
            return grid;
        }

        public static RowDefinition GetRowDefinition(GridLength auto)
        {
            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = auto;
            return rowDefinition;
        }
    }
