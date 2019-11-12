<#
    .SYNOPSIS
    This script can be used to provision a namespace and topic.
            
    .DESCRIPTION
    This script can be used to provision a namespace and a topic. 
    
    .PARAMETER  Path
    Specifies the full path of the topic.

    .PARAMETER  AutoDeleteOnIdle
    Specifies after how many minutes the topic is automatically deleted. The minimum duration is 5 minutes.

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
    
    .PARAMETER  EnableExpress
    Specifies whether to enable the topic to be partitioned across multiple message brokers. 
    An express topic holds a message in memory temporarily before writing it to persistent storage.

    .PARAMETER  EnableFilteringMessagesBeforePublishing
    Specifies whether messages should be filtered before publishing.
    
    .PARAMETER  EnablePartitioning
    Specifies whether the topic to be partitioned across multiple message brokers is enabled. 
    
    .PARAMETER  IsAnonymousAccessible
    Specifies whether the message is anonymous accessible.
    
    .PARAMETER  MaxSizeInMegabytes
    Specifies the maximum size of the topic in megabytes, which is the size of memory allocated for the topic.
    
    .PARAMETER  RequiresDuplicateDetection
    Specifies whether the topic requires duplicate detection.
    
    .PARAMETER  SupportOrdering
    Specifies whether the topic supports ordering.
    
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
    [Bool]$EnableFilteringMessagesBeforePublishing = $False, # optional    default to false
    [Bool]$EnableExpress = $False,                           # optional    default to false
    [Bool]$EnablePartitioning = $False,                      # optional    default to false
    [Bool]$IsAnonymousAccessible = $False,                   # optional    default to false
    [Int]$MaxSizeInMegabytes = 1024,                         # optional    default to 1024
    [Bool]$RequiresDuplicateDetection = $False,              # optional    default to false
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

# Create the NamespaceManager object to create the topic
Write-Host "Creating a NamespaceManager object for the [$Namespace] namespace..."
$NamespaceManager = [Microsoft.ServiceBus.NamespaceManager]::CreateFromConnectionString($CurrentNamespace.ConnectionString);
Write-Host "NamespaceManager object for the [$Namespace] namespace has been successfully created."

# Check if the topic already exists
if ($NamespaceManager.TopicExists($Path))
{
    Write-Output "The [$Path] topic already exists in the [$Namespace] namespace." 
}
else
{
    Write-Output "Creating the [$Path] topic in the [$Namespace] namespace..."
    $TopicDescription = New-Object -TypeName Microsoft.ServiceBus.Messaging.TopicDescription -ArgumentList $Path
    if ($AutoDeleteOnIdle -ge 5)
    {
        $TopicDescription.AutoDeleteOnIdle = [System.TimeSpan]::FromMinutes($AutoDeleteOnIdle)
    }
    if ($DefaultMessageTimeToLive -gt 0)
    {
        $TopicDescription.DefaultMessageTimeToLive = [System.TimeSpan]::FromMinutes($DefaultMessageTimeToLive)
    }
    if ($DuplicateDetectionHistoryTimeWindow -gt 0)
    {
        $TopicDescription.DuplicateDetectionHistoryTimeWindow = [System.TimeSpan]::FromMinutes($DuplicateDetectionHistoryTimeWindow)
    }
    $TopicDescription.EnableBatchedOperations = $EnableBatchedOperations
    $TopicDescription.EnableExpress = $EnableExpress
    $TopicDescription.EnableFilteringMessagesBeforePublishing = $EnableFilteringMessagesBeforePublishing
    $TopicDescription.EnablePartitioning = $EnablePartitioning
    $TopicDescription.IsAnonymousAccessible = $IsAnonymousAccessible
    $TopicDescription.MaxSizeInMegabytes = $MaxSizeInMegabytes
    $TopicDescription.RequiresDuplicateDetection = $RequiresDuplicateDetection
    if ($EnablePartitioning)
    {
        $TopicDescription.SupportOrdering = $False
    }
    else
    {
        $TopicDescription.SupportOrdering = $SupportOrdering
    }
    $TopicDescription.UserMetadata = $UserMetadata
    $NamespaceManager.CreateTopic($TopicDescription);
    Write-Host "The [$Path] topic in the [$Namespace] namespace has been successfully created."
}

# Mark the finish time of the script execution
$finishTime = Get-Date

# Output the time consumed in seconds
$TotalTime = ($finishTime - $startTime).TotalSeconds
Write-Output "The script completed in $TotalTime seconds."