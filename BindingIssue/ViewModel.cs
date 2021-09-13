using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingIssue
{
    public class ViewModel : ReactiveObject
    {
        private string _testString = "PARENT: Initial string";
        public string TestString
        {
            get { return _testString; }
            set { this.RaiseAndSetIfChanged(ref _testString, value); }
        }

        private NestedViewModel _nestedViewModel;
        public NestedViewModel NestedViewModel
        {
            get { return _nestedViewModel; }
            set { this.RaiseAndSetIfChanged(ref _nestedViewModel, value); }
        }

        public ViewModel()
        {
            NestedViewModel = new NestedViewModel();

            Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(t =>
            {
                TestString = "PARENT: I've changed";
                NestedViewModel.TestString = "NESTED: I've changed";
            });
        }
    }

    public class NestedViewModel : ReactiveObject
    {
        private string _testString = "NESTED: Initial string";
        public string TestString
        {
            get { return _testString; }
            set { this.RaiseAndSetIfChanged(ref _testString, value); }
        }
    }
}
