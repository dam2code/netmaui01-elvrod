﻿

namespace Notes;

public partial class MainPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public MainPage()
    {
        InitializeComponent();
                editor = this.FindByName<Editor>("editor");


        if (File.Exists(_fileName))
        {
            editor.Text = File.ReadAllText(_fileName);
        }
    

    var notesHeading = new Label() { Text = "Notes", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };

        var buttonsGrid = new Grid() { HeightRequest = 40.0 };
        buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
        buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30.0, GridUnitType.Absolute) });
        buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });

        var saveButton = new Button() { WidthRequest = 100, Text = "Save" };
        saveButton.Clicked += OnSaveButtonClicked;
        Grid.SetColumn(saveButton, 0);
        buttonsGrid.Children.Add(saveButton);

        var deleteButton = new Button() { WidthRequest = 100, Text = "Delete" };
        deleteButton.Clicked += OnDeleteButtonClicked;
        Grid.SetColumn(deleteButton, 2);
        buttonsGrid.Children.Add(deleteButton);

        var stackLayout = new VerticalStackLayout
        {
            Padding = new Thickness(30, 60, 30, 30),
            Children = { notesHeading, editor, buttonsGrid }
        };

        this.Content = stackLayout;
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, editor.Text);
        DisplayAlert("Success", "Note saved!", "OK");
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
            editor.Text = string.Empty;
            DisplayAlert("Deleted", "Note deleted!", "OK");
        }
    }
}


