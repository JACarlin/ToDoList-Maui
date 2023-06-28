namespace TDMPW_411_3P_PR02;

using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Threading.Tasks;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private List<ToDoItem> listaTareas = new List<ToDoItem>();
    public List<ToDoItem> ListaTareas
    {
        get => listaTareas; set
        {
            listaTareas = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        updateFrames();
    }


    private void Entry_Completed(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEntry.Text))
        {

            try
            {
                ToDoItem newTask = new ToDoItem(ListaTareas[ListaTareas.Count - 1].Id + 1, txtEntry.Text, false);
                createTask(newTask);
            }
            catch
            {
                ToDoItem newTask = new ToDoItem(0 + 1, txtEntry.Text, false);
                createTask(newTask);
            }

            
        }
        else
        {
            this.DisplayAlert("", "Ingrese una tarea por favor", "ok");
        }
    }
    public void createTask(ToDoItem newTask)
    {
        ListaTareas.Add(newTask);

        txtEntry.Text = "";
        this.DisplayAlert("", "Tarea agregada", "ok");

        updateFrames();
    }

    public void updateFrames()
    {
        contenedor2.Children.Clear();
        contenedor.Children.Clear();

        foreach (ToDoItem task in ListaTareas)
        {
            if (task.Estado)
            {
                Frame frame = new Frame
                {
                    BackgroundColor = Colors.SpringGreen,
                    BorderColor = Colors.Transparent,
                    Margin = new Thickness(4)
                };

                StackLayout stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };

                CheckBox checkBox = new CheckBox
                {
                    Color = Colors.DarkGreen,
                    HorizontalOptions = LayoutOptions.Start,
                    IsChecked = task.Estado,
                    AutomationId = "cb" + task.Id
                };
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                Label label = new Label
                {
                    Text = task.Nombre,
                    TextColor = Colors.DarkGreen,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                Button button = new Button
                {
                    Text = "🗑",
                    BackgroundColor = Colors.Transparent,
                    HorizontalOptions = LayoutOptions.End,
                    AutomationId = "btn" + task.Id
                };
                button.Clicked += Button_Clicked;
                stackLayout.Children.Add(checkBox);
                stackLayout.Children.Add(label);
                stackLayout.Children.Add(button);
                frame.Content = stackLayout;
                

                contenedor.Children.Add(frame);
                
            }
            else
            {
                Frame frame = new Frame
                {
                    BackgroundColor = Colors.Yellow,
                    BorderColor = Colors.Transparent,
                    Margin = new Thickness(4)
                };

                StackLayout stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };

                CheckBox checkBox = new CheckBox
                {
                    Color = Colors.OrangeRed,
                    HorizontalOptions = LayoutOptions.Start,
                    IsChecked = task.Estado,
                    AutomationId = "cb" + task.Id
                };
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                Label label = new Label
                {
                    Text = task.Nombre,
                    TextColor = Colors.OrangeRed,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                Button button = new Button
                {
                    Text = "🗑",
                    BackgroundColor = Colors.Transparent,
                    HorizontalOptions = LayoutOptions.End,
                    AutomationId = "btn" + task.Id
                };
                button.Clicked += Button_Clicked;
                stackLayout.Children.Add(checkBox);
                stackLayout.Children.Add(label);
                stackLayout.Children.Add(button);
                frame.Content = stackLayout;

                contenedor2.Children.Add(frame);
            }

        }
        addInvisible1();
        addInvisible2();
        addInvisible1();
        addInvisible2();
    }
    public void addInvisible1()
    {
        Frame frame = new Frame
        {
            BackgroundColor = Colors.Yellow,
            BorderColor = Colors.Transparent,
            Margin = new Thickness(4)
        };

        StackLayout stackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };

        CheckBox checkBox = new CheckBox
        {
            Color = Colors.OrangeRed,
            HorizontalOptions = LayoutOptions.Start,
            IsChecked = true,
            AutomationId = "cb" 
        };
        Label label = new Label
        {
            Text = "a",
            TextColor = Colors.OrangeRed,
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        Button button = new Button
        {
            Text = "🗑",
            BackgroundColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.End,
            AutomationId = "btn"
        };
        stackLayout.Children.Add(checkBox);
        stackLayout.Children.Add(label);
        stackLayout.Children.Add(button);
        frame.Content = stackLayout;
        frame.Opacity = 0.001;
        contenedor2.Children.Add(frame);
    }
    public void addInvisible2()
    {
        Frame frame = new Frame
        {
            BackgroundColor = Colors.Yellow,
            BorderColor = Colors.Transparent,
            Margin = new Thickness(4)
        };

        StackLayout stackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };

        CheckBox checkBox = new CheckBox
        {
            Color = Colors.OrangeRed,
            HorizontalOptions = LayoutOptions.Start,
            IsChecked = true,
            AutomationId = "cb"
        };
        Label label = new Label
        {
            Text = "a",
            TextColor = Colors.OrangeRed,
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        Button button = new Button
        {
            Text = "🗑",
            BackgroundColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.End,
            AutomationId = "btn"
        };
        stackLayout.Children.Add(checkBox);
        stackLayout.Children.Add(label);
        stackLayout.Children.Add(button);
        frame.Content = stackLayout;
        frame.Opacity = 0.001;
        contenedor.Children.Add(frame);
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var input = button.AutomationId;
        if (input != null)
        {
            string numberString = input.Replace("btn", string.Empty);
            if (int.TryParse(numberString, out int number))
            {
                ToDoItem task = ListaTareas.Find(objeto => objeto.Id == number);
                ListaTareas.Remove(task);
            }
            updateFrames();
        }
        this.DisplayAlert("", "Tarea eliminada", "ok");
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        var input = checkBox.AutomationId;
        if (input != null)
        {
            string numberString = input.Replace("cb", string.Empty);
            if (int.TryParse(numberString, out int number))
            {
                ToDoItem task = ListaTareas.Find(objeto => objeto.Id == number);
                task.Estado = checkBox.IsChecked;
            }
            updateFrames();
        }
        
    }
}

