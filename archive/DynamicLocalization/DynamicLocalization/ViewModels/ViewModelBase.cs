using DynamicLocalization.Messages;

namespace DynamicLocalization.ViewModels
{
    internal class ViewModelBase : BindableBase, INavigationAware, IPageLifecycleAware
    {
        public ViewModelBase(INavigationService navigationService) 
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; set; }

        public void OnAppearing()
        {
            MessagingCenter.Subscribe<object>(Application.Current, CultureChangedMessage.Message, (s) => { UpdateLocalizedItems(); });
        }

        public void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<object>(Application.Current, CultureChangedMessage.Message);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            UpdateLocalizedItems();            
        }

        protected virtual void UpdateLocalizedItems()
        {
        }
    }
}
