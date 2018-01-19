using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfApp3
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

		System.Threading.Thread thread;
		
		private int lineNum = 0;

		private static Random random = new Random();
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		List<string> oldStrings = new List<string>();
		StringBuilder currentSb = null;
		TextBox currentTextBox = null;

		public void AddString(string nuString)
		{
			//case : new block
			if (currentSb == null)
			{
				//create new block and hold it.
				currentSb = new StringBuilder();
				Dispatcher.Invoke(new Action(() =>
				{
					currentTextBox = new TextBox();
					currentTextBox.BorderBrush = Brushes.Red;
					currentTextBox.BorderThickness = new Thickness(2);
					MainStackPanel.Children.Add(currentTextBox);
				}));
			}

			//StringBuilder is for non-ui-process.
			currentSb.AppendLine(nuString);

			//add to current block
			Dispatcher.Invoke(new Action(() =>
			{
				currentTextBox.AppendText(nuString);
				MyScrollViewer.ScrollToEnd();
			}));

			//if current text block is too long...
			if (currentSb.Length > 8000)
			{
				//save strings for other non-ui-process
				oldStrings.Add(currentSb.ToString());

				//unhold current controls
				currentSb = null;
				currentTextBox = null;
			}
		}

		bool quit = true;

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			if (quit)
			{
				quit = false;
				thread = new System.Threading.Thread(() =>
				{
					while (!quit)
					{
						//generate new string
						string nuString = (lineNum++).ToString() + ":" + RandomString(80) + "\n";

						AddString(nuString);

						//to let the other works use ui-thread.
						System.Threading.Thread.Sleep(5);
					}
				});
				thread.Start();
			}
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			if (!quit)
			{
				quit = true;
				thread.Join();
			}
		}
	}
}
