using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows;

namespace org.pescuma.icm
{
	internal class Pinger
	{
		private readonly Configuration config;
		private readonly Action<string, DateTime, int> callback;
		private Ping pingSender;
		private readonly Timer timer;
		private DateTime lastPing;
		private int lastServer = -1;
		private string lastServerName;

		public Pinger(Configuration config, Action<string, DateTime, int> callback)
		{
			this.config = config;
			this.callback = callback;

			timer = new Timer();
			timer.AutoReset = false;
			timer.Elapsed += OnTimer;
		}

		public bool IsStarted
		{
			get { return pingSender != null; }
		}

		public void Start()
		{
			if (pingSender != null)
				throw new InvalidOperationException("Already started");

			pingSender = new Ping();
			pingSender.PingCompleted += OnPingCompleted;

			SendPing();
		}

		private void SendPing()
		{
			PingOptions options = new PingOptions();
			options.DontFragment = true;

			var servers = new List<string>(config.Servers.Split('\n'));
			for (int i = 0; i < servers.Count; i++)
				servers[i] = servers[i].Trim(' ', '\r', '\t');
			servers.RemoveAll(s => s.Length < 1);

			if (servers.Count < 1)
			{
				timer.Interval = Math.Max(100, config.TestEachMs);
				timer.Start();
				return;
			}

			lastServer = (lastServer + 1) % servers.Count;
			lastPing = DateTime.Now;
			lastServerName = servers[lastServer];

			//Console.Write("Reply from " + servers[lastServer] + ": ");
			pingSender.SendAsync(lastServerName, config.TimeoutMs, CreateBuffer(), options);
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
//				Console.WriteLine("Ping canceled");
			}
			else if (e.Error != null)
			{
//				Console.WriteLine("Ping failed: " + e.Error);
				OnNewPingTime(lastServerName, -1);
			}
			else
			{
				PingReply reply = e.Reply;

				int dt;
				if (reply.Status == IPStatus.Success)
					dt = (int) Math.Min(reply.RoundtripTime, config.TimeoutMs - 1);
				else
					dt = config.TimeoutMs;

//				Console.WriteLine("Ping status: {0} in {1} ms", reply.Status, dt);

				OnNewPingTime(lastServerName, dt);
			}
		}

		private void OnNewPingTime(string server, int dt)
		{
			int pingDt = (int) ((DateTime.Now - lastPing).Ticks / 10000);

			//Console.WriteLine("time=" + dt + "ms  clock=" + pingDt + "ms");

			Application.Current.Dispatcher.BeginInvoke((Action) delegate { callback(server, lastPing, dt); });

			timer.Interval = Math.Max(100, config.TestEachMs - pingDt);
			timer.Start();
		}

		private void OnTimer(object sender, ElapsedEventArgs e)
		{
			timer.Stop();

			SendPing();
		}
	}
}
