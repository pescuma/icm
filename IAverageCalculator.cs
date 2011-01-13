namespace InternetConnectionMonitor
{
	public interface IAverageCalculator
	{
		int WindowSize { get; set; }
		bool WindowIsFull { get; }
		double Average { get; }
		void Add(double element);
	}
}