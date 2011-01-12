using System;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows;

namespace InternetConnectionMonitor
{
	internal class Pinger
	{
		private readonly Configuration config;
		private readonly Action<int> callback;
		private Ping pingSender;
		private readonly Timer timer;
		private long lastPing;

		public Pinger(Configuration config, Action<int> callback)
		{
			this.config = config;
			this.callback = callback;

			timer = new Timer();
			timer.AutoReset = false;
			timer.Elapsed += OnTimer;
		}

		public void Start()
		{
			if (pingSender != null)
				throw new InvalidOperationException("Already started");
			if (string.IsNullOrEmpty(config.Server))
				throw new InvalidOperationException("No server defined");

			pingSender = new Ping();
			pingSender.PingCompleted += OnPingCompleted;

			SendPing();
		}

		private void SendPing()
		{
			PingOptions options = new PingOptions();
			options.DontFragment = true;

			pingSender.SendAsync(config.Server, config.TimeoutMs, CreateBuffer(), options);

			lastPing = GetCurrentTickMs();
		}

		private byte[] CreateBuffer()
		{
			byte[] buffer = new byte[config.Bytes];
			for (int i = 0; i < config.Bytes; i++)
				buffer[i] = 48; // '0'
			return buffer;
		}

		public void Stop()
		{
			if (pingSender == null)
				return;

			timer.Stop();

			pingSender.PingCompleted -= OnPingCompleted;
			pingSender.SendAsyncCancel();
			pingSender = null;
		}

		private void OnPingCompleted(object sender, PingCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				Console.WriteLine("Ping canceled");
			}
			else if (e.Error != null)
			{
				Console.WriteLine("Ping failed: " + e.Error);
				OnNewPingTime(config.TimeoutMs);
			}
			else
			{
				PingReply reply = e.Reply;

				int dt;
				if (reply.Status == IPStatus.Success)
					dt = (int) Math.Min(reply.RoundtripTime, config.TimeoutMs);
				else
					dt = config.TimeoutMs;

				Console.WriteLine("Ping status: {0} in {1} ms", reply.Status, dt);

				OnNewPingTime(dt);
			}
		}

		private void OnNewPingTime(int dt)
		{
			Application.Current.Dispatcher.BeginInvoke((Action) delegate { callback(dt); });

			int pingDt = (int) (GetCurrentTickMs() - lastPing);
			timer.Interval = Math.Max(100, config.TestEachMs - pingDt);
			timer.Start();
		}

		private long GetCurrentTickMs()
		{
			return DateTime.Now.Ticks / 10000;
		}

		private void OnTimer(object sender, ElapsedEventArgs e)
		{
			SendPing();
		}
	}
}
