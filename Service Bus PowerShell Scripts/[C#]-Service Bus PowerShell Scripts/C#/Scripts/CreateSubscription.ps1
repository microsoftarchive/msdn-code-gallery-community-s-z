<#
    .SYNOPSIS
    This script can be used to provision a namespace and subscription.
            
    .DESCRIPTION
    This script can be used to provision a namespace and a subscription. 

    .PARAMETER  TopicPath
    Specifies the path of the topic that this subscription description belongs to.
    
    .PARAMETER  Name
    Specifies the name of the subscription.

    .PARAMETER  AutoDeleteOnIdle
    Specifies after how many minutes the subscription is automatically deleted. The minimum duration is 5 minutes.

    .PARAMETER  DefaultMessageTimeToLive
    Specifies default message time to live value in minutes. This is the duration after which the message expires, 
    starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself.
    Messages older than their TimeToLive value will expire and no longer be retained in the message store. 
    Subscribers will be unable to receive expired messages.A message can have a lower TimeToLive value than that specified here, 
    but by default TimeToLive is set to MaxValue. Therefore, this property becomes the default time to live value applied to messages.
    
    .PARAMETER  EnableBatchedOperations
    Specifies whether server-side batched operations are enabled.
    
    .PARAMETER  EnableDeadLetteringOnFilterEvaluationExceptions
    Specifies whether this subscription has dead letter support on Filter evaluation exceptions.

    .PARAMETER  EnableDeadLetteringOnMessageExpiration
    Specifies whether this subscription has dead letter support when a message expires.

    .PARAMETER  ForwardDeadLetteredMessagesTo
    Specifies the name to the recipient to which the dead lettered message is forwarded.
    
    .PARAMETER  ForwardTo
    Specifies the name to the recipient to which the message is forwarded.

    .PARAMETER  LockDuration
    Specifies the duration of a peek lock in seconds; that is, the amount of time that the message is locked for other receivers. 
    The maximum value for LockDuration is 5 minutes; the default value is 1 minute.
    
    .PARAMETER  MaxDeliveryCount
    Specifies the maximum delivery count. A message is automatically deadlettered after this number of deliveries.
    
    .PARAMETER  RequiresSession
    Specifies whether the subscription supports the concept of session.
    
    .PARAMETER  SupportOrdering
    Specifies whether the subscription supports ordering.
    
    .PARAMETER  UserMetadata
    Specifies the user metadata.

    .PARAMETER SqlFilter
    Specifies a filter expression written in SQL language-based syntax.

    .PARAMETER SqlRuleAction
    Specifies a set of actions written in SQL language-based syntax that is performed against a BrokeredMessage.

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
    [String]$TopicPath,                                              # required    needs to be alphanumeric
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Name,                                                   # required    needs to be alphanumeric    
    [Int]$AutoDeleteOnIdle = -1,                                     # optional    default to -1
    [Int]$DefaultMessageTimeToLive = -1,                             # optional    default to -1
    [Bool]$EnableBatchedOperations = $True,                          # optional    default to true
    [Bool]$EnableDeadLetteringOnFilterEvaluationExceptions = $True,  # optional    default to true
    [Bool]$EnableDeadLetteringOnMessageExpiration = $False,          # optional    default to false
    [String]$ForwardDeadLetteredMessagesTo = $Null,                  # optional    default to null
    [String]$ForwardTo = $Null,                                      # optional    default to null
    [Int]$LockDuration = 30,                                         # optional    default to 30
    [Int]$MaxDeliveryCount = 10,                                     # optional    default to 10
    [Bool]$RequiresSession = $False,                                 # optional    default to false
    [Bool]$SupportOrdering = $True,                                  # optional    default to true
    [String]$UserMetadata = $Null,                                   # optional    default to null
    [String]$SqlFilter = "1=1",                                      # optional    default to null
    [String]$SqlRuleAction = $Null,                                  # optional    default to null
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Namespace                                               # required    needs to be alphanumeric
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
    Exit
}

# Create the NamespaceManager object to create the subscription
Write-Host "Creating a NamespaceManager object for the [$Namespace] namespace..."
$NamespaceManager = [Microsoft.ServiceBus.NamespaceManager]::CreateFromConnectionString($CurrentNamespace.ConnectionString);
Write-Host "NamespaceManager object for the [$Namespace] namespace has been successfully created."

# Check if the topic exists
if (!$NamespaceManager.TopicExists($TopicPath))
{
    Write-Output "The [$TopicPath] topic does not exit in the [$Namespace] namespace." 
    Exit
}

# Check if the subscription already exists
if ($NamespaceManager.SubscriptionExists($TopicPath, $Name))
{
    Write-Output "The [$Name] subscription already exists in the [$Namespace] namespace." 
}
else
{
    Write-Output "Creating the [$Name] subscription for the [$TopicPath] topic in the [$Namespace] namespace..."
    Write-Output " - SqlFilter: [$SqlFilter]"
    Write-Output " - SqlRuleAction: [$SqlRuleAction]"
    $SubscriptionDescription = New-Object -TypeName Microsoft.ServiceBus.Messaging.SubscriptionDescription -ArgumentList $TopicPath, $Name
    if ($AutoDeleteOnIdle -ge 5)
    {
        $SubscriptionDescription.AutoDeleteOnIdle = [System.TimeSpan]::FromMinutes($AutoDeleteOnIdle)
    }
    if ($DefaultMessageTimeToLive -gt 0)
    {
        $SubscriptionDescription.DefaultMessageTimeToLive = [System.TimeSpan]::FromMinutes($DefaultMessageTimeToLive)
    }
    $SubscriptionDescription.EnableBatchedOperations = $EnableBatchedOperations
    $SubscriptionDescription.EnableDeadLetteringOnFilterEvaluationExceptions = $EnableDeadLetteringOnFilterEvaluationExceptions
    $SubscriptionDescription.EnableDeadLetteringOnMessageExpiration = $EnableDeadLetteringOnMessageExpiration
    $SubscriptionDescription.ForwardDeadLetteredMessagesTo = $ForwardDeadLetteredMessagesTo
    $SubscriptionDescription.ForwardTo = $ForwardTo
    if ($LockDuration -gt 0)
    {
        $SubscriptionDescription.LockDuration = [System.TimeSpan]::FromSeconds($LockDuration)
    }
    $SubscriptionDescription.MaxDeliveryCount = $MaxDeliveryCount
    $SubscriptionDescription.RequiresSession = $RequiresSession
    $SubscriptionDescription.UserMetadata = $UserMetadata
    
    $SqlFilterObject = New-Object -TypeName Microsoft.ServiceBus.Messaging.SqlFilter -ArgumentList $SqlFilter
    $SqlRuleActionObject = New-Object -TypeName Microsoft.ServiceBus.Messaging.SqlRuleAction -ArgumentList $SqlRuleAction
    $RuleDescription = New-Object -TypeName Microsoft.ServiceBus.Messaging.RuleDescription
    $RuleDescription.Filter = $SqlFilterObject
    $RuleDescription.Action = $SqlRuleActionObject

    $NamespaceManager.CreateSubscription($SubscriptionDescription, $RuleDescription);

    Write-Host "The [$Name] subscription for the [$TopicPath] topic has been successfully created."
}

# Mark the finish time of the script execution
$finishTime = Get-Date

# Output the time consumed in seconds
$TotalTime = ($finishTime - $startTime).TotalSeconds
Write-Output "The script completed in $TotalTime seconds."