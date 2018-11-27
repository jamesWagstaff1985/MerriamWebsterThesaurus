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
        private SynonymsAndAntonyms _synonymsAndAntonyms;

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

        public LoggedInViewModel(SynonymsAndAntonyms synonymsAndAntonyms)
        {
            _synonymsAndAntonyms = synonymsAndAntonyms;

            this.WhenAnyValue(x => x.Word)
                .Where(x => !string.IsNullOrWhiteSpace(x) && x.Length > 2)
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.MainThreadScheduler)
                .Subscribe(_ => CheckWord());
        }

        private void CheckWord()
        {
            if (!string.IsNullOrEmpty(Word))
            {
                var Results = _synonymsAndAntonyms.GetAssociatedWords(Word);
                Synonyms = Results.Item1;
                Antonyms = Results.Item2;
            }
        }
    }
}
