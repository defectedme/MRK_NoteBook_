using MRK_NoteBook.Data;
using MRK_NoteBook.ViewModel;

namespace MRK_NoteBook.Views;

public partial class CalculatorView : ContentPage
{
    int currentState = 1;
    string operatorMath;
    double firstNum, secondNum;

    public CalculatorView()
    {
        InitializeComponent();
        OnClear(this, null);
        BindingContext = new CalculatorViewModel(this.Navigation);
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNum = 0;
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
    }

    void OnSquareRoot(object sender, EventArgs e)
    {
        if (firstNum == 0)
            return;
        firstNum = firstNum * firstNum;
        this.result.Text = firstNum.ToString();
    }

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;

        double number;
        if (double.TryParse(this.result.Text, out number))
        {
            this.result.Text = number.ToString("N0");
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
    }


    void onOperatorSelection(object sender, EventArgs e)
    {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        operatorMath = btnPressed;
    }

    void onCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            var result = CalculatorViewModel.DxecCalculation(firstNum, secondNum, operatorMath);

            this.result.Text = result.ToString();
            firstNum = result;
            currentState = -1;
        }
    }

    async void OnProductsClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ProductsPageView
        {
            BindingContext = new ToDo()
        });

    }
}