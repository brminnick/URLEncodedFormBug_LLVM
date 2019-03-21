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
            var isPostSuccessful = false;

            IsBusy = true;

            try
            {
                if (shouldUseRefit)
                    isPostSuccessful = await APIService.IsPostSuccessful_Refit();
                else
                    isPostSuccessful = await APIService.IsPostSuccessful();

                if (isPostSuccessful)
                    await Application.Current.MainPage.DisplayAlert("Success!", "", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Failed", "", "Ok");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.ToString(), "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
