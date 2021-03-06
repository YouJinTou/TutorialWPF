﻿using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }

    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= this.PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += this.PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
}
