namespace WpfPresentation.ViewModel
{
    using Model;
    using System.ComponentModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        private MainView _view;
        private MainModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _view = new MainView();
            _model = new MainModel();
        }

        // action to add
        public void Add()
        {
            _model.Number++;
        }
    }
}
