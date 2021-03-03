using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> ListUsers;
        string dir = @"H:\C#\WPF\ExamWPF\Messenger\Messenger\";
        User Shekspir;
        User Brad;
        User tmp;
     
        public MainWindow()
        {
            InitializeComponent();
            ListUsers = new ObservableCollection<User>();

          
          
             Shekspir =new User(){ Name = "Shekspir", Picture = @"Images\Jhoi.jpg" };
            Shekspir.Text= Text_set(@"\Shekspir.txt");
            string dir2 = Directory.GetCurrentDirectory();
           

            Shekspir.DirTxt = dir2 + @"\Shekspir.txt";


            Brad = new User() { Name = "User2", Picture = @"Images\Brad.jpg" };
            Brad.Text = Text_set(@"\Brad.txt");
         
            Brad.DirTxt = dir2 + @"\Brad.txt";


            ListUsers.Add(Shekspir) ;

            ListUsers.Add(Brad);
          
            this.ListBoxUsers.ItemsSource = ListUsers;
           
        }

        public List<string> Text_set(string path)
        {
            string dir = Directory.GetCurrentDirectory();
            dir += path;
  
            int size=0;
            List<string> text = new List<string>();
            using (StreamReader sr = new StreamReader(dir, System.Text.Encoding.Default))
            {
                string line;
              
              
                while ((line = sr.ReadLine()) != null)
                {
                    size++;
                   
                }
            }
        

            using (StreamReader sr = new StreamReader(dir))
            {
                string line;


                while ((line = sr.ReadLine()) != null)
                {

                    text.Add(line);
              
                }
            }


            return text;
        }




        private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            tmp= (User)ListBoxUsers.SelectedItem;
            this.ImageDialog.ImageSource = new BitmapImage(new Uri(dir+ tmp.Picture)) ;
            this.UserNameDoalog.Text = tmp.Name;
            this.TextBoxMyMessage.Text = "";
            List<String> Text = new List<string>();
            this.DialogBox.Items.Clear();
            foreach (var item in tmp.Text)
            {

                Text.Add(item);
            }

           
            for (int i = 0; i < tmp.Text.Count; i++)
            {
                DialogBox.Items.Add(new TextBlock() { Text = tmp.Text[i]});
            }

           
        }

        private void ButtonSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (this.DialogBox.Items.Count!=0 && tmp!=null)
            {
                try
                {
                  
                    if (this.TextBoxMyMessage.Text!="")
                    {
                        tmp.Text.Add("Вы: " + this.TextBoxMyMessage.Text);
                        DialogBox.Items.Add(new TextBlock() { Text = "Вы: " + this.TextBoxMyMessage.Text, TextAlignment = TextAlignment.Right, Width = 450 });
                    }
                  //сохраненние в файл
                    using (StreamWriter writer = new StreamWriter(tmp.DirTxt))
                    {
                        foreach (var item in tmp.Text)
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Это бесплатная версия\n Для получения полного доступа ко всем возможностям\n произведтите олпату\nКарта приват банк 564865456556","Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
