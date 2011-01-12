using System;

namespace InternetConnectionMonitor
{
	public class HistoricalAverageCalculator : IAverageCalculator
	{
		private int windowSize;
		private int numEntries;
		private double average;

		public HistoricalAverageCalculator(int windowSize)
		{
			this.windowSize = windowSize;
		}

		public int WindowSize
		{
			get { return windowSize; }
			set
			{
				if (windowSize == value)
					return;

				windowSize = value;
				numEntries = Math.Min(numEntries, windowSize);
			}
		}

		public double Average
		{
			get { return average; }
		}

		public void Add(double element)
		{
			numEntries = Math.Min(numEntries + 1, windowSize);
			average = (average * (numEntries - 1) + element) / numEntries;
		}
	}
}