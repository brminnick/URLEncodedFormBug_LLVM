using Xamarin.Forms;

namespace RefitLLVMRepro
{
    public class SubmitFormPage : ContentPage
    {
        public SubmitFormPage()
        {
            BindingContext = new SubmitFormViewModel();

            var submitWithRefitButton = new Button
            {
                CommandParameter = true,
                Text = "Submit with Refit"
            };
            submitWithRefitButton.SetBinding(Button.CommandProperty, nameof(SubmitFormViewModel.SubmitButtonTappedCommand));

            var submitWithoutRefitButton = new Button
            {
                CommandParameter = false,
                Text = "Submit without Refit"
            };
            submitWithoutRefitButton.SetBinding(Button.CommandProperty, nameof(SubmitFormViewModel.SubmitButtonTappedCommand));

            var activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(IsVisibleProperty, nameof(SubmitFormViewModel.IsBusy));
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(SubmitFormViewModel.IsBusy));

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    submitWithRefitButton,
                    submitWithoutRefitButton,
                    activityIndicator
                }
            };
        }
    }
}
