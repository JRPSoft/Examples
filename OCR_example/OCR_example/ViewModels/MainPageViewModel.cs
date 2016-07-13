using OCR_example.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;

namespace OCR_example.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Private Fields

        private MainPageModel _model;

        #endregion Private Fields

        #region Public Constructors

        public MainPageViewModel()
        {
            Model = new Models.MainPageModel();
        }

        #endregion Public Constructors

        #region Public Properties

        public MainPageModel Model
        {
            get { return _model; }
            set { Set(ref _model, value); }
        }

        #endregion Public Properties

        #region Public Methods

        public async void OpenImageAndAnalyse()
        {
            StorageFile photo = await PickImage();

            //the language must be installed on the device
            //var installedAndSupportedLanguages = OcrEngine.AvailableRecognizerLanguages;
            OcrEngine ocrEngine = OcrEngine.TryCreateFromLanguage(new Windows.Globalization.Language("en-us"));

            if (ocrEngine != null)
            {
                OcrResult ocrResult = await ConvertImageToText(photo, ocrEngine);
                var stringBuilder = new StringBuilder();

                foreach (var line in ocrResult.Lines)
                {
                    stringBuilder.AppendLine(line.Text);
                }

                Model.TextFound = stringBuilder.ToString();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static async Task<OcrResult> ConvertImageToText(StorageFile photo, OcrEngine ocrEngine)
        {
            OcrResult ocrResult = null;

            //Min Width and Height => 1
            var imageBitmap = new WriteableBitmap(1, 1);
            imageBitmap = await LoadAsync(imageBitmap, photo);

            //Don't forguet the using statement to avoid memory leak
            using (SoftwareBitmap softwareBitmap = SoftwareBitmap.CreateCopyFromBuffer(imageBitmap.PixelBuffer, BitmapPixelFormat.Rgba8, imageBitmap.PixelWidth, imageBitmap.PixelHeight))
            {
                ocrResult = await ocrEngine.RecognizeAsync(softwareBitmap);
            }

            return ocrResult;
        }

        private static async Task<WriteableBitmap> LoadAsync(
                  WriteableBitmap writeableBitmap,
          StorageFile storageFile)
        {
            var wb = writeableBitmap;

            //Don't forguet the using statement to avoid memory leak
            using (var stream = await storageFile.OpenReadAsync())
            {
                await wb.SetSourceAsync(stream);
            }

            return wb;
        }

        private static async Task<StorageFile> PickImage()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".bmp");

            var photo = await picker.PickSingleFileAsync();
            return photo;
        }

        #endregion Private Methods
    }
}