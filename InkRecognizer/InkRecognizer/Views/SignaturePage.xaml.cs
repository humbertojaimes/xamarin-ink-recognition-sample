using System;
using System.Collections.Generic;
using InkRecognizer.ViewModels;
using SignaturePad.Forms;
using Xamarin.Forms;

namespace InkRecognizer.Views
{
    public partial class SignaturePage : ContentPage
    {
        public SignaturePage()
        {
            InitializeComponent();
        }

        void SignaturePadView_StrokeCompleted(System.Object sender, System.EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            if (BindingContext is SignatureViewModel signatureViewModel && sender is SignaturePadView signaturePad)
            {
                signatureViewModel.SignatureStrokes = new System.Collections.ObjectModel.ObservableCollection<IEnumerable<Point>>(signaturePad.Strokes);
                signaturePad.StrokeColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }

        }
    }
}
