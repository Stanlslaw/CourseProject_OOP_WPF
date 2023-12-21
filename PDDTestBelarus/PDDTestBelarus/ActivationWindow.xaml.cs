using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Newtonsoft.Json;
using PDDTestBelarus.Models;

namespace PDDTestBelarus;

public partial class ActivationWindow : Window
{
    private UUID _uuid;
    public ActivationWindow()
    {
        _uuid=JsonConvert.DeserializeObject<UUID>(File.ReadAllText("activationconfig.json"));
        if (_uuid.uuid == null)
        {
            _uuid.uuid =Convert.ToString(Guid.NewGuid());
            File.WriteAllText("activationconfig.json", JsonConvert.SerializeObject(_uuid));
        }
        InitializeComponent();
        KeyBox.Focus();
    }

    public void OnInputChanges(object sender, EventArgs e)
    {
        string pattern = @"^[A-Fa-f0-9]{8}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{12}$";
        if (KeyBox.Text.Length > 0)
        {
            Placeholder.Visibility = Visibility.Hidden;
        }
        else
        {
            Placeholder.Visibility = Visibility.Visible;
        }
        bool isValidGuid = Regex.IsMatch(KeyBox.Text, pattern);
        
        if (isValidGuid)
        {
            SendButton.IsEnabled = true;
            ErrorMessage.Text = "";
        }
        else
        {
            SendButton.IsEnabled = false;
            ErrorMessage.Text = "Не соответствует формату";
        }
    }
    private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        KeyBox.Focus();
        e.Handled = true;
    }
    public async void SendKey(object sender, EventArgs e)
    {
        if (KeyBox.Text == "00000000-0000-0000-0000-000000000000")
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            // Закрытие текущего окна
         Close();
         return;
        }

        HttpClient client = new HttpClient();
        HttpResponseMessage res = await client.GetAsync($"http://localhost:5000/api/Key/activekey?key={KeyBox.Text}");
        string resBody = await res.Content.ReadAsStringAsync();
        if (!Convert.ToBoolean(resBody))
        {
            ErrorMessage.Text = "Неверный код или данный код уже активирован";
        }
        MessageBox.Show(resBody);
    }
    
    
}