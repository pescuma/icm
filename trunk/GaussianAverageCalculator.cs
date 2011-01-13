using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetConnectionMonitor
{
	public class GaussianAverageCalculator : IAverageCalculator
	{
		private int windowSize;
		private readonly List<double> elements = new List<double>();
		private readonly double[] kernel = new double[3];
		private readonly int guessWindowSize;

		public GaussianAverageCalculator(int windowSize, double sigma, int guessWindowSize)
		{
			this.windowSize = windowSize;
			this.guessWindowSize = guessWindowSize;
			InitKernel(sigma);
		}

		private void InitKernel(double sigma)
		{
			kernel[0] = kernel[2] = Gaussian(1, sigma);
			kernel[1] = Gaussian(0, sigma);

			double sum = kernel.Sum();
			for (int i = 0; i < kernel.Length; i++)
				kernel[i] = kernel[i] / sum;
		}

		/// <see cref="http://en.wikipedia.org/wiki/Gaussian_filter"/>
		private double Gaussian(int x, double sigma)
		{
			return 1 / (Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(- x * x / (2 * sigma * sigma));
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
			get { return elements.Count == windowSize + 1; }
		}

		public double Average
		{
			get
			{
				if (elements.Count < 1)
				{
					return 0;
				}
				else
				{
					List<double> els = ApplyGauss(elements);
					return els.Sum() / els.Count;
				}
			}
		}

		private List<double> ApplyGauss(List<double> vals)
		{
			if (vals.Count < 2)
				return vals;

			// Guess next element so we don't have to delay it
			vals = new List<double>(vals);
			vals.Add(GuessNextElement(vals));

			List<double> result = new List<double>();
			for (int i = 0; i < vals.Count - 2; i++)
			{
				double v = 0;
				for (int j = 0; j < 3; j++)
					v += kernel[j] * vals[i + j];
				result.Add(v);
			}

			return result;
		}

		private double GuessNextElement(List<double> vals)
		{
			int guessCount = Math.Min(guessWindowSize, vals.Count);

			double next = 0;
			for (int i = vals.Count - guessCount; i < vals.Count; i++)
				next += vals[i];
			next /= guessCount;
			
			return next;
		}

		public void Add(double element)
		{
			elements.Add(element);

			RemoveAdicionalElements();
		}

		private void RemoveAdicionalElements()
		{
			if (elements.Count > windowSize + 1)
				elements.RemoveRange(0, elements.Count - windowSize - 1);
		}
	}
}
