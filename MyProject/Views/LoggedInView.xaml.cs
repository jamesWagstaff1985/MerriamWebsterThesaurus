using MyProject.ViewModels;
using System.Windows;
using ReactiveUI;
using System.Reactive.Disposables;
using MyProject.Models;

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for LoggedInView.xaml
    /// </summary>
    public partial class LoggedInView : Window, IViewFor<LoggedInViewModel>
    {
        public static readonly DependencyProperty LoggedInViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(LoggedInViewModel), typeof(LoggedInView));
        
            public LoggedInView()
            {
            InitializeComponent();
            ViewModel = new LoggedInViewModel(new SynonymsAndAntonyms());

            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, x => x.Word, x => x.Word.Text)
                .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Synonyms, x => x.ReturnedSynonyms.Text)
                .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Antonyms, x => x.ReturnedAntonyms.Text)
                .DisposeWith(disposable);
            });
            }

        public LoggedInViewModel ViewModel
        {
            get => (LoggedInViewModel)GetValue(LoggedInViewModelProperty);
            set => SetValue(LoggedInViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (LoggedInViewModel)value;
        }

    }
}
