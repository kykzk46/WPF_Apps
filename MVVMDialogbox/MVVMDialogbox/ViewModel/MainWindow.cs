using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MvvmFoundation.Wpf;

namespace MVVMDialogbox.ViewModel
{
	public class MainWindow
	{
		#region Command

		RelayCommand<object> _OpenDialogCommand = null;
		public ICommand OpenDialogCommand
		{
			get
			{
				if (_OpenDialogCommand == null)
				{
					_OpenDialogCommand = new RelayCommand<object>((p) => OnOpenDialogCommandExecute(p), (p) => CanOpenDialogCommandExecute(p));
				}

				return _OpenDialogCommand;
			}
		}
		bool CanOpenDialogCommandExecute(object param)
		{
			return true;
		}
		void OnOpenDialogCommandExecute(object param)
		{
			var vm = new Dialog.DialogYesNo.DialogYesNoViewModel("Question");
			var result = Dialog.DialogService.DialogService.OpenDialog(vm, param as Window);
		}
		#endregion
	}
}
