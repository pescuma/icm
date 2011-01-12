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
    <property name="Bytes" type="int" default="32" />
    <property name="ProblemThresholdMs" type="int" default="200" />
    <property name="FailThresholdMs" type="int" default="1000" />
    <property name="TimeoutMs" type="int" default="1500" />
    <property name="TestEachMs" type="int" default="2000" />
    <property name="AverageWindow" type="int" default="10" />
    <property name="Server" type="string" default="8.8.8.8" />
  </type>

</model>