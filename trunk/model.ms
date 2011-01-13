<model>

  <type name="Presenter">
    <property name="CurrentSide" type="Side" default="Side.Left" />
    <property name="CurrentQuality" type="Quality" default="Quality.Good" setter="protected" />
    <property name="AvgPingTimeMs" type="int" setter="protected" />
    <component name="Config" type="Configuration" />
    <property name="MainImage" type="string" setter="protected" />
    <property name="TrayImage" type="string" setter="protected" />
  </type>
  
  <type name="Configuration">
    <property name="Servers" type="string" default="8.8.8.8\n8.8.4.4" />
    <property name="Bytes" type="int" default="8" />
    <property name="ProblemThresholdMs" type="int" default="300" />
    <property name="FailThresholdMs" type="int" default="1000" />
    <property name="TimeoutMs" type="int" default="1500" />
    <property name="TestEachMs" type="int" default="2000" />
    <property name="ZenerFactor" type="double" default="0.2" />
    <property name="AverageWindow" type="int" default="6" />
    <property name="AverageType" type="int" default="2" />
    <property name="GaussianAverageSigma" type="double" default="1" />
    <property name="GaussianAverageGuessWindow" type="int" default="2" />
    <property name="GrowlServer" type="string" />
    <property name="GrowlPassword" type="string" />
  </type>

</model>