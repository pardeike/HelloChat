using System;
using System.ComponentModel;
using System.Windows;

namespace HelloChat
{
	public partial class MainWindow : Window
	{
		public MainWindow() => InitializeComponent();

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			Environment.Exit(0);
		}
	}
}
