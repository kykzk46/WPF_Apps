using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NonBlockingUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		int LongTask()
		{
			Thread.Sleep(5000);
			return 1;
		}

		private void Button_Click_Blocking(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Start");
			int rst = LongTask();
			Debug.WriteLine("rst = " + rst);
			Debug.WriteLine("End");
		}

		private void Button_Click_NonBlocking(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Start");
			LongTaskAsync();
			Debug.WriteLine("End");
		}

		async void LongTaskAsync()
		{
			// Create and start
			//var task = Task.Run(() => LongTask());

			var task = new Task<int>(() => LongTask());
			task.Start(); // defer start

			int rst = await task;
			Debug.WriteLine("Finished Task");

			Debug.WriteLine("rst = " + rst);
		}
	}
}
