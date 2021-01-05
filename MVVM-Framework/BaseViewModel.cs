using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// Fires <see cref="PropertyChanged"/> events on demand.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// The event that is fired when a property's value changes.
    /// </summary>
    private event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Fires a <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the property whose value has changed.</param>
    public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Sets a property's value.
    /// </summary>
    /// <typeparam name="T">The property's type.</typeparam>
    /// <param name="property">The referenced property's current value.</param>
    /// <param name="updatedValue">The updated value to set.</param>
    /// <param name="propertyName">The name of the property that invoked this method.</param>
    public void SetProperty<T>(ref T property, T updatedValue, [CallerMemberName]string propertyName = "")
    {
        if (Equals(property, updatedValue)) { return; }
        else
        {
            property = updatedValue;
            NotifyPropertyChanged(propertyName);
        }
    }
}
