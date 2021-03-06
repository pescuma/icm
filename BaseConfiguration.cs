// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace org.pescuma.icm
{

	[DataContract]
	[DebuggerDisplay("Configuration[Servers={Servers} Bytes={Bytes} ProblemThresholdMs={ProblemThresholdMs} FailThresholdMs={FailThresholdMs} TimeoutMs={TimeoutMs} TestEachMs={TestEachMs} ZenerFactor={ZenerFactor} AverageWindow={AverageWindow} AverageType={AverageType} GaussianAverageSigma={GaussianAverageSigma} GaussianAverageGuessWindow={GaussianAverageGuessWindow} GrowlServer={GrowlServer} GrowlPassword={GrowlPassword} MaxHistoryPoints={MaxHistoryPoints}]")]
	public abstract class BaseConfiguration : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string SERVERS = "Servers";
			public const string BYTES = "Bytes";
			public const string PROBLEM_THRESHOLD_MS = "ProblemThresholdMs";
			public const string FAIL_THRESHOLD_MS = "FailThresholdMs";
			public const string TIMEOUT_MS = "TimeoutMs";
			public const string TEST_EACH_MS = "TestEachMs";
			public const string ZENER_FACTOR = "ZenerFactor";
			public const string AVERAGE_WINDOW = "AverageWindow";
			public const string AVERAGE_TYPE = "AverageType";
			public const string GAUSSIAN_AVERAGE_SIGMA = "GaussianAverageSigma";
			public const string GAUSSIAN_AVERAGE_GUESS_WINDOW = "GaussianAverageGuessWindow";
			public const string GROWL_SERVER = "GrowlServer";
			public const string GROWL_PASSWORD = "GrowlPassword";
			public const string MAX_HISTORY_POINTS = "MaxHistoryPoints";
		}
		
		#endregion
		
		#region Constructors
		
		public BaseConfiguration()
		{
			_bytes = 32;
			_problemThresholdMs = 300;
			_failThresholdMs = 1500;
			_timeoutMs = 1500;
			_testEachMs = 3000;
			_zenerFactor = 0.2;
			_averageWindow = 3;
			_averageType = 0;
			_gaussianAverageSigma = 1;
			_gaussianAverageGuessWindow = 2;
			_maxHistoryPoints = 50;
		}
		
		public BaseConfiguration(BaseConfiguration other)
		{
			_servers = other.Servers;
			_bytes = other.Bytes;
			_problemThresholdMs = other.ProblemThresholdMs;
			_failThresholdMs = other.FailThresholdMs;
			_timeoutMs = other.TimeoutMs;
			_testEachMs = other.TestEachMs;
			_zenerFactor = other.ZenerFactor;
			_averageWindow = other.AverageWindow;
			_averageType = other.AverageType;
			_gaussianAverageSigma = other.GaussianAverageSigma;
			_gaussianAverageGuessWindow = other.GaussianAverageGuessWindow;
			_growlServer = other.GrowlServer;
			_growlPassword = other.GrowlPassword;
			_maxHistoryPoints = other.MaxHistoryPoints;
		}
		
		#endregion
		
		#region Property Servers
		
		[DataMember(Name = "Servers", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _servers;
		
		public string Servers
		{
			[DebuggerStepThrough]
			get {
				return GetServers();
			}
			[DebuggerStepThrough]
			set {
				SetServers(value);
			}
		}
		
		protected virtual string GetServers()
		{
			return _servers;
		}
		
		protected virtual bool SetServers(string servers)
		{
			if (_servers == servers)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.SERVERS);
			
			_servers = servers;
			
			NotifyPropertyChanged(PROPERTIES.SERVERS);
			
			return true;
		}
		
		#endregion Property Servers
		
		#region Property Bytes
		
		[DataMember(Name = "Bytes", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _bytes;
		
		public int Bytes
		{
			[DebuggerStepThrough]
			get {
				return GetBytes();
			}
			[DebuggerStepThrough]
			set {
				SetBytes(value);
			}
		}
		
		protected virtual int GetBytes()
		{
			return _bytes;
		}
		
		protected virtual bool SetBytes(int bytes)
		{
			if (_bytes == bytes)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.BYTES);
			
			_bytes = bytes;
			
			NotifyPropertyChanged(PROPERTIES.BYTES);
			
			return true;
		}
		
		#endregion Property Bytes
		
		#region Property ProblemThresholdMs
		
		[DataMember(Name = "ProblemThresholdMs", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _problemThresholdMs;
		
		public int ProblemThresholdMs
		{
			[DebuggerStepThrough]
			get {
				return GetProblemThresholdMs();
			}
			[DebuggerStepThrough]
			set {
				SetProblemThresholdMs(value);
			}
		}
		
		protected virtual int GetProblemThresholdMs()
		{
			return _problemThresholdMs;
		}
		
		protected virtual bool SetProblemThresholdMs(int problemThresholdMs)
		{
			if (_problemThresholdMs == problemThresholdMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.PROBLEM_THRESHOLD_MS);
			
			_problemThresholdMs = problemThresholdMs;
			
			NotifyPropertyChanged(PROPERTIES.PROBLEM_THRESHOLD_MS);
			
			return true;
		}
		
		#endregion Property ProblemThresholdMs
		
		#region Property FailThresholdMs
		
		[DataMember(Name = "FailThresholdMs", Order = 3, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _failThresholdMs;
		
		public int FailThresholdMs
		{
			[DebuggerStepThrough]
			get {
				return GetFailThresholdMs();
			}
			[DebuggerStepThrough]
			set {
				SetFailThresholdMs(value);
			}
		}
		
		protected virtual int GetFailThresholdMs()
		{
			return _failThresholdMs;
		}
		
		protected virtual bool SetFailThresholdMs(int failThresholdMs)
		{
			if (_failThresholdMs == failThresholdMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.FAIL_THRESHOLD_MS);
			
			_failThresholdMs = failThresholdMs;
			
			NotifyPropertyChanged(PROPERTIES.FAIL_THRESHOLD_MS);
			
			return true;
		}
		
		#endregion Property FailThresholdMs
		
		#region Property TimeoutMs
		
		[DataMember(Name = "TimeoutMs", Order = 4, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _timeoutMs;
		
		public int TimeoutMs
		{
			[DebuggerStepThrough]
			get {
				return GetTimeoutMs();
			}
			[DebuggerStepThrough]
			set {
				SetTimeoutMs(value);
			}
		}
		
		protected virtual int GetTimeoutMs()
		{
			return _timeoutMs;
		}
		
		protected virtual bool SetTimeoutMs(int timeoutMs)
		{
			if (_timeoutMs == timeoutMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.TIMEOUT_MS);
			
			_timeoutMs = timeoutMs;
			
			NotifyPropertyChanged(PROPERTIES.TIMEOUT_MS);
			
			return true;
		}
		
		#endregion Property TimeoutMs
		
		#region Property TestEachMs
		
		[DataMember(Name = "TestEachMs", Order = 5, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _testEachMs;
		
		public int TestEachMs
		{
			[DebuggerStepThrough]
			get {
				return GetTestEachMs();
			}
			[DebuggerStepThrough]
			set {
				SetTestEachMs(value);
			}
		}
		
		protected virtual int GetTestEachMs()
		{
			return _testEachMs;
		}
		
		protected virtual bool SetTestEachMs(int testEachMs)
		{
			if (_testEachMs == testEachMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.TEST_EACH_MS);
			
			_testEachMs = testEachMs;
			
			NotifyPropertyChanged(PROPERTIES.TEST_EACH_MS);
			
			return true;
		}
		
		#endregion Property TestEachMs
		
		#region Property ZenerFactor
		
		[DataMember(Name = "ZenerFactor", Order = 6, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _zenerFactor;
		
		public double ZenerFactor
		{
			[DebuggerStepThrough]
			get {
				return GetZenerFactor();
			}
			[DebuggerStepThrough]
			set {
				SetZenerFactor(value);
			}
		}
		
		protected virtual double GetZenerFactor()
		{
			return _zenerFactor;
		}
		
		protected virtual bool SetZenerFactor(double zenerFactor)
		{
			if (_zenerFactor == zenerFactor)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.ZENER_FACTOR);
			
			_zenerFactor = zenerFactor;
			
			NotifyPropertyChanged(PROPERTIES.ZENER_FACTOR);
			
			return true;
		}
		
		#endregion Property ZenerFactor
		
		#region Property AverageWindow
		
		[DataMember(Name = "AverageWindow", Order = 7, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _averageWindow;
		
		public int AverageWindow
		{
			[DebuggerStepThrough]
			get {
				return GetAverageWindow();
			}
			[DebuggerStepThrough]
			set {
				SetAverageWindow(value);
			}
		}
		
		protected virtual int GetAverageWindow()
		{
			return _averageWindow;
		}
		
		protected virtual bool SetAverageWindow(int averageWindow)
		{
			if (_averageWindow == averageWindow)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.AVERAGE_WINDOW);
			
			_averageWindow = averageWindow;
			
			NotifyPropertyChanged(PROPERTIES.AVERAGE_WINDOW);
			
			return true;
		}
		
		#endregion Property AverageWindow
		
		#region Property AverageType
		
		[DataMember(Name = "AverageType", Order = 8, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _averageType;
		
		public int AverageType
		{
			[DebuggerStepThrough]
			get {
				return GetAverageType();
			}
			[DebuggerStepThrough]
			set {
				SetAverageType(value);
			}
		}
		
		protected virtual int GetAverageType()
		{
			return _averageType;
		}
		
		protected virtual bool SetAverageType(int averageType)
		{
			if (_averageType == averageType)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.AVERAGE_TYPE);
			
			_averageType = averageType;
			
			NotifyPropertyChanged(PROPERTIES.AVERAGE_TYPE);
			
			return true;
		}
		
		#endregion Property AverageType
		
		#region Property GaussianAverageSigma
		
		[DataMember(Name = "GaussianAverageSigma", Order = 9, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _gaussianAverageSigma;
		
		public double GaussianAverageSigma
		{
			[DebuggerStepThrough]
			get {
				return GetGaussianAverageSigma();
			}
			[DebuggerStepThrough]
			set {
				SetGaussianAverageSigma(value);
			}
		}
		
		protected virtual double GetGaussianAverageSigma()
		{
			return _gaussianAverageSigma;
		}
		
		protected virtual bool SetGaussianAverageSigma(double gaussianAverageSigma)
		{
			if (_gaussianAverageSigma == gaussianAverageSigma)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.GAUSSIAN_AVERAGE_SIGMA);
			
			_gaussianAverageSigma = gaussianAverageSigma;
			
			NotifyPropertyChanged(PROPERTIES.GAUSSIAN_AVERAGE_SIGMA);
			
			return true;
		}
		
		#endregion Property GaussianAverageSigma
		
		#region Property GaussianAverageGuessWindow
		
		[DataMember(Name = "GaussianAverageGuessWindow", Order = 10, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _gaussianAverageGuessWindow;
		
		public int GaussianAverageGuessWindow
		{
			[DebuggerStepThrough]
			get {
				return GetGaussianAverageGuessWindow();
			}
			[DebuggerStepThrough]
			set {
				SetGaussianAverageGuessWindow(value);
			}
		}
		
		protected virtual int GetGaussianAverageGuessWindow()
		{
			return _gaussianAverageGuessWindow;
		}
		
		protected virtual bool SetGaussianAverageGuessWindow(int gaussianAverageGuessWindow)
		{
			if (_gaussianAverageGuessWindow == gaussianAverageGuessWindow)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.GAUSSIAN_AVERAGE_GUESS_WINDOW);
			
			_gaussianAverageGuessWindow = gaussianAverageGuessWindow;
			
			NotifyPropertyChanged(PROPERTIES.GAUSSIAN_AVERAGE_GUESS_WINDOW);
			
			return true;
		}
		
		#endregion Property GaussianAverageGuessWindow
		
		#region Property GrowlServer
		
		[DataMember(Name = "GrowlServer", Order = 11, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _growlServer;
		
		public string GrowlServer
		{
			[DebuggerStepThrough]
			get {
				return GetGrowlServer();
			}
			[DebuggerStepThrough]
			set {
				SetGrowlServer(value);
			}
		}
		
		protected virtual string GetGrowlServer()
		{
			return _growlServer;
		}
		
		protected virtual bool SetGrowlServer(string growlServer)
		{
			if (_growlServer == growlServer)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.GROWL_SERVER);
			
			_growlServer = growlServer;
			
			NotifyPropertyChanged(PROPERTIES.GROWL_SERVER);
			
			return true;
		}
		
		#endregion Property GrowlServer
		
		#region Property GrowlPassword
		
		[DataMember(Name = "GrowlPassword", Order = 12, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _growlPassword;
		
		public string GrowlPassword
		{
			[DebuggerStepThrough]
			get {
				return GetGrowlPassword();
			}
			[DebuggerStepThrough]
			set {
				SetGrowlPassword(value);
			}
		}
		
		protected virtual string GetGrowlPassword()
		{
			return _growlPassword;
		}
		
		protected virtual bool SetGrowlPassword(string growlPassword)
		{
			if (_growlPassword == growlPassword)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.GROWL_PASSWORD);
			
			_growlPassword = growlPassword;
			
			NotifyPropertyChanged(PROPERTIES.GROWL_PASSWORD);
			
			return true;
		}
		
		#endregion Property GrowlPassword
		
		#region Property MaxHistoryPoints
		
		[DataMember(Name = "MaxHistoryPoints", Order = 13, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _maxHistoryPoints;
		
		public int MaxHistoryPoints
		{
			[DebuggerStepThrough]
			get {
				return GetMaxHistoryPoints();
			}
			[DebuggerStepThrough]
			set {
				SetMaxHistoryPoints(value);
			}
		}
		
		protected virtual int GetMaxHistoryPoints()
		{
			return _maxHistoryPoints;
		}
		
		protected virtual bool SetMaxHistoryPoints(int maxHistoryPoints)
		{
			if (_maxHistoryPoints == maxHistoryPoints)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.MAX_HISTORY_POINTS);
			
			_maxHistoryPoints = maxHistoryPoints;
			
			NotifyPropertyChanged(PROPERTIES.MAX_HISTORY_POINTS);
			
			return true;
		}
		
		#endregion Property MaxHistoryPoints
		
		#region Get/Set by name and CopyFrom
		
		public object GetField(string fieldName)
		{
			switch (fieldName)
			{
				case PROPERTIES.SERVERS:
					return GetServers();
				case PROPERTIES.BYTES:
					return GetBytes();
				case PROPERTIES.PROBLEM_THRESHOLD_MS:
					return GetProblemThresholdMs();
				case PROPERTIES.FAIL_THRESHOLD_MS:
					return GetFailThresholdMs();
				case PROPERTIES.TIMEOUT_MS:
					return GetTimeoutMs();
				case PROPERTIES.TEST_EACH_MS:
					return GetTestEachMs();
				case PROPERTIES.ZENER_FACTOR:
					return GetZenerFactor();
				case PROPERTIES.AVERAGE_WINDOW:
					return GetAverageWindow();
				case PROPERTIES.AVERAGE_TYPE:
					return GetAverageType();
				case PROPERTIES.GAUSSIAN_AVERAGE_SIGMA:
					return GetGaussianAverageSigma();
				case PROPERTIES.GAUSSIAN_AVERAGE_GUESS_WINDOW:
					return GetGaussianAverageGuessWindow();
				case PROPERTIES.GROWL_SERVER:
					return GetGrowlServer();
				case PROPERTIES.GROWL_PASSWORD:
					return GetGrowlPassword();
				case PROPERTIES.MAX_HISTORY_POINTS:
					return GetMaxHistoryPoints();
			}
			
			throw new ArgumentException("No gettable field named " + fieldName);
		}
		
		public void SetField(string fieldName, object value)
		{
			switch (fieldName)
			{
				case PROPERTIES.SERVERS:
					if (!(value is string))
						throw new ArgumentException(fieldName + " must be of type string");
						
					SetServers((string) value);
					
					return;
				case PROPERTIES.BYTES:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetBytes((int) value);
					
					return;
				case PROPERTIES.PROBLEM_THRESHOLD_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetProblemThresholdMs((int) value);
					
					return;
				case PROPERTIES.FAIL_THRESHOLD_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetFailThresholdMs((int) value);
					
					return;
				case PROPERTIES.TIMEOUT_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetTimeoutMs((int) value);
					
					return;
				case PROPERTIES.TEST_EACH_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetTestEachMs((int) value);
					
					return;
				case PROPERTIES.ZENER_FACTOR:
					if (!(value is double))
						throw new ArgumentException(fieldName + " must be of type double");
						
					SetZenerFactor((double) value);
					
					return;
				case PROPERTIES.AVERAGE_WINDOW:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetAverageWindow((int) value);
					
					return;
				case PROPERTIES.AVERAGE_TYPE:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetAverageType((int) value);
					
					return;
				case PROPERTIES.GAUSSIAN_AVERAGE_SIGMA:
					if (!(value is double))
						throw new ArgumentException(fieldName + " must be of type double");
						
					SetGaussianAverageSigma((double) value);
					
					return;
				case PROPERTIES.GAUSSIAN_AVERAGE_GUESS_WINDOW:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetGaussianAverageGuessWindow((int) value);
					
					return;
				case PROPERTIES.GROWL_SERVER:
					if (!(value is string))
						throw new ArgumentException(fieldName + " must be of type string");
						
					SetGrowlServer((string) value);
					
					return;
				case PROPERTIES.GROWL_PASSWORD:
					if (!(value is string))
						throw new ArgumentException(fieldName + " must be of type string");
						
					SetGrowlPassword((string) value);
					
					return;
				case PROPERTIES.MAX_HISTORY_POINTS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetMaxHistoryPoints((int) value);
					
					return;
			}
			
			throw new ArgumentException("No settable field named " + fieldName);
		}
		
		public void CopyFrom(Configuration other)
		{
			Servers = other.Servers;
			Bytes = other.Bytes;
			ProblemThresholdMs = other.ProblemThresholdMs;
			FailThresholdMs = other.FailThresholdMs;
			TimeoutMs = other.TimeoutMs;
			TestEachMs = other.TestEachMs;
			ZenerFactor = other.ZenerFactor;
			AverageWindow = other.AverageWindow;
			AverageType = other.AverageType;
			GaussianAverageSigma = other.GaussianAverageSigma;
			GaussianAverageGuessWindow = other.GaussianAverageGuessWindow;
			GrowlServer = other.GrowlServer;
			GrowlPassword = other.GrowlPassword;
			MaxHistoryPoints = other.MaxHistoryPoints;
		}
		
		#endregion
		
		#region Property Notification
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event ChildPropertyChangingEventHandler ChildPropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		public event ChildPropertyChangedEventHandler ChildPropertyChanged;
		
		protected void NotifyPropertyChanging(string propertyName)
		{
			PropertyChangingEventHandler handler = PropertyChanging;
			if (handler != null)
				handler(this, new PropertyChangingEventArgs(propertyName));
		}
		
		protected void NotifyChildPropertyChanging(string propertyName, object sender, PropertyChangingEventArgs e)
		{
			ChildPropertyChangingEventHandler handler = ChildPropertyChanging;
			if (handler != null)
				handler(sender, new ChildPropertyChangingEventArgs(this, propertyName, e));
		}
		
		protected void NotifyPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		
		protected void NotifyChildPropertyChanged(string propertyName, object sender, PropertyChangedEventArgs e)
		{
			ChildPropertyChangedEventHandler handler = ChildPropertyChanged;
			if (handler != null)
				handler(sender, new ChildPropertyChangedEventArgs(this, propertyName, e));
		}
		
		#endregion
		
		#region Clone
		
		public Configuration Clone()
		{
			return (Configuration) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new Configuration((Configuration) this);
		}
		
		#endregion
	}
	
}
