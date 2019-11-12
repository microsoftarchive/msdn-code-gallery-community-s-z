a) This sample requires that you add your servicebus connection string to the app.config file in the app.config under Receivers and Senders project
b) Run the Senders.exe first to ensure that the eventHub is created
Sender sample takes 2 args
<eventhubname> : Eventhub name
[numberOfPartitions] : Specify number of partitions.

c) Start as many receivers as there are #partitions to ensure all the messages are received
d) Receiver Sample takes 3 arguments 

<eventhubname> : Eventhub name
<partitionId> : PartitionId to receive events from. PartitionId  ranges from 0 to n -1 
[receiverEpoch]: Optional parameter. Pass an integer equal to or higher than the previously passed epoch for the same partition to ensure that there is only one receiver per partition at any time.
[startingoffset] : Optional parameter. Starting event offset to resume receiving. If this argument is omitted receiver will start receiving from the beginning offset.


