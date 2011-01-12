// Automatically generated by Model#
// DO NOT EDIT THIS FILE

using System;
using System.ComponentModel;
using org.pescuma.ModelSharp.Lib;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace InternetConnectionMonitor
{
    [DataContract]
    public abstract class BaseConfiguration : INotifyPropertyChanging, INotifyChildPropertyChanging, INotifyPropertyChanged, INotifyChildPropertyChanged, ICloneable
    {
        #region Field Name Defines
        
        public class PROPERTIES
        {
            public const string BYTES = "Bytes";
            public const string PROBLEM_THRESHOLD_MS = "ProblemThresholdMs";
            public const string FAIL_THRESHOLD_MS = "FailThresholdMs";
            public const string TIMEOUT_MS = "TimeoutMs";
            public const string TEST_EACH_MS = "TestEachMs";
            public const string AVERAGE_WINDOW = "AverageWindow";
            public const string SERVER = "Server";
        }
        
        #endregion
        
        #region Constructors
        
        public BaseConfiguration()
        {
            _bytes = 32;
            _problemThresholdMs = 200;
            _failThresholdMs = 1000;
            _timeoutMs = 1500;
            _testEachMs = 2000;
            _averageWindow = 10;
            _server = "8.8.8.8";
        }
        
        public BaseConfiguration(BaseConfiguration other)
        {
            _bytes = other.Bytes;
            _problemThresholdMs = other.ProblemThresholdMs;
            _failThresholdMs = other.FailThresholdMs;
            _timeoutMs = other.TimeoutMs;
            _testEachMs = other.TestEachMs;
            _averageWindow = other.AverageWindow;
            _server = other.Server;
        }
        
        #endregion
        
        #region Property Bytes
        
        [DataMember(Name = "Bytes", Order = 0, IsRequired = false)]
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
        
        #endregion
        
        #region Property ProblemThresholdMs
        
        [DataMember(Name = "ProblemThresholdMs", Order = 1, IsRequired = false)]
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
        
        #endregion
        
        #region Property FailThresholdMs
        
        [DataMember(Name = "FailThresholdMs", Order = 2, IsRequired = false)]
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
        
        #endregion
        
        #region Property TimeoutMs
        
        [DataMember(Name = "TimeoutMs", Order = 3, IsRequired = false)]
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
        
        #endregion
        
        #region Property TestEachMs
        
        [DataMember(Name = "TestEachMs", Order = 4, IsRequired = false)]
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
        
        #endregion
        
        #region Property AverageWindow
        
        [DataMember(Name = "AverageWindow", Order = 5, IsRequired = false)]
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
        
        #endregion
        
        #region Property Server
        
        [DataMember(Name = "Server", Order = 6, IsRequired = false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _server;
        
        public string Server
        {
            [DebuggerStepThrough]
            get {
                return GetServer();
            }
            [DebuggerStepThrough]
            set {
                SetServer(value);
            }
        }
        
        protected virtual string GetServer()
        {
            return _server;
        }
        
        protected virtual bool SetServer(string server)
        {
            if (_server == server)
                return false;
                
            NotifyPropertyChanging(PROPERTIES.SERVER);
            
            _server = server;
            
            NotifyPropertyChanged(PROPERTIES.SERVER);
            
            return true;
        }
        
        #endregion
        
        #region Get/Set by name and CopyFrom
        
        public object GetField(string fieldName)
        {
            switch (fieldName)
            {
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
                case PROPERTIES.AVERAGE_WINDOW:
                    return GetAverageWindow();
                case PROPERTIES.SERVER:
                    return GetServer();
            }
            
            throw new ArgumentException("No gettable field named " + fieldName);
        }
        
        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case PROPERTIES.BYTES:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetBytes((int) value);
                    
                    break;
                case PROPERTIES.PROBLEM_THRESHOLD_MS:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetProblemThresholdMs((int) value);
                    
                    break;
                case PROPERTIES.FAIL_THRESHOLD_MS:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetFailThresholdMs((int) value);
                    
                    break;
                case PROPERTIES.TIMEOUT_MS:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetTimeoutMs((int) value);
                    
                    break;
                case PROPERTIES.TEST_EACH_MS:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetTestEachMs((int) value);
                    
                    break;
                case PROPERTIES.AVERAGE_WINDOW:
                    if (!(value is int))
                        throw new ArgumentException(fieldName + " must be of type int");
                        
                    SetAverageWindow((int) value);
                    
                    break;
                case PROPERTIES.SERVER:
                    if (!(value is string))
                        throw new ArgumentException(fieldName + " must be of type string");
                        
                    SetServer((string) value);
                    
                    break;
            }
            
            throw new ArgumentException("No settable field named " + fieldName);
        }
        
        public void CopyFrom(Configuration other)
        {
            Bytes = other.Bytes;
            ProblemThresholdMs = other.ProblemThresholdMs;
            FailThresholdMs = other.FailThresholdMs;
            TimeoutMs = other.TimeoutMs;
            TestEachMs = other.TestEachMs;
            AverageWindow = other.AverageWindow;
            Server = other.Server;
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
                handler(this, new ChildPropertyChangingEventArgs(this, propertyName, e));
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
                handler(this, new ChildPropertyChangedEventArgs(this, propertyName, e));
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