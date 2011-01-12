namespace InternetConnectionMonitor
{
	public interface IAverageCalculator
	{
		int WindowSize { get; set; }
		double Average { get; }
		void Add(double element);
	}
}