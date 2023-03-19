using MRK_NoteBook.Data;
using MRK_NoteBook.DataServices;
using MRK_NoteBook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRK_NoteBook.ViewModel
{



    public class SecureFolderViewModel 
    {
        private string _secureuserName, _securepassword;

        public string SecureUserName { get => _secureuserName; set => _secureuserName = value; }
        public string SecurePassword { get => _securepassword; set => _securepassword = value; }

        public ICommand RegisterSecureCommand { private set; get; }

        public ICommand LoginSecureCommand { private set; get; }

        private readonly INavigation Navigation;

        public SecureFolderViewModel(INavigation navigation)
        {
            RegisterSecureCommand = new Command(OnRegisterCommand);
            LoginSecureCommand = new Command(OnLoginCommand);
            Navigation = navigation;
        }
        private async void OnLoginCommand(object obj)
        {
            var loginDB = await App.secureLoginDatabase.GetLoginDataAsync(SecureUserName);
            if (loginDB != null)
            {
                if (string.Equals(loginDB.SecurePassword, SecurePassword))
                {
                    Application.Current.MainPage = new SecureItemsView();


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
            lm.SecureUserName = SecureUserName;
            lm.SecurePassword = SecurePassword;
            App.secureLoginDatabase.SaveLoginDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration successful", "Ok");
        }


        static SecureFolderLoginDatabase secureFolderLoginDatabase;

        public static SecureFolderLoginDatabase secureLoginDatabase
        {
            get
            {
                if (secureFolderLoginDatabase == null)
                {
                    secureFolderLoginDatabase = new SecureFolderLoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
                }
                return secureFolderLoginDatabase;
            }
        }





    }
}
