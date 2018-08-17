using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ObjectDetectionGui.Base
{
    public static class DpUtil
    {
        public static DependencyProperty Register<TProp>(string propertyName, TProp defaultValue = default(TProp), PropertyChangedCallback propertyChangedCallback = null)
        {
            return DependencyProperty.Register(propertyName, typeof(TProp), GetOwnerType(), new PropertyMetadata(defaultValue, propertyChangedCallback));
        }


        public static DependencyProperty RegisterWithOptions<TProp>(string propertyName, FrameworkPropertyMetadataOptions options,
            TProp defaultValue = default(TProp), PropertyChangedCallback propertyChangedCallback = null)
        {
            return DependencyProperty.Register(propertyName, typeof(TProp), GetOwnerType(), new FrameworkPropertyMetadata(defaultValue, options, propertyChangedCallback));
        }


        private static Type GetOwnerType()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }


        public static void SetBinding(object source, string sourceProperty, DependencyObject target, DependencyProperty dp,
            string stringFormat = null, BindingMode mode = BindingMode.Default)
        {
            if (source == null || string.IsNullOrWhiteSpace(sourceProperty))
                return;

            Binding binding = new Binding(sourceProperty);
            binding.ConverterCulture = CultureInfo.CurrentCulture;
            binding.Source = source;
            if (!string.IsNullOrWhiteSpace(stringFormat))
                binding.StringFormat = stringFormat;

            binding.Mode = mode;
            BindingOperations.SetBinding(target, dp, binding);
        }
    }
}
