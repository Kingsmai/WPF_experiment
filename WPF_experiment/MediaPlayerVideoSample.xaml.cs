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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_experiment
{
    /// <summary>
    /// Interaction logic for MediaPlayerVideoSample.xaml
    /// </summary>
    public partial class MediaPlayerVideoSample : Window
    {
        public MediaPlayerVideoSample()
        {
            InitializeComponent();

			// 准备时间
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick; // 增加监听事件
            timer.Start();
        }

		void timer_Tick(object sender, EventArgs e)
		{
			if (myPlayer.Source != null)
			{
				// 显示秒数，格式：00:00 / 00:00
				if (myPlayer.NaturalDuration.HasTimeSpan)
					lblStatus.Content = string.Format("{0} / {1}", myPlayer.Position.ToString(@"mm\:ss"), myPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			}
			else
				lblStatus.Content = "No file selected..."; // 如果没有文件
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			myPlayer.Play();
		}

		private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			myPlayer.Pause();
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			myPlayer.Stop();
		}
	}
}
