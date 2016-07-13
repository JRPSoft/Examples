namespace OCR_example.Models
{
    public class MainPageModel : Template10.Mvvm.BindableBase
    {
        #region Private Fields

        private string _textFound;

        #endregion Private Fields

        #region Public Properties

        public string TextFound
        {
            get { return _textFound; }
            set { Set(ref _textFound, value); }
        }

        #endregion Public Properties
    }
}