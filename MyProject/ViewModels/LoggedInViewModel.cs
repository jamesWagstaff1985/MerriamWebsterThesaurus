using System;
using MyProject.Models;
using ReactiveUI;
using System.Reactive.Linq;

namespace MyProject.ViewModels
{
    public class LoggedInViewModel : ReactiveObject
    {
        private string _word;
        private string _synonyms;
        private string _antonyms;

        public string Word
        {
            get { return _word; }
            set { this.RaiseAndSetIfChanged(ref _word, value); }
        }

        public string Synonyms
        {
            get { return _synonyms; }
            set { this.RaiseAndSetIfChanged(ref _synonyms, value); }
        }

        public string Antonyms
        {
            get { return _antonyms; }
            set { this.RaiseAndSetIfChanged(ref _antonyms, value); }
        }

        public LoggedInViewModel()
        {
            this.WhenAnyValue(x => x.Word)
                .Where(x => !String.IsNullOrWhiteSpace(x) && x.Length > 2)
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.MainThreadScheduler)
                .Subscribe(_ => CheckWord());
        }

        private void CheckWord()
        {
            if (!String.IsNullOrEmpty(Word))
            {
                var Results = new SynonymsAndAntonyms { query = Word }.GetAssociatedWords();
                Synonyms = Results.Item1;
                Antonyms = Results.Item2;
            }
        }
    }
}
