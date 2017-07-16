using System;
using System.Windows;

namespace Fasetto.Word
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        public static Parent Instance { get; private set; } = new Parent();

        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.RegisterAttached(
                "Value",
                typeof(Property),
                typeof(BaseAttachedProperty<Parent, Property>),
                new UIPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }

        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(sender, e);
            //Instance.ValueChanged(sender, e);
        }
    }
}
