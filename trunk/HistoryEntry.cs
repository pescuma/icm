using System;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace org.pescuma.icm
{
	[DataContract]
	public class HistoryEntry : BaseHistoryEntry
	{
		public HistoryEntry()
		{
		}

		public HistoryEntry(HistoryEntry other)
			: base(other)
		{
		}

		public Brush QualityColor
		{
			get
			{
				switch (Quality)
				{
					case Quality.Good:
						return new SolidColorBrush {Color = Colors.Green};
					case Quality.Problem:
						return new SolidColorBrush {Color = Colors.Yellow};
					case Quality.Fail:
						return new SolidColorBrush {Color = Colors.Red};
					default:
						throw new NotImplementedException();
				}
			}
		}

		public Brush PingQualityColor
		{
			get
			{
				if (PingTimeMs <= ProblemThresholdMs)
					return new SolidColorBrush { Color = Colors.Green };
				else if (PingTimeMs <= FailThresholdMs)
					return new SolidColorBrush { Color = Colors.Yellow };
				else
					return new SolidColorBrush { Color = Colors.Red };
			}
		}
	}
}
