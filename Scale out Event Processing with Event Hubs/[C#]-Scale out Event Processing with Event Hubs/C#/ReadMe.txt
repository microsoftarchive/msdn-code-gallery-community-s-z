a) This sample requires that you add your servicebus connection string to the app.config file in the app.config under Host and Senders project.
b) This sample also requires that you add your Azure storage connection string to the app.config file in the app.config under Host project.
c) Run the Senders.exe first to ensure that the eventHub is created
Sender sample takes 2 args
<eventhubname> : Eventhub name
[numberOfPartitions] : Specify number of partitions.

d) Start as many Host.exe as you like to see how receving work load is distributed among them
e) Host Sample takes 3 arguments 

<eventhubname> : Eventhub name
<hostname> : The host name to identify the host.
[consumergroup] : The optional consumer group for receiving messages, will use Default consumer group if this argument is missing.
