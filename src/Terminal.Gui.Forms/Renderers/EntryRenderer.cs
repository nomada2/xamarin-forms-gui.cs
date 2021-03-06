﻿using System.ComponentModel;
using Terminal.Gui.Forms.EventArgs;
using Xamarin.Forms;

namespace Terminal.Gui.Forms.Renderers
{
    public class EntryRenderer : ViewRenderer<Entry, TextField>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new TextField(string.Empty));
                    Control.Changed += OnTextChanged;
                }

                UpdateText();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                UpdateText();
            }
        }

        void UpdateText()
        {
            Control.Text = Element.Text ?? string.Empty;
        }

        void OnTextChanged(object sender, System.EventArgs e)
        {
            ((IElementController)Element).SetValueFromRenderer(Entry.TextProperty, Control.Text.ToString());
        }
    }
}