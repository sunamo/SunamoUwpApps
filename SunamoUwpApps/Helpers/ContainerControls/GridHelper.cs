namespace apps.Helpers.ContainerControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apps;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the grid helper type.
    /// </summary>
    public static class GridHelper
    {

        /// <summary>
        /// Set column width to grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="cdn">The cdn.</param>
        public static void SetColumnWidthToGrid(Grid grid, List<ColumnDefinition> cdn)
        {
            var cdo = grid.ColumnDefinitions;
            cdo.Clear();
            foreach (var item in cdn)
            {
                cdo.Add(item);
            }
        }

        /// <summary>
        /// Set row height to grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="cdn">The cdn.</param>
        public static void SetRowHeightToGrid(Grid grid, List<RowDefinition> cdn)
        {
            var cdo = grid.RowDefinitions;
            cdo.Clear();
            foreach (var item in cdn)
            {
                cdo.Add(item);
            }
        }

        /// <summary>
        /// Same width for all columns double.
        /// </summary>
        /// <param name="gridWidth">The grid width.</param>
        /// <param name="columnsShow">The columns show.</param>
        /// <returns>The same width for all columns double result.</returns>
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

        /// <summary>
        /// Same width for all columns double.
        /// </summary>
        /// <param name="columnsLength">The columns length.</param>
        /// <param name="gridWidth">The grid width.</param>
        /// <returns>The same width for all columns double result.</returns>
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

        /// <summary>
        /// Get column definition.
        /// </summary>
        /// <param name="oneC">The one c.</param>
        /// <returns>The get column definition result.</returns>
        public static ColumnDefinition GetColumnDefinition(double oneC)
        {
            return GetColumnDefinition(GetGridLength(oneC));
        }

        /// <summary>
        /// Get row definition.
        /// </summary>
        /// <param name="oneC">The one c.</param>
        /// <returns>The get row definition result.</returns>
        public static RowDefinition GetRowDefinition(double oneC)
        {
            return GetRowDefinition(GetGridLength(oneC));
        }

        /// <summary>
        /// Get column definition.
        /// </summary>
        /// <param name="oneC">The one c.</param>
        /// <returns>The get column definition result.</returns>
        public static ColumnDefinition GetColumnDefinition(GridLength oneC)
        {
            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = oneC;
            return columnDefinition;
        }

        /// <summary>
        /// Get grid length.
        /// </summary>
        /// <param name="oneC">The one c.</param>
        /// <param name="gut">The gut.</param>
        /// <returns>The get grid length result.</returns>
        public static GridLength GetGridLength(double oneC, GridUnitType gut)
        {
            return new GridLength(oneC, gut);
        }

        /// <summary>
        /// Get grid length.
        /// </summary>
        /// <param name="oneC">The one c.</param>
        /// <returns>The get grid length result.</returns>
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

        /// <summary>
        /// Get column definitions.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The get column definitions result.</returns>
        public static List<ColumnDefinition> GetColumnDefinitions(List<double> items)
        {
            List<ColumnDefinition> result = new List<ColumnDefinition>();
            foreach (var item in items)
            {
                result.Add(GetColumnDefinition(item));
            }
            return result;
        }

        /// <summary>
        /// Get row definitions.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The get row definitions result.</returns>
        public static List<RowDefinition> GetRowDefinitions(List<GridLength> items)
        {
            List<RowDefinition> result = new List<RowDefinition>();
            foreach (var item in items)
            {
                result.Add(GetRowDefinition(item));
            }
            return result;
        }

        /// <summary>
        /// Get column definitions.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The get column definitions result.</returns>
        public static List<ColumnDefinition> GetColumnDefinitions(List<GridLength> items)
        {
            List<ColumnDefinition> result = new List<ColumnDefinition>();
            foreach (var item in items)
            {
                result.Add(GetColumnDefinition(item));
            }
            return result;
        }

        /// <summary>
        /// Create grid.
        /// </summary>
        /// <param name="extentElementAtElement">The extent element at element.</param>
        /// <param name="bwas">The bwas.</param>
        /// <returns>The create grid result.</returns>
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

        /// <summary>
        /// Get row definition.
        /// </summary>
        /// <param name="auto">The auto.</param>
        /// <returns>The get row definition result.</returns>
        public static RowDefinition GetRowDefinition(GridLength auto)
        {
            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = auto;
            return rowDefinition;
        }
    }
