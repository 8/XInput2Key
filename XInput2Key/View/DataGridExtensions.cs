using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace XInput2Key.View
{
    public static class DataGridExtensions
    {
        #region DataContext

        public static object GetColumnDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(ColumnDataContextProperty);
        }

        public static void SetColumnDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(ColumnDataContextProperty, value);
        }

        public static readonly DependencyProperty ColumnDataContextProperty =
            DependencyProperty.RegisterAttached("ColumnDataContext", typeof(object), typeof(DataGridExtensions), new PropertyMetadata(null, OnColumnDataContextChanged));

        private static void OnColumnDataContextChanged(object owner, DependencyPropertyChangedEventArgs e)
        {
            UpdateColumnsDataContext(owner as DataGrid, e.NewValue);
        }

        private static void UpdateColumnsDataContext(DataGrid dataGrid, object dataContext)
        {
            if (dataGrid != null)
            {
                foreach (var c in dataGrid.Columns)
                    c.SetValue(FrameworkElement.DataContextProperty, dataContext);

                dataGrid.Columns.CollectionChanged += (o, e) => Columns_CollectionChanged(dataContext, e);
            }
        }

        private static void Columns_CollectionChanged(object dataContext, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var c in e.NewItems.OfType<DataGridColumn>())
                    c.SetValue(FrameworkElement.DataContextProperty, dataContext);
            }
        }

        #endregion

    }
}
