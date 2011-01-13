using System.Collections.Generic;
using System.Linq;

namespace InternetConnectionMonitor
{
	public class AverageCalculator : IAverageCalculator
	{
		private readonly List<double> elements = new List<double>();
		private int windowSize;

		public AverageCalculator(int windowSize)
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

				RemoveAdicionalElements();
			}
		}

		public bool WindowIsFull
		{
			get { return elements.Count == windowSize; }
		}

		public double Average
		{
			get
			{
				if (elements.Count < 1)
					return 0;
				else
					return elements.Aggregate((sum, el) => sum + el) / elements.Count;
			}
		}

		public void Add(double element)
		{
			elements.Add(element);

			RemoveAdicionalElements();
		}

		private void RemoveAdicionalElements()
		{
			if (elements.Count > windowSize)
				elements.RemoveRange(0, elements.Count - windowSize);
		}
	}
}
