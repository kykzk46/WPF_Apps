using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MvvmFoundation.Wpf;
using System.Windows.Input;

namespace HierarchicalListboxes.viewmodel
{
	class MainWindow_VM : ObservableObject
	{
		List<string> _listbox1Items = new List<string>
		{
			"A000",
			"A000",
			"A000",
			"A000",
			"A000",
			"A000",
			"B000",
			"B000",
			"B000",
			"B000",
			"C000",
			"C000",
			"C000",
			"C000",
		};

		List<string> _listbox2Items = new List<string>
		{
			"A100",
			"A100",
			"A200",
			"A200",
			"A300",
			"A300",
			"B100",
			"B100",
			"B200",
			"B200",
			"C100",
			"C100",
			"C100",
			"C200",
		};

		List<string> _listbox3Items = new List<string>
		{
			"A110",
			"A110",
			"A210",
			"A210",
			"A310",
			"A320",
			"B110",
			"B110",
			"B210",
			"B220",
			"C110",
			"C110",
			"C120",
			"C210",
		};

		List<string> _listbox4Items = new List<string>
		{
			"A111",
			"A112",
			"A211",
			"A212",
			"A311",
			"A321",
			"B111",
			"B112",
			"B211",
			"B222",
			"C111",
			"C112",
			"C121",
			"C211",
		};

		ListboxItem_VM _Listbox1Vm;
		public ListboxItem_VM Listbox1Vm
		{
			get { return _Listbox1Vm; }
			set
			{
				if(_Listbox1Vm != value)
				{
					_Listbox1Vm = value;
					RaisePropertyChanged("Listbox1Vm");
				}
			}
		}

		ListboxItem_VM _Listbox2Vm;
		public ListboxItem_VM Listbox2Vm
		{
			get { return _Listbox2Vm; }
			set
			{
				if(_Listbox2Vm != value)
				{
					_Listbox2Vm = value;
					RaisePropertyChanged("Listbox2Vm");
				}
			}
		}

		ListboxItem_VM _Listbox3Vm;
		public ListboxItem_VM Listbox3Vm
		{
			get { return _Listbox3Vm; }
			set
			{
				if(_Listbox3Vm != value)
				{
					_Listbox3Vm = value;
					RaisePropertyChanged("Listbox3Vm");
				}
			}
		}

		ListboxItem_VM _Listbox4Vm;
		public ListboxItem_VM Listbox4Vm
		{
			get { return _Listbox4Vm; }
			set
			{
				if(_Listbox4Vm != value)
				{
					_Listbox4Vm = value;
					RaisePropertyChanged("Listbox4Vm");
				}
			}
		}

		public MainWindow_VM()
		{
			_Listbox1Vm = new ListboxItem_VM(_listbox1Items.Distinct<string>().ToList(), 1);
			_Listbox2Vm = new ListboxItem_VM(_listbox2Items.Distinct<string>().ToList(), 2);
			_Listbox3Vm = new ListboxItem_VM(_listbox3Items.Distinct<string>().ToList(), 3);
			_Listbox4Vm = new ListboxItem_VM(_listbox4Items.Distinct<string>().ToList(), 4);

			_Listbox1Vm.ChildListbox = _Listbox2Vm;
			_Listbox2Vm.ChildListbox = _Listbox3Vm;
			_Listbox3Vm.ChildListbox = _Listbox4Vm;
		}

        RelayCommand<object> _Reset = null;
        public ICommand Reset
        {
            get
            {
                if (_Reset == null)
                {
                    _Reset = new RelayCommand<object>(p => OnReset(p), (p) => CanReset(p));
                }

                return _Reset;
            }
        }
        bool CanReset(object param)
        {
            return true;
        }

        private void OnReset(object param)
        {
			_Listbox1Vm.ListBoxSelectedItem = null;
			_Listbox2Vm.ListBoxSelectedItem = null;
			_Listbox3Vm.ListBoxSelectedItem = null;
			_Listbox4Vm.ListBoxSelectedItem = null;
        }
	}
}
