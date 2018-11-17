using System;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using System.Windows;
using System.Threading;

namespace MyProject.ViewModels
{
    public class LoginPromptViewModel : ReactiveObject
    {
        private string _username;
        private string _password;
        public ReactiveCommand<Unit, Unit> DoLogin { get; }
        private string _message;
        private int MaxAttempts = 2;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        void ClearMessage()
        {
            Message = null;
        }

        private void CloseWindow(object state)
        {
            Environment.Exit(0);
        }

        public LoginPromptViewModel()
        {
            this.WhenAnyValue(x => x.Username, x => x.Password).Subscribe(_ => ClearMessage());
            DoLogin = ReactiveCommand.Create(
                () =>
                {
                    Models.UserDbContext Users = new Models.UserDbContext();
                    var context = new Models.UserDbContext();
                    if (context.Users.Any(c=>c.Username == Username && c.Password == Password))
                    {
                        ChangeView();
                    }
                    else if(MaxAttempts > 0)
                    { 
                        MaxAttempts--;
                        Message = "Username/Password Incorrect\nTry again";
                    }
                    else
                    {
                        Message = "Max attempts reached\nGoodbye";
                        Timer t = new Timer(CloseWindow, null, 2000, 2000);
                    }
                });
        }

        public void ChangeView()
        {
            var win = new Views.LoggedInView();
            win.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
