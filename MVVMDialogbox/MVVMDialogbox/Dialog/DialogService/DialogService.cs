using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDialogbox.Dialog.DialogService
{
	public class DialogService
	{
		public static DialogResult OpenDialog(DialogViewModelBase vm)
		{
			DialogWindow win = new DialogWindow();
			win.DataContext = vm;
			win.ShowDialog();
			return DialogResult.Undefined;
		}

	}
}
