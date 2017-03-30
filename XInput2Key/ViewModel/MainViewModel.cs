namespace XInput2Key.ViewModel
{
    using System.Windows.Input;

    public interface IMainViewModel
    {
    }

    public class MainViewModel : IMainViewModel
    {
        #region StartListenCommand
        private ICommand _StartListenCommand;
        public ICommand StartListenCommand
        {
            get
            {
                if (_StartListenCommand == null)
                    _StartListenCommand = new RelayCommand(call => StartListen());
                return _StartListenCommand;
            }
        }
        #endregion

        public void StartListen()
        {
        }

    }
}
