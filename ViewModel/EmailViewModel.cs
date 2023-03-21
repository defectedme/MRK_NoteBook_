using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using MRK_NoteBook.Model;

namespace MRK_NoteBook.ViewModel
{
    public partial class EmailViewModel : ObservableObject
    {
     
        public Model.Email GetEmail { get; set; }

        public EmailViewModel(INavigation navigation)
        {
            GetEmail = new Model.Email();
        }


        [RelayCommand]
        async void SendMail()
        {
            try
            {
                if(string.IsNullOrEmpty(GetEmail.Subject) ||
                    string.IsNullOrEmpty(GetEmail.Body)||
                    string.IsNullOrEmpty(GetEmail.TO))
                {
                    await Shell.Current.DisplayAlert("ERROR", "Cannot be empty", "Ok");
                    return;
                }
                var message = new EmailMessage()
                {
                    Subject = GetEmail.Subject,
                    Body = GetEmail.Body,
                    To = new List<string>(GetEmail.TO.Split(','))
                };
                if(GetEmail.CC.Length > 0)
                    message.Cc = new List<string>(GetEmail.CC.Split(','));
                await Microsoft.Maui.ApplicationModel.Communication.Email.Default.ComposeAsync(message);
            }

            catch (FeatureNotEnabledException fbsEx)
            {
                await Shell.Current.DisplayAlert("ERROR", fbsEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR", ex.Message, "Ok");
            }

        }


    }
}
