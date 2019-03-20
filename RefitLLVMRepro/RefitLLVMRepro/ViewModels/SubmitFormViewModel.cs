using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using Xamarin.Forms;

namespace RefitLLVMRepro
{
    public class SubmitFormViewModel : BaseViewModel
    {
        #region Fields
        bool _isBusy;
        ICommand _submitButtonTappedCommand;
        #endregion

        #region Properties
        public ICommand SubmitButtonTappedCommand => _submitButtonTappedCommand ??
            (_submitButtonTappedCommand = new AsyncCommand<bool>(ExecuteSubmitButtonCommand, continueOnCapturedContext: false));

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        #endregion

        #region Methods
        async Task ExecuteSubmitButtonCommand(bool shouldUseRefit)
        {
            const int punNumber = 321;
            const string wrongAnswer = "wrong answer";

            bool isUserTextCorrect = false, isInternetConnectionAvailable = false;

            IsBusy = true;

            try
            {
                if (shouldUseRefit)
                    (isUserTextCorrect, isInternetConnectionAvailable) = await APIService.IsUserTextCorrect_IsInternetConnectionAvailable(punNumber, wrongAnswer);
                else
                    (isUserTextCorrect, isInternetConnectionAvailable) = await APIService.PostAsyncWithFormUrlEncodedContent(punNumber, wrongAnswer);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.ToString(), "OK");
            }
            finally
            {
                IsBusy = false;
            }

            if (!isInternetConnectionAvailable)
                await Application.Current.MainPage.DisplayAlert("Failed to Connect", "", "Ok");
            else if (isUserTextCorrect)
                await Application.Current.MainPage.DisplayAlert("User Input Correct?", "", "Ok");
            else
                await Application.Current.MainPage.DisplayAlert("Success!", "", "Ok");
        }
        #endregion
    }
}
