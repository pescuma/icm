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
	[DebuggerDisplay("HistoryEntry[Date={Date} PingTimeMs={PingTimeMs} AverageTimeMs={AverageTimeMs} ProblemThresholdMs={ProblemThresholdMs} FailThresholdMs={FailThresholdMs} Quality={Quality}]")]
	public abstract class BaseHistoryEntry : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
	{
		#region Field Name Defines
		
		public class PROPERTIES
		{
			public const string DATE = "Date";
			public const string PING_TIME_MS = "PingTimeMs";
			public const string AVERAGE_TIME_MS = "AverageTimeMs";
			public const string PROBLEM_THRESHOLD_MS = "ProblemThresholdMs";
			public const string FAIL_THRESHOLD_MS = "FailThresholdMs";
			public const string QUALITY = "Quality";
		}
		
		#endregion
		
		#region Constructors
		
		public BaseHistoryEntry()
		{
			AddDateListeners(_date);
			AddQualityListeners(_quality);
		}
		
		public BaseHistoryEntry(BaseHistoryEntry other)
		{
			_date = other.Date;
			AddDateListeners(_date);
			_pingTimeMs = other.PingTimeMs;
			_averageTimeMs = other.AverageTimeMs;
			_problemThresholdMs = other.ProblemThresholdMs;
			_failThresholdMs = other.FailThresholdMs;
			_quality = other.Quality;
			AddQualityListeners(_quality);
		}
		
		#endregion
		
		#region Property Date
		
		[DataMember(Name = "Date", Order = 0, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _date;
		
		public DateTime Date
		{
			[DebuggerStepThrough]
			get {
				return GetDate();
			}
			[DebuggerStepThrough]
			set {
				SetDate(value);
			}
		}
		
		protected virtual DateTime GetDate()
		{
			return _date;
		}
		
		protected virtual bool SetDate(DateTime date)
		{
			if (_date == date)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.DATE);
			
			RemoveDateListeners(date);
			
			_date = date;
			
			AddDateListeners(date);
			
			NotifyPropertyChanged(PROPERTIES.DATE);
			
			return true;
		}
		
		private void RemoveDateListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= DatePropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= DateChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= DatePropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= DateChildPropertyChangedEventHandler;
		}
		
		private void AddDateListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += DatePropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += DateChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += DatePropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += DateChildPropertyChangedEventHandler;
		}
		
		private void DatePropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.DATE, sender, e);
		}
		
		private void DateChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.DATE, sender, e);
		}
		
		private void DatePropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.DATE, sender, e);
		}
		
		private void DateChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.DATE, sender, e);
		}
		
		#endregion Property Date
		
		#region Property PingTimeMs
		
		[DataMember(Name = "PingTimeMs", Order = 1, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pingTimeMs;
		
		public int PingTimeMs
		{
			[DebuggerStepThrough]
			get {
				return GetPingTimeMs();
			}
			[DebuggerStepThrough]
			set {
				SetPingTimeMs(value);
			}
		}
		
		protected virtual int GetPingTimeMs()
		{
			return _pingTimeMs;
		}
		
		protected virtual bool SetPingTimeMs(int pingTimeMs)
		{
			if (_pingTimeMs == pingTimeMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.PING_TIME_MS);
			
			_pingTimeMs = pingTimeMs;
			
			NotifyPropertyChanged(PROPERTIES.PING_TIME_MS);
			
			return true;
		}
		
		#endregion Property PingTimeMs
		
		#region Property AverageTimeMs
		
		[DataMember(Name = "AverageTimeMs", Order = 2, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _averageTimeMs;
		
		public int AverageTimeMs
		{
			[DebuggerStepThrough]
			get {
				return GetAverageTimeMs();
			}
			[DebuggerStepThrough]
			set {
				SetAverageTimeMs(value);
			}
		}
		
		protected virtual int GetAverageTimeMs()
		{
			return _averageTimeMs;
		}
		
		protected virtual bool SetAverageTimeMs(int averageTimeMs)
		{
			if (_averageTimeMs == averageTimeMs)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.AVERAGE_TIME_MS);
			
			_averageTimeMs = averageTimeMs;
			
			NotifyPropertyChanged(PROPERTIES.AVERAGE_TIME_MS);
			
			return true;
		}
		
		#endregion Property AverageTimeMs
		
		#region Property ProblemThresholdMs
		
		[DataMember(Name = "ProblemThresholdMs", Order = 3, IsRequired = false)]
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
		
		[DataMember(Name = "FailThresholdMs", Order = 4, IsRequired = false)]
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
		
		#region Property Quality
		
		[DataMember(Name = "Quality", Order = 5, IsRequired = false)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Quality _quality;
		
		public Quality Quality
		{
			[DebuggerStepThrough]
			get {
				return GetQuality();
			}
			[DebuggerStepThrough]
			set {
				SetQuality(value);
			}
		}
		
		protected virtual Quality GetQuality()
		{
			return _quality;
		}
		
		protected virtual bool SetQuality(Quality quality)
		{
			if (_quality == quality)
				return false;
				
			NotifyPropertyChanging(PROPERTIES.QUALITY);
			
			RemoveQualityListeners(quality);
			
			_quality = quality;
			
			AddQualityListeners(quality);
			
			NotifyPropertyChanged(PROPERTIES.QUALITY);
			
			return true;
		}
		
		private void RemoveQualityListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging -= QualityPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging -= QualityChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged -= QualityPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged -= QualityChildPropertyChangedEventHandler;
		}
		
		private void AddQualityListeners(object child)
		{
			if (child == null)
				return;
				
			var notifyPropertyChanging = child as INotifyPropertyChanging;
			if (notifyPropertyChanging != null)
				notifyPropertyChanging.PropertyChanging += QualityPropertyChangingEventHandler;
				
			var notifyChildPropertyChanging = child as INotifyChildPropertyChanging;
			if (notifyChildPropertyChanging != null)
				notifyChildPropertyChanging.ChildPropertyChanging += QualityChildPropertyChangingEventHandler;
				
			var notifyPropertyChanged = child as INotifyPropertyChanged;
			if (notifyPropertyChanged != null)
				notifyPropertyChanged.PropertyChanged += QualityPropertyChangedEventHandler;
				
			var notifyChildPropertyChanged = child as INotifyChildPropertyChanged;
			if (notifyChildPropertyChanged != null)
				notifyChildPropertyChanged.ChildPropertyChanged += QualityChildPropertyChangedEventHandler;
		}
		
		private void QualityPropertyChangingEventHandler(object sender, PropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.QUALITY, sender, e);
		}
		
		private void QualityChildPropertyChangingEventHandler(object sender, ChildPropertyChangingEventArgs e)
		{
			NotifyChildPropertyChanging(PROPERTIES.QUALITY, sender, e);
		}
		
		private void QualityPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.QUALITY, sender, e);
		}
		
		private void QualityChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs e)
		{
			NotifyChildPropertyChanged(PROPERTIES.QUALITY, sender, e);
		}
		
		#endregion Property Quality
		
		#region Get/Set by name and CopyFrom
		
		public object GetField(string fieldName)
		{
			switch (fieldName)
			{
				case PROPERTIES.DATE:
					return GetDate();
				case PROPERTIES.PING_TIME_MS:
					return GetPingTimeMs();
				case PROPERTIES.AVERAGE_TIME_MS:
					return GetAverageTimeMs();
				case PROPERTIES.PROBLEM_THRESHOLD_MS:
					return GetProblemThresholdMs();
				case PROPERTIES.FAIL_THRESHOLD_MS:
					return GetFailThresholdMs();
				case PROPERTIES.QUALITY:
					return GetQuality();
			}
			
			throw new ArgumentException("No gettable field named " + fieldName);
		}
		
		public void SetField(string fieldName, object value)
		{
			switch (fieldName)
			{
				case PROPERTIES.DATE:
					if (!(value is DateTime))
						throw new ArgumentException(fieldName + " must be of type DateTime");
						
					SetDate((DateTime) value);
					
					return;
				case PROPERTIES.PING_TIME_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetPingTimeMs((int) value);
					
					return;
				case PROPERTIES.AVERAGE_TIME_MS:
					if (!(value is int))
						throw new ArgumentException(fieldName + " must be of type int");
						
					SetAverageTimeMs((int) value);
					
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
				case PROPERTIES.QUALITY:
					if (!(value is Quality))
						throw new ArgumentException(fieldName + " must be of type Quality");
						
					SetQuality((Quality) value);
					
					return;
			}
			
			throw new ArgumentException("No settable field named " + fieldName);
		}
		
		public void CopyFrom(HistoryEntry other)
		{
			Date = other.Date;
			PingTimeMs = other.PingTimeMs;
			AverageTimeMs = other.AverageTimeMs;
			ProblemThresholdMs = other.ProblemThresholdMs;
			FailThresholdMs = other.FailThresholdMs;
			Quality = other.Quality;
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
		
		public HistoryEntry Clone()
		{
			return (HistoryEntry) ((ICloneable) this).Clone();
		}
		
		object ICloneable.Clone()
		{
			return new HistoryEntry((HistoryEntry) this);
		}
		
		#endregion
	}
	
}
