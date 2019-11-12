<#
    .SYNOPSIS
    This script can be used to provision a namespace and queue.
            
    .DESCRIPTION
    This script can be used to provision a namespace and a queue. 
    
    .PARAMETER  Path
    Specifies the full path of the queue.

    .PARAMETER  AutoDeleteOnIdle
    Specifies after how many minutes the queue is automatically deleted. The minimum duration is 5 minutes.

    .PARAMETER  DefaultMessageTimeToLive
    Specifies default message time to live value in minutes. This is the duration after which the message expires, 
    starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself.
    Messages older than their TimeToLive value will expire and no longer be retained in the message store. 
    Subscribers will be unable to receive expired messages.A message can have a lower TimeToLive value than that specified here, 
    but by default TimeToLive is set to MaxValue. Therefore, this property becomes the default time to live value applied to messages.
    
    .PARAMETER  DuplicateDetectionHistoryTimeWindow
    Specifies the duration of the duplicate detection history in minutes. The default value is 10 minutes.
    
    .PARAMETER  EnableBatchedOperations
    Specifies whether server-side batched operations are enabled.
    
    .PARAMETER  EnableDeadLetteringOnMessageExpiration
    Specifies whether this queue has dead letter support when a message expires.
    
    .PARAMETER  EnableExpress
    Specifies whether to enable the queue to be partitioned across multiple message brokers. 
    An express queue holds a message in memory temporarily before writing it to persistent storage.
     
    .PARAMETER  EnablePartitioning
    Specifies whether the queue to be partitioned across multiple message brokers is enabled. 
    
    .PARAMETER  ForwardDeadLetteredMessagesTo
    Specifies the path to the recipient to which the dead lettered message is forwarded.
    
    .PARAMETER  ForwardTo
    Specifies the path to the recipient to which the message is forwarded.
    
    .PARAMETER  IsAnonymousAccessible
    Specifies whether the message is anonymous accessible.

    .PARAMETER  LockDuration
    Specifies the duration of a peek lock in seconds; that is, the amount of time that the message is locked for other receivers. 
    The maximum value for LockDuration is 5 minutes; the default value is 1 minute.
    
    .PARAMETER  MaxDeliveryCount
    Specifies the maximum delivery count. A message is automatically deadlettered after this number of deliveries.
    
    .PARAMETER  MaxSizeInMegabytes
    Specifies the maximum size of the queue in megabytes, which is the size of memory allocated for the queue.
    
    .PARAMETER  RequiresDuplicateDetection
    Specifies whether the queue requires duplicate detection.
    
    .PARAMETER  RequiresSession
    Specifies whether the queue supports the concept of session.
    
    .PARAMETER  SupportOrdering
    Specifies whether the queue supports ordering.
    
    .PARAMETER  UserMetadata
    Specifies the user metadata.

    .PARAMETER  Namespace
    Specifies the name of the Service Bus namespace.

    .PARAMETER  CreateACSNamespace
    Specifies whether  to create an ACS namespace associated to the Service Bus namespace.

    .PARAMETER  Location
    Specifies the location to create the namespace in. The default value is "West Europe". 

    Valid values:
    -- East Asia
    -- East US
	-- Central US
    -- North Central US
    -- North Europe
    -- West Europe
    -- West US
    
	.NOTES  
    Author     : Paolo Salvatori
    Twitter    : @babosbird
    Blog       : http://blogs.msdn.com/b/paolos/
#>

[CmdletBinding(PositionalBinding=$True)]
Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Path,                                           # required    needs to be alphanumeric    
    [Int]$AutoDeleteOnIdle = -1,                             # optional    default to -1
    [Int]$DefaultMessageTimeToLive = -1,                     # optional    default to -1
    [Int]$DuplicateDetectionHistoryTimeWindow = 10,          # optional    default to 10
    [Bool]$EnableBatchedOperations = $True,                  # optional    default to true
    [Bool]$EnableDeadLetteringOnMessageExpiration = $False,  # optional    default to false
    [Bool]$EnableExpress = $False,                           # optional    default to false
    [Bool]$EnablePartitioning = $False,                      # optional    default to false
    [String]$ForwardDeadLetteredMessagesTo = $Null,          # optional    default to null
    [String]$ForwardTo = $Null,                              # optional    default to null
    [Bool]$IsAnonymousAccessible = $False,                   # optional    default to false
    [Int]$LockDuration = 30,                                 # optional    default to 30
    [Int]$MaxDeliveryCount = 10,                             # optional    default to 10
    [Int]$MaxSizeInMegabytes = 1024,                         # optional    default to 1024
    [Bool]$RequiresDuplicateDetection = $False,              # optional    default to false
    [Bool]$RequiresSession = $False,                         # optional    default to false
    [Bool]$SupportOrdering = $True,                          # optional    default to true
    [String]$UserMetadata = $Null,                           # optional    default to null
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Namespace,                                      # required    needs to be alphanumeric
    [Bool]$CreateACSNamespace = $False,                      # optional    default to $false
    [String]$Location = "West Europe"                        # optional    default to "West Europe"
    )

