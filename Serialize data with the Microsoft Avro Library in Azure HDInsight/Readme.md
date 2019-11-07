# Serialize data with the Microsoft Avro Library in Azure HDInsight
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- JSON
- .NET Framework 4.0
- Hadoop
- HDInsight Azure
## Topics
- JSON
- Class Library
- Serialization
- Microsoft Azure
- Data
- Streaming
- Big Data
## Updated
- 04/02/2014
## Description

<h1>Introduction</h1>
<p><em>This topic shows how to use the Microsoft Avro Library to serialize objects and other data structures into streams to persist them to memory and also how to deserialize them to recover the original objects.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The .NET Framework 4.0 must be installed and the Microsoft .NET Library for Avro must be installed using the NuGet Package Manager.&nbsp;
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>There are four examples in this sample that illustrate different scenarios supported by the Microsoft Avro Library.
</em></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<ul>
<li><strong>Serialization with reflection</strong>: The JSON schema for types to be serialized is automatically built from the data contract attributes.
</li><li><strong>Serialization with generic records</strong>: The JSON schema is explicitly specified in a record when no .NET type is available for refection.
</li><li><strong>Serialization using object container files with reflection</strong>: The JSON schema is implicitly serialized with the data and shared using an Avro container file.
</li><li><strong>Serialization using object container files with generic records</strong>: The JSON schema is explicitly serialized with the data and shared using an Avro container
</li></ul>
</em>
<p></p>
<p><em>The first two show how to serialize and deserialize data into memory stream buffers using reflection and generic records. The schema for the data&nbsp;in these two cases is assumed to be shared between readers and writers out-of-band so that the schema
 does not need to be serialized with the data in an Avro container file.</em></p>
<p><em>The second two examples show how to serialize data into memory stream buffers using reflection and generic records with Avro container files. The schema for the data in these two cases is not shared out-of-band. When data is stored in an Avro container
 file, its schema is always stored with it because the schema must be shared with potential readers&nbsp;for deserialization.<br>
