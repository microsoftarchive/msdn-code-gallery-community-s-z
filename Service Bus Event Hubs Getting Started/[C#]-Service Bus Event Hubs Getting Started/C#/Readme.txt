a) This sample requires that you add your servicebus connection string to the app.config file
b) It requires that you have a Storage Emulator running or a valid AzureStorageConnectionString in the app.config
c) Sample takes 3 arguments - 

<eventhubname> : Name of the eventhub to be created.
<NumberOfMessagesToSend> : Number of messages to be sent
<NumberOfPartitions> : Number of eventhub partitions
