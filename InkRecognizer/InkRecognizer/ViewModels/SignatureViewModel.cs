using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InkRecognizer.Model;
using MvvmHelpers;
using SignaturePad.Forms;
using Xamarin.Forms;
using System.Linq;
using System.Text;

namespace InkRecognizer.ViewModels
{
    public class SignatureViewModel : BaseViewModel
    {

        private ObservableCollection<IEnumerable<Xamarin.Forms.Point>> strokes;

        public ObservableCollection<IEnumerable<Xamarin.Forms.Point>> SignatureStrokes
        {
            set
            {
                strokes = value;
                OnPropertyChanged();
            }

            get => strokes;
        }


        public Command RecognizeCommand => new Command(async () =>
        {

            InkRecognizerRequest request = new InkRecognizerRequest();
            int id = 0;

            foreach (var stroke in SignatureStrokes)
            {

                request.strokes.Add(new Stroke { id = id, points = stroke.ToList().ToModelPoints() });
                
                id++;
            }

            var result = await Helpers.InkRecognizerHelper.Recognize(request);


            var lines = result.recognitionUnits.Where(x => x.category.Equals("line")).ToList();


            StringBuilder stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                string text = string.Empty;
                foreach (var child in line.childIds)
                {

                    text += result.recognitionUnits.FirstOrDefault(x => x.id == child).recognizedText;

                }
                stringBuilder.AppendLine(text);
            }

           await Application.Current.MainPage.DisplayAlert("Resultado", stringBuilder.ToString(), "Ok");
        });

        public SignatureViewModel()
        {

        }
    }
}