</em></p>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Microsoft.Hadoop.Avro.Sample
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Avro.Schema;

    //Sample Class used in serialization samples
    [DataContract(Name = &quot;SensorDataValue&quot;, Namespace = &quot;Sensors&quot;)]
    internal class SensorData
    {
        [DataMember(Name = &quot;Location&quot;)]
        public Location Position { get; set; }

        [DataMember(Name = &quot;Value&quot;)]
        public byte[] Value { get; set; }
    }

    //Sample struct used in serialization samples
    [DataContract]
    internal struct Location
    {
        [DataMember]
        public int Floor { get; set; }

        [DataMember]
        public int Room { get; set; }
    }

    //This class contains all methods demonstrating
    //the usage of Microsoft Avro Library
    public class AvroSample
    {

        //Serialize and deserialize sample data set represented as an object using Reflection
        //No explicit schema definition is required - schema of serialized objects is automatically built
        public void SerializeDeserializeObjectUsingReflection()
        {

            Console.WriteLine(&quot;SERIALIZATION USING REFLECTION\n&quot;);
            Console.WriteLine(&quot;Serializing Sample Data Set...&quot;);

            //Create a new AvroSerializer instance and specify a custom serialization strategy AvroDataContractResolver
            //for serializing only properties attributed with DataContract/DateMember
            var avroSerializer = AvroSerializer.Create&lt;SensorData&gt;();

            //Create a Memory Stream buffer
            using (var buffer = new MemoryStream())
            {
                //Create a data set using sample Class and struct 
                var expected = new SensorData { Value = new byte[] { 1, 2, 3, 4, 5 }, Position = new Location { Room = 243, Floor = 1 } };

                //Serialize the data to the specified stream
                avroSerializer.Serialize(buffer, expected);

      
                Console.WriteLine(&quot;Deserializing Sample Data Set...&quot;);

                //Prepare the stream for deserializing the data
                buffer.Seek(0, SeekOrigin.Begin);

                //Deserialize data from the stream and cast it to the same type used for serialization
                var actual = avroSerializer.Deserialize(buffer);

                Console.WriteLine(&quot;Comparing Initial and Deserialized Data Sets...&quot;);

                //Finally, verify that deserialized data matches the original one
                bool isEqual = this.Equal(expected, actual);

                Console.WriteLine(&quot;Result of Data Set Identity Comparison is {0}&quot; , isEqual);
                
            }
        }
   }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Microsoft.Hadoop.Avro.Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Runtime.Serialization;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Hadoop.Avro.Container;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Hadoop.Avro.Schema;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Sample&nbsp;Class&nbsp;used&nbsp;in&nbsp;serialization&nbsp;samples</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataContract(Name&nbsp;=&nbsp;<span class="cs__string">&quot;SensorDataValue&quot;</span>,&nbsp;Namespace&nbsp;=&nbsp;<span class="cs__string">&quot;Sensors&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SensorData&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Location&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Location&nbsp;Position&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Name&nbsp;=&nbsp;<span class="cs__string">&quot;Value&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Sample&nbsp;struct&nbsp;used&nbsp;in&nbsp;serialization&nbsp;samples</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">struct</span>&nbsp;Location&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Floor&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Room&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;class&nbsp;contains&nbsp;all&nbsp;methods&nbsp;demonstrating</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//the&nbsp;usage&nbsp;of&nbsp;Microsoft&nbsp;Avro&nbsp;Library</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AvroSample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Serialize&nbsp;and&nbsp;deserialize&nbsp;sample&nbsp;data&nbsp;set&nbsp;represented&nbsp;as&nbsp;an&nbsp;object&nbsp;using&nbsp;Reflection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//No&nbsp;explicit&nbsp;schema&nbsp;definition&nbsp;is&nbsp;required&nbsp;-&nbsp;schema&nbsp;of&nbsp;serialized&nbsp;objects&nbsp;is&nbsp;automatically&nbsp;built</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SerializeDeserializeObjectUsingReflection()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;SERIALIZATION&nbsp;USING&nbsp;REFLECTION\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Serializing&nbsp;Sample&nbsp;Data&nbsp;Set...&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;new&nbsp;AvroSerializer&nbsp;instance&nbsp;and&nbsp;specify&nbsp;a&nbsp;custom&nbsp;serialization&nbsp;strategy&nbsp;AvroDataContractResolver</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//for&nbsp;serializing&nbsp;only&nbsp;properties&nbsp;attributed&nbsp;with&nbsp;DataContract/DateMember</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;avroSerializer&nbsp;=&nbsp;AvroSerializer.Create&lt;SensorData&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;Memory&nbsp;Stream&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;data&nbsp;set&nbsp;using&nbsp;sample&nbsp;Class&nbsp;and&nbsp;struct&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;expected&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SensorData&nbsp;{&nbsp;Value&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;Position&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Location&nbsp;{&nbsp;Room&nbsp;=&nbsp;<span class="cs__number">243</span>,&nbsp;Floor&nbsp;=&nbsp;<span class="cs__number">1</span>&nbsp;}&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Serialize&nbsp;the&nbsp;data&nbsp;to&nbsp;the&nbsp;specified&nbsp;stream</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;avroSerializer.Serialize(buffer,&nbsp;expected);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Deserializing&nbsp;Sample&nbsp;Data&nbsp;Set...&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prepare&nbsp;the&nbsp;stream&nbsp;for&nbsp;deserializing&nbsp;the&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buffer.Seek(<span class="cs__number">0</span>,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Deserialize&nbsp;data&nbsp;from&nbsp;the&nbsp;stream&nbsp;and&nbsp;cast&nbsp;it&nbsp;to&nbsp;the&nbsp;same&nbsp;type&nbsp;used&nbsp;for&nbsp;serialization</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;actual&nbsp;=&nbsp;avroSerializer.Deserialize(buffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Comparing&nbsp;Initial&nbsp;and&nbsp;Deserialized&nbsp;Data&nbsp;Sets...&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Finally,&nbsp;verify&nbsp;that&nbsp;deserialized&nbsp;data&nbsp;matches&nbsp;the&nbsp;original&nbsp;one</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isEqual&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Equal(expected,&nbsp;actual);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Result&nbsp;of&nbsp;Data&nbsp;Set&nbsp;Identity&nbsp;Comparison&nbsp;is&nbsp;{0}&quot;</span>&nbsp;,&nbsp;isEqual);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p>Serialize data with the Microsoft Avro Library: <a href="http://www.azure.com/en-us/documentation/articles/hdinsight-dotnet-avro-serialization">
http://www.azure.com/en-us/documentation/articles/hdinsight-dotnet-avro-serialization</a></p>
<p>HDInsight SDK Reference Documentation:<em> <a href="http://msdn.microsoft.com/en-us/library/azure/dn469975.aspx">
http://msdn.microsoft.com/en-us/library/azure/dn469975.aspx</a></em></p>
<p>Sample: Serialize data with the Microsoft Avro Library using a custom codec:<em>
<a href="http://code.msdn.microsoft.com/windowsazure/Serialize-data-with-the-67159111">
http://code.msdn.microsoft.com/windowsazure/Serialize-data-with-the-67159111</a></em></p>
<p>The Apache Avro specification:<em> <a href="http://avro.apache.org/docs/current/spec.html">
http://avro.apache.org/docs/current/spec.html</a></em></p>
<p>Introducing JSON (JavaScript Object Notation):<em> <a href="http://json.org/">
http://json.org/</a> </em><em><br>
</em><em><br>
</em></p>
