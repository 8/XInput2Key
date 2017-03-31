namespace XInput2Key
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    [Serializable]
    public class BasePropertyChanged : SynchronizationContextObject, INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            OnPropertyChanged((property.Body as MemberExpression).Member.Name);
        }
    }
}
