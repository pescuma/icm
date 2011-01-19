<model>

  <type name="Presenter">
    <property name="CurrentSide" type="Side" default="Side.Left" />
    <property name="CurrentQuality" type="Quality" default="Quality.Good" setter="protected" />
    <property name="AvgPingTimeMs" type="int" setter="protected" />
    <component name="Config" type="Configuration" />
    <property name="MainImage" type="string" setter="protected" />
    <property name="TrayImage" type="string" setter="protected" />
    <collection name="History" contents="HistoryEntry" />
  </type>

  <type name="HistoryEntry">
    <property name="Date" type="DateTime" />
    <property name="PingTimeMs" type="int" />
    <property name="AverageTimeMs" type="int" />
    <property name="ProblemThresholdMs" type="int" />
    <property name="FailThresholdMs" type="int" />
    <property name="Quality" type="Quality" />
  </type>

  <type name="Configuration">
    <property name="Servers" type="string" />
    <property name="Bytes" type="int" default="32" />
    <property name="ProblemThresholdMs" type="int" default="300" />
    <property name="FailThresholdMs" type="int" default="1500" />
    <property name="TimeoutMs" type="int" default="1500" />
    <property name="TestEachMs" type="int" default="3000" />
    <property name="ZenerFactor" type="double" default="0.2" />
    <property name="AverageWindow" type="int" default="3" />
    <property name="AverageType" type="int" default="0" />
    <property name="GaussianAverageSigma" type="double" default="1" />
    <property name="GaussianAverageGuessWindow" type="int" default="2" />
    <property name="GrowlServer" type="string" />
    <property name="GrowlPassword" type="string" />
    <property name="MaxHistoryPoints" type="int" default="50" />
  </type>

</model>