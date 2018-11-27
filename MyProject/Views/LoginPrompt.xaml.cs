using MyProject.Models;
using MyProject.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for LoginPrompt.xaml
    /// </summary>
    public partial class LoginPrompt : Window, IViewFor<LoginPromptViewModel>
    {
            //Register the viewmodel to the view
            public static readonly DependencyProperty LoginPromptViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(LoginPromptViewModel), typeof(LoginPrompt));
        public LoginPrompt()
        {

            InitializeComponent();

            ViewModel = new LoginPromptViewModel(new UserDbContext());
            //Set the binding
            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, x => x.Username, x => x.Username.Text)
                .DisposeWith(disposable);
                this.Bind(this.ViewModel, x => x.Password, x => x.Password.Text)
                .DisposeWith(disposable);
                this.BindCommand(this.ViewModel, x => x.DoLogin, x => x.LoginButton)
                .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Message, x => x.Messages.Text)
                .DisposeWith(disposable);
            });

        }
        public LoginPromptViewModel ViewModel
        {
            get => (LoginPromptViewModel)GetValue(LoginPromptViewModelProperty);
            set => SetValue(LoginPromptViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (LoginPromptViewModel)value;
        }
    }
}
