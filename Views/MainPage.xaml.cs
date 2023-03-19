using System.Diagnostics;
using MRK_NoteBook.DataServices;
using MRK_NoteBook.Models;
using MRK_NoteBook.Views;
using MRK_NoteBook.Data;
using System;

namespace MRK_NoteBook.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class MainPage : ContentPage
{
    //ProductsPageView productPageView;


    public MainPage()
    {
        InitializeComponent();
        //BindingContext = productPageView;


    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        collectionView.ItemsSource = await database.GetItemsAsync();

    }


    async void OnAddToDoClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ManageToDoPage
        {
            BindingContext = new ToDo()
        });

    }

    async void OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
    {

        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ManageToDoPage
            {
                BindingContext = e.SelectedItem as ToDo

            });
            await DisplayAlert("Item Edit", "GO", "ok");

        }
    }

    async void OnProductsClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ProductsPageView
        {
            BindingContext = new ToDo()
        });

    }

    //async void LogInClicked(object sender, EventArgs e)
    //{


    //    //await Navigation.PushAsync(new SecureFolderView { BindingContext = new ToDo() });    
     

    //}

    async void LogInClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new SecureFolderView());
        BindingContext = new ToDo();

    }




    void OnAbouToClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new OnAbouToClicked());
        DisplayAlert("GO to About", "MRK Page", "ok");

    }

    public async void DeleteAllDbButton(object sender, EventArgs e)
    {


        bool answer = await  DisplayAlert("!!!GOING TO DELETE ALL DATA!!!!", "SURE?", "YES", "NO");


        if (answer == false)
        {
            return;
        }
        if (answer == true)
        {
            TodoItemDatabase Database = await TodoItemDatabase.Instance;
            await Database.DeleteAllItems<ToDo>();
        }







    }

}