# Set the output level to verbose and make the script stop on error
$VerbosePreference = "Continue"
$ErrorActionPreference = "Stop"

# WARNING: Make sure to reference the latest version of the \Microsoft.ServiceBus.dll
Write-Output "Adding the [Microsoft.ServiceBus.dll] assembly to the script..."
Add-Type -Path "C:\Projects\Azure\ServiceBusExplorerNew\ServiceBusExplorer2.4Git\bin\Debug\Microsoft.ServiceBus.dll"
Write-Output "The [Microsoft.ServiceBus.dll] assembly has been successfully added to the script."

# Mark the start time of the script execution
$startTime = Get-Date

# Create Azure Service Bus namespace
$CurrentNamespace = Get-AzureSBNamespace -Name $Namespace


# Check if the namespace already exists or needs to be created
if ($CurrentNamespace)
{
    Write-Output "The namespace [$Namespace] already exists in the [$($CurrentNamespace.Region)] region." 
}
else
{
    Write-Host "The [$Namespace] namespace does not exist."
    Write-Output "Creating the [$Namespace] namespace in the [$Location] region..."
    New-AzureSBNamespace -Name $Namespace -Location $Location -CreateACSNamespace $CreateACSNamespace -NamespaceType Messaging
    $CurrentNamespace = Get-AzureSBNamespace -Name $Namespace
    Write-Host "The [$Namespace] namespace in the [$Location] region has been successfully created."
}

# Create the NamespaceManager object to create the queue
Write-Host "Creating a NamespaceManager object for the [$Namespace] namespace..."
$NamespaceManager = [Microsoft.ServiceBus.NamespaceManager]::CreateFromConnectionString($CurrentNamespace.ConnectionString);
Write-Host "NamespaceManager object for the [$Namespace] namespace has been successfully created."

# Check if the queue already exists
if ($NamespaceManager.QueueExists($Path))
{
    Write-Output "The [$Path] queue already exists in the [$Namespace] namespace." 
}
else
{
    Write-Output "Creating the [$Path] queue in the [$Namespace] namespace..."
    $QueueDescription = New-Object -TypeName Microsoft.ServiceBus.Messaging.QueueDescription -ArgumentList $Path
    if ($AutoDeleteOnIdle -ge 5)
    {
        $QueueDescription.AutoDeleteOnIdle = [System.TimeSpan]::FromMinutes($AutoDeleteOnIdle)
    }
    if ($DefaultMessageTimeToLive -gt 0)
    {
        $QueueDescription.DefaultMessageTimeToLive = [System.TimeSpan]::FromMinutes($DefaultMessageTimeToLive)
    }
    if ($DuplicateDetectionHistoryTimeWindow -gt 0)
    {
        $QueueDescription.DuplicateDetectionHistoryTimeWindow = [System.TimeSpan]::FromMinutes($DuplicateDetectionHistoryTimeWindow)
    }
    $QueueDescription.EnableBatchedOperations = $EnableBatchedOperations
    $QueueDescription.EnableDeadLetteringOnMessageExpiration = $EnableDeadLetteringOnMessageExpiration
    $QueueDescription.EnableExpress = $EnableExpress
    $QueueDescription.EnablePartitioning = $EnablePartitioning
    $QueueDescription.ForwardDeadLetteredMessagesTo = $ForwardDeadLetteredMessagesTo
    $QueueDescription.ForwardTo = $ForwardTo
    $QueueDescription.IsAnonymousAccessible = $IsAnonymousAccessible
    if ($LockDuration -gt 0)
    {
        $QueueDescription.LockDuration = [System.TimeSpan]::FromSeconds($LockDuration)
    }
    $QueueDescription.MaxDeliveryCount = $MaxDeliveryCount
    $QueueDescription.MaxSizeInMegabytes = $MaxSizeInMegabytes
    $QueueDescription.RequiresDuplicateDetection = $RequiresDuplicateDetection
    $QueueDescription.RequiresSession = $RequiresSession
    if ($EnablePartitioning)
    {
        $QueueDescription.SupportOrdering = $False
    }
    else
    {
        $QueueDescription.SupportOrdering = $SupportOrdering
    }
    $QueueDescription.UserMetadata = $UserMetadata
    $NamespaceManager.CreateQueue($QueueDescription);
    Write-Host "The [$Path] queue in the [$Namespace] namespace has been successfully created."
}

# Mark the finish time of the script execution
$finishTime = Get-Date

# Output the time consumed in seconds
$TotalTime = ($finishTime - $startTime).TotalSeconds
Write-Output "The script completed in $TotalTime seconds."