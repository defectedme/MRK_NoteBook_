using MRK_NoteBook.Data;
using MRK_NoteBook.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRK_NoteBook.ViewModel
{


    public class LoginViewModel
    {

        private string _userName, _password;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public ICommand RegisterCommand { private set; get; }

        public ICommand LoginCommand { private set; get; }

        private INavigation Navigation;

        public LoginViewModel(INavigation navigation)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            Navigation = navigation;
        }
        private async void OnLoginCommand(object obj)
        {
            var loginDB = await App.LoginDatabase.GetLoginDataAsync(UserName);
            if (loginDB != null)
            {
                if (string.Equals(loginDB.Password, Password))
                {
                    //await Navigation.PushModalAsync(new ProductsPageView());
                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("failure", "Invalid Password", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("failure", "Invalid Username", "Ok");
            }
        }


        private void OnRegisterCommand(object obj)
        {
            ToDo lm = new ToDo();
            lm.UserName = UserName;
            lm.Password = Password;
            App.LoginDatabase.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration Successful", "Ok");
        }
    }
}
