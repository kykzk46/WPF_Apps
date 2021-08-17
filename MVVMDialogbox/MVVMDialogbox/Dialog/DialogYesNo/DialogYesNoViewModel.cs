using MVVMDialogbox.Dialog.DialogService;
using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVMDialogbox.Dialog.DialogYesNo
{
	class DialogYesNoViewModel : DialogViewModelBase
	{
		public DialogYesNoViewModel(string message) : base(message)
		{
		}

		#region Command

		RelayCommand<object> _YesCommand = null;
		public ICommand YesCommand
		{
			get
			{
				if (_YesCommand == null)
				{
					_YesCommand = new RelayCommand<object>((p) => OnYesCommandExecute(p), (p) => CanYesCommandExecute(p));
				}

				return _YesCommand;
			}
		}
		bool CanYesCommandExecute(object param)
		{
			return true;
		}
		void OnYesCommandExecute(object param)
		{
			CloseDialogWithResult(param as Window, DialogResult.Yes);
		}

		RelayCommand<object> _NoCommand = null;
		public ICommand NoCommand
		{
			get
			{
				if (_NoCommand == null)
				{
					_NoCommand = new RelayCommand<object>((p) => OnNoCommandExecute(p), (p) => CanNoCommandExecute(p));
				}

				return _NoCommand;
			}
		}
		bool CanNoCommandExecute(object param)
		{
			return true;
		}
		void OnNoCommandExecute(object param)
		{
			CloseDialogWithResult(param as Window, DialogResult.No);
		}
		#endregion
	}
}
