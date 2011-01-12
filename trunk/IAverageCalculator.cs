namespace InternetConnectionMonitor
{
	public interface IAverageCalculator
	{
		int WindowSize { get; set; }
		int SampleSize { get; }
		double Average { get; }
		void Add(double element);
	}
}