using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using KeyServer;
using Newtonsoft.Json;
using PDDTestBelarus.Models;

namespace PDDTestBelarus;

public partial class ActivationWindow : Window
{
    private AuthorizeData _authorizeData;
    public ActivationWindow()
    {
        _authorizeData=JsonConvert.DeserializeObject<AuthorizeData>(File.ReadAllText("activationconfig.json"));
        if (_authorizeData.uuid == null)
        {
            _authorizeData.uuid =Convert.ToString(Guid.NewGuid());
            File.WriteAllText("activationconfig.json", JsonConvert.SerializeObject(_authorizeData));
        }

        if (_authorizeData.hash == MD5Hash.ComputeMD5Hash(_authorizeData.uuid, "secret"))
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            // Закрытие текущего окна
            Close();
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
        MainWindow mainWindow;
        if (KeyBox.Text == "00000000-0000-0000-0000-000000000000")
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            // Закрытие текущего окна
         Close();
         return;
        }

        KeyBox.IsEnabled = false;
        SendButton.IsEnabled = false;
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res =
                await client.GetAsync(
                    $"http://localhost:5000/api/Key/activekey?key={KeyBox.Text}&uuid={_authorizeData.uuid}");
            string resBody = await res.Content.ReadAsStringAsync();
            AuthorizeData resAuthorize = JsonConvert.DeserializeObject<AuthorizeData>(resBody);
            if (resAuthorize.hash == null)
            {
                ErrorMessage.Text = "Неверный код или данный код уже активирован";
                KeyBox.IsEnabled = true;
                SendButton.IsEnabled = true;
            }
            else
            {
                mainWindow = new MainWindow();
                mainWindow.Show();
                // Закрытие текущего окна
                Close();
                File.WriteAllText("activationconfig.json",JsonConvert.SerializeObject(resAuthorize));
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show("Проблема с подключением к серверу");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
     
        KeyBox.IsEnabled = true;
        SendButton.IsEnabled = true;
       
    }
    
    
}