using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ObjectDetectionGui.Base
{
    public abstract class NotifiedModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Checks if a property already matches a desired value, if not sets the property and notifies listeners.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.
        /// This value is optional and can be provided automatically when invoked from compilers that support CallerMemberName.</param>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
