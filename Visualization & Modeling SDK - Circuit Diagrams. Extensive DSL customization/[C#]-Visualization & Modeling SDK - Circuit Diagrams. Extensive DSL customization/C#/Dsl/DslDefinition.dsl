<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="e26def83-0f56-4d70-8814-e7353ae12f7e" Description="" Name="Circuits" DisplayName="Circuits" Namespace="Microsoft.Example.Circuits" ProductName="Electronic Circuit Designer" CompanyName="Microsoft" PackageGuid="9da50e81-6fd1-4659-91d6-46c69979b9be" PackageNamespace="" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="2a77b731-7725-48c2-ab1c-3f49c65407eb" Description="" Name="NamedElement" DisplayName="Named Element" InheritanceModifier="Abstract" Namespace="Microsoft.Example.Circuits">
      <Properties>
        <DomainProperty Id="15884371-ec14-4a60-bff5-ee7531473653" Description="" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="bc91c3f0-c89e-4da2-b731-e641515f33e4" Description="" Name="ComponentModel" DisplayName="Component Model" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="NamedElement" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Comment" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ComponentModelHasComments.Comments</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Component" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ComponentModelHasComponents.Components</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Junction" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ComponentModelHasJunctions.Junctions</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="d67e018c-d2cd-4a79-8dbe-455708d95d71" Description="" Name="Component" DisplayName="Component" InheritanceModifier="Abstract" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="NamedElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="590619df-9ac5-455a-a1db-501285552cc1" Description="Description for Microsoft.Example.Circuits.Component.Polarity" Name="Polarity" DisplayName="Polarity">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Comment" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ComponentModelHasComponents.ComponentModel/!ComponentModel/ComponentModelHasComments.Comments</DomainPath>
            <DomainPath>CommentsReferenceComponents.Comments</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="20d71e1d-233a-4d51-a624-17e5872e8ab1" Description="Description for Microsoft.Example.Circuits.Connection" Name="Connection" DisplayName="Connection" InheritanceModifier="Abstract" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="NamedElement" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="53311b53-3109-4791-84b7-653e18747cac" Description="" Name="Comment" DisplayName="Comment" Namespace="Microsoft.Example.Circuits">
      <Properties>
        <DomainProperty Id="a0c1ec6d-25ab-41e7-9561-976cd0dd4c91" Description="" Name="Text" DisplayName="Text" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="550dfd7a-86c2-417f-bbdc-38a13581d3b8" Description="Description for Microsoft.Example.Circuits.Resistor" Name="Resistor" DisplayName="Resistor" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="Component" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="aa0bd9da-edc2-48c9-b341-e4d24fd377f5" Description="Description for Microsoft.Example.Circuits.Resistor.Resistance" Name="Resistance" DisplayName="Resistance">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="97b0c926-082e-4d29-8980-502a3b6d9811" Description="Description for Microsoft.Example.Circuits.ComponentTerminal" Name="ComponentTerminal" DisplayName="Component Terminal" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="Connection" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Comment" />
          </Index>
          <ForwardingPath>
            <DomainPath>ComponentHasComponentTerminal.Component/!Component</DomainPath>
          </ForwardingPath>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="166b94ea-0aaa-48ee-8f05-bb946841800f" Description="Description for Microsoft.Example.Circuits.Junction" Name="Junction" DisplayName="Junction" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="Connection" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="204097fe-b184-43e4-86ec-2c3b312800e3" Description="Description for Microsoft.Example.Circuits.Transistor" Name="Transistor" DisplayName="Transistor" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="Component" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="96ef7372-9d48-4e48-a9f3-9f436c77c514" Description="Description for Microsoft.Example.Circuits.Transistor.Gain" Name="Gain" DisplayName="Gain">
          <Type>
            <ExternalTypeMoniker Name="/System/Int16" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ComponentTerminal" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>TransistorHasBase.Base</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="c86f6ea3-ac06-46ce-aee4-6d23b261157e" Description="Description for Microsoft.Example.Circuits.Capacitor" Name="Capacitor" DisplayName="Capacitor" Namespace="Microsoft.Example.Circuits">
      <BaseClass>
        <DomainClassMoniker Name="Component" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="d524c96d-f6ea-4570-889f-658ab42a4794" Description="Description for Microsoft.Example.Circuits.Capacitor.Is Polar" Name="IsPolar" DisplayName="Is Polar" DefaultValue="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="de56ccfa-4371-403c-9ab8-947cd60dabc3" Description="Description for Microsoft.Example.Circuits.Capacitor.Capacitance" Name="Capacitance" DisplayName="Capacitance">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="6743d47b-89db-45e4-89cb-64baa3372aae" Description="" Name="ComponentModelHasComments" DisplayName="Component Model Has Comments" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <Source>
        <DomainRole Id="22ab9777-e032-4dcb-aad3-9ae45b6b98af" Description="" Name="ComponentModel" DisplayName="ComponentModel" PropertyName="Comments" PropertyDisplayName="Comments">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="65706759-f58a-4e50-9806-b8d7d76f887a" Description="" Name="Comment" DisplayName="Comment" PropertyName="ComponentModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Component Model">
          <RolePlayer>
            <DomainClassMoniker Name="Comment" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="84cea95a-2306-4d81-b7d5-474fa5a57fd9" Description="" Name="ComponentModelHasComponents" DisplayName="ComponentModelHasComponents" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <Source>
        <DomainRole Id="fcddbe78-5744-4d7b-a8c4-6cbe1ff61cce" Description="" Name="ComponentModel" DisplayName="ComponentModel" PropertyName="Components" PropertyDisplayName="Components">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="25fef9df-b0c9-412f-a9a6-b155df27c751" Description="" Name="Component" DisplayName="Component" PropertyName="ComponentModel" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Component Model">
          <RolePlayer>
            <DomainClassMoniker Name="Component" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="47946380-4f7b-408a-848f-d5334cd75407" Description="" Name="CommentsReferenceComponents" DisplayName="Comments Reference Components" Namespace="Microsoft.Example.Circuits">
      <Source>
        <DomainRole Id="b36d2173-8533-440e-b127-16a9961ed9f1" Description="" Name="Comment" DisplayName="Comment" PropertyName="Subjects" IsPropertyGenerator="false" PropertyDisplayName="Subjects">
          <RolePlayer>
            <DomainClassMoniker Name="Comment" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="d7b121d9-2c1e-4f59-9cf6-9a4715226279" Description="" Name="Subject" DisplayName="Subject" PropertyName="Comments" IsPropertyGenerator="false" PropertyDisplayName="Comments">
          <RolePlayer>
            <DomainClassMoniker Name="Component" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="50c76db9-2620-490b-a117-39714ce4bdb0" Description="Description for Microsoft.Example.Circuits.ComponentHasComponentTerminal" Name="ComponentHasComponentTerminal" DisplayName="Component Has Component Terminal" InheritanceModifier="Abstract" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <Source>
        <DomainRole Id="37c127ae-9623-4a1a-8868-04da2eda9bb3" Description="Description for Microsoft.Example.Circuits.ComponentHasComponentTerminal.Component" Name="Component" DisplayName="Component" PropertyName="ComponentTerminals" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Component Terminals">
          <RolePlayer>
            <DomainClassMoniker Name="Component" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4eae5468-5993-41b9-8d4f-5f947fe1616e" Description="Description for Microsoft.Example.Circuits.ComponentHasComponentTerminal.ComponentTerminal" Name="ComponentTerminal" DisplayName="Component Terminal" PropertyName="Component" Multiplicity="One" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Component">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e03e3c03-c1d5-42df-bf9d-ca45e1e90064" Description="Description for Microsoft.Example.Circuits.Wire" Name="Wire" DisplayName="Wire" Namespace="Microsoft.Example.Circuits">
      <Properties>
        <DomainProperty Id="bf6d4c7e-ad62-4dd6-964a-8b23d9b2e295" Description="Description for Microsoft.Example.Circuits.Wire.Is Directed" Name="IsDirected" DisplayName="Is Directed">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="58a88c4e-d564-4e4f-b090-edafe01a6737" Description="Description for Microsoft.Example.Circuits.Wire.SourceConnection" Name="SourceConnection" DisplayName="Source Connection" PropertyName="TargetConnections" PropertyDisplayName="Target Connections">
          <RolePlayer>
            <DomainClassMoniker Name="Connection" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ee0be4b2-6771-4e51-b48d-3835798af95f" Description="Description for Microsoft.Example.Circuits.Wire.TargetConnection" Name="TargetConnection" DisplayName="Target Connection" PropertyName="SourceConnections" PropertyDisplayName="Source Connections">
          <RolePlayer>
            <DomainClassMoniker Name="Connection" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="24d21be4-5481-4cdb-8029-b55a80dfdafa" Description="Description for Microsoft.Example.Circuits.ComponentModelHasJunctions" Name="ComponentModelHasJunctions" DisplayName="Component Model Has Junctions" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <Source>
        <DomainRole Id="5d4b06a9-ef83-41b9-8c23-098352938ffb" Description="Description for Microsoft.Example.Circuits.ComponentModelHasJunctions.ComponentModel" Name="ComponentModel" DisplayName="Component Model" PropertyName="Junctions" PropertyDisplayName="Junctions">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="63f0ae4a-c5d3-4c05-b7f0-e7925638dd26" Description="Description for Microsoft.Example.Circuits.ComponentModelHasJunctions.Junction" Name="Junction" DisplayName="Junction" PropertyName="ComponentModel" Multiplicity="One" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Component Model">
          <RolePlayer>
            <DomainClassMoniker Name="Junction" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="71a0c856-110b-43df-bd35-7f5b71a81c3f" Description="Description for Microsoft.Example.Circuits.ResistorHasT1" Name="ResistorHasT1" DisplayName="Resistor Has T1" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="9ae002ec-2e1f-452a-b88f-52d7763f6afe" Description="PropagateCopy is set to copy terminals." Name="Resistor" DisplayName="Resistor" PropertyName="T1" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="T1">
          <Notes>PropagateCopy is set.
</Notes>
          <RolePlayer>
            <DomainClassMoniker Name="Resistor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a1a22cf9-ec03-4b12-a147-3d8a74e36778" Description="Description for Microsoft.Example.Circuits.ResistorHasT1.T1" Name="T1" DisplayName="T1" PropertyName="R1" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="R1">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="84d0af5c-8fc5-4246-b18a-319834255e5a" Description="Description for Microsoft.Example.Circuits.ResistorHasT2" Name="ResistorHasT2" DisplayName="Resistor Has T2" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="58e5ef97-90d7-4dbf-b756-5fabc63eeeed" Description="PropagateCopy is set to copy terminals." Name="R2" DisplayName="R2" PropertyName="T2" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="T2">
          <Notes>PropagateCopy is set.
</Notes>
          <RolePlayer>
            <DomainClassMoniker Name="Resistor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="081b1778-251d-4e28-9188-8501583f071f" Description="Description for Microsoft.Example.Circuits.ResistorHasT2.T2" Name="T2" DisplayName="T2" PropertyName="R2" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="R2">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6002ac5d-1228-4317-830a-2cdccb0df443" Description="Description for Microsoft.Example.Circuits.TransistorHasBase" Name="TransistorHasBase" DisplayName="Transistor Has Base" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="489734a7-a4a0-431e-996b-f06e29dec51e" Description="PropagateCopy is set to copy terminals." Name="BaseOfTransistor" DisplayName="Base Of Transistor" PropertyName="Base" Multiplicity="One" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Base">
          <RolePlayer>
            <DomainClassMoniker Name="Transistor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ac708137-4fc1-4825-bbc7-0f2b66c175e3" Description="Description for Microsoft.Example.Circuits.TransistorHasBase.Base" Name="Base" DisplayName="Base" PropertyName="BaseOfTransistor" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Base Of Transistor">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c58641fa-29ee-49af-8c6b-9fe56485fcf9" Description="Description for Microsoft.Example.Circuits.TransistorHasCollector" Name="TransistorHasCollector" DisplayName="Transistor Has Collector" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="111c6979-50af-4e45-959f-1afbfa738739" Description="PropagateCopy is set to copy terminals." Name="CollectorOfTransistor" DisplayName="Collector Of Transistor" PropertyName="Collector" Multiplicity="One" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Collector">
          <RolePlayer>
            <DomainClassMoniker Name="Transistor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2c52f29b-11af-4bdb-8a47-15a52502923b" Description="Description for Microsoft.Example.Circuits.TransistorHasCollector.Collector" Name="Collector" DisplayName="Collector" PropertyName="CollectorOfTransistor" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Collector Of Transistor">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="11ce6e42-b520-438b-a674-d6176b4d36ab" Description="Description for Microsoft.Example.Circuits.TransistorHasEmitter" Name="TransistorHasEmitter" DisplayName="Transistor Has Emitter" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="a72a05c8-561d-434c-9a48-4f70dcba9d24" Description="PropagateCopy is set to copy terminals." Name="EmitterOfTransistor" DisplayName="Emitter Of Transistor" PropertyName="Emitter" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Emitter">
          <RolePlayer>
            <DomainClassMoniker Name="Transistor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9cb509df-8bf3-4a4c-97d9-471b0701f3ac" Description="Description for Microsoft.Example.Circuits.TransistorHasEmitter.Emitter" Name="Emitter" DisplayName="Emitter" PropertyName="EmitterOfTransistor" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Emitter Of Transistor">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b8fa5038-cf5c-407f-b405-d03f19179069" Description="Description for Microsoft.Example.Circuits.CapacitorHasT1" Name="CapacitorHasT1" DisplayName="Capacitor Has T1" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="203fd785-e783-462b-96d0-8870ad303228" Description="PropagateCopy is set to copy terminals." Name="CapacitorT1" DisplayName="Capacitor T1" PropertyName="T1" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="T1">
          <RolePlayer>
            <DomainClassMoniker Name="Capacitor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4a5f92e6-c900-4b73-b684-3180b3036e59" Description="Description for Microsoft.Example.Circuits.CapacitorHasT1.T1" Name="T1" DisplayName="T1" PropertyName="CapacitorT1" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Capacitor T1">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9e98c146-34a1-4cf9-9bb4-2d551d6f3122" Description="Description for Microsoft.Example.Circuits.CapacitorHasT2" Name="CapacitorHasT2" DisplayName="Capacitor Has T2" Namespace="Microsoft.Example.Circuits" IsEmbedding="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="44bc0d48-fd5a-4f48-8273-be0a93a19a2a" Description="PropagateCopy is set to copy terminals." Name="CapacitorT2" DisplayName="Capacitor T2" PropertyName="T2" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="T2">
          <RolePlayer>
            <DomainClassMoniker Name="Capacitor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="18bf8808-aafb-4ea8-a6b6-55f94b261880" Description="Description for Microsoft.Example.Circuits.CapacitorHasT2.T2" Name="T2" DisplayName="T2" PropertyName="CapacitorT2" Multiplicity="ZeroOne" PropagatesDelete="true" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Capacitor T2">
          <RolePlayer>
            <DomainClassMoniker Name="ComponentTerminal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <ExternalType Name="Color" Namespace="System.Drawing" />
  </Types>
  <Shapes>
    <Port Id="9543cd71-7245-4a8a-86c3-0279b1c82cee" Description="Description for Microsoft.Example.Circuits.ComponentTerminalShape" Name="ComponentTerminalShape" DisplayName="Component Terminal Shape" Namespace="Microsoft.Example.Circuits" FixedTooltipText="Component Terminal Shape" FillColor="Black" InitialWidth="0.05" InitialHeight="0.05" FillGradientMode="None" Geometry="Circle" />
    <GeometryShape Id="4a5e1893-81c1-427f-b3d6-05a22aeb2f55" Description="" Name="ResistorShape" DisplayName="Resistor Shape" Namespace="Microsoft.Example.Circuits" TooltipType="Fixed" FixedTooltipText="Double-click to rotate" FillColor="LightYellow" InitialWidth="1" InitialHeight="0.2" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="ComponentShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="4e6b1597-c952-41c4-a1d0-c352da6b175e" Description="" Name="CommentBoxShape" DisplayName="Comment Box Shape" Namespace="Microsoft.Example.Circuits" GeneratesDoubleDerived="true" FixedTooltipText="Comment Box Shape" FillColor="Khaki" OutlineColor="Brown" InitialHeight="0.3" Geometry="Rectangle">
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Comment" DisplayName="Comment" DefaultText="" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="1431ad0f-69ce-4542-add4-9b8171e074de" Description="Description for Microsoft.Example.Circuits.JunctionShape" Name="JunctionShape" DisplayName="Junction Shape" Namespace="Microsoft.Example.Circuits" FixedTooltipText="Junction Shape" FillColor="Black" InitialWidth="0.1" InitialHeight="0.1" FillGradientMode="None" HasDefaultConnectionPoints="true" Geometry="Circle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="ComponentShape" />
      </BaseGeometryShape>
    </GeometryShape>
    <GeometryShape Id="65cbe568-5de1-4de2-a36f-6a025893cd07" Description="Description for Microsoft.Example.Circuits.ComponentShape" Name="ComponentShape" DisplayName="Component Shape" InheritanceModifier="Abstract" Namespace="Microsoft.Example.Circuits" FixedTooltipText="Component Shape" InitialHeight="1" Geometry="Rectangle">
      <Properties>
        <DomainProperty Id="9ce90fe7-2b1c-4cc9-82cc-8497b85f79d6" Description="Description for Microsoft.Example.Circuits.ComponentShape.Rotate" Name="rotate" DisplayName="Rotate" Category="Orientation" GetterAccessModifier="Assembly" SetterAccessModifier="Assembly">
          <Type>
            <ExternalTypeMoniker Name="/System/Int16" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9e01e42e-849e-4bc4-901f-09955402be89" Description="Description for Microsoft.Example.Circuits.ComponentShape.Flip" Name="flip" DisplayName="Flip" Category="Orientation" GetterAccessModifier="Assembly" SetterAccessModifier="Assembly">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ShapeHasDecorators Position="OuterBottomLeft" HorizontalOffset="0" VerticalOffset="0" isMoveable="true">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="5fc336fa-1909-4da5-a8e9-361b77ae9e66" Description="Description for Microsoft.Example.Circuits.TransistorShape" Name="TransistorShape" DisplayName="Transistor Shape" Namespace="Microsoft.Example.Circuits" GeneratesDoubleDerived="true" TooltipType="Fixed" FixedTooltipText="Right-click to rotate or flip." FillColor="Transparent" OutlineColor="Transparent" InitialWidth="0.8" InitialHeight="0.8" FillGradientMode="None" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="ComponentShape" />
      </BaseGeometryShape>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="PNPImage" DisplayName="PNPImage" DefaultIcon="Resources\TransistorPNP.bmp" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="NPNImage" DisplayName="NPNImage" DefaultIcon="Resources\TransistorNPN.bmp" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="3ddb7fb0-dabb-4610-aea5-6e9ad19aa641" Description="Description for Microsoft.Example.Circuits.CapacitorShape" Name="CapacitorShape" DisplayName="Capacitor Shape" Namespace="Microsoft.Example.Circuits" GeneratesDoubleDerived="true" TooltipType="Fixed" FixedTooltipText="Double-click to rotate" OutlineColor="White" InitialWidth="0.5" InitialHeight="0.5" FillGradientMode="None" Geometry="Rectangle">
      <BaseGeometryShape>
        <GeometryShapeMoniker Name="ComponentShape" />
      </BaseGeometryShape>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0.01" VerticalOffset="-0.02">
        <IconDecorator Name="NonPolarImage" DisplayName="Non Polar Image" DefaultIcon="Resources\CapacitorHnp.bmp" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0.01" VerticalOffset="-0.02">
        <IconDecorator Name="PolarImage" DisplayName="Polar Image" DefaultIcon="Resources\CapacitorVnp.bmp" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="ca4b4ed5-60c5-4efb-bcd1-cccb093f548d" Description="" Name="WireConnector" DisplayName="Wire Connector" Namespace="Microsoft.Example.Circuits" FixedTooltipText="Wire Connector" ExposesColorAsProperty="true">
      <Properties>
        <DomainProperty Id="297c777a-91c9-4755-9d7e-56f024242fe6" Description="Description for Microsoft.Example.Circuits.WireConnector.Color" Name="Color" DisplayName="Color" Kind="CustomStorage">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
      </Properties>
    </Connector>
    <Connector Id="fbec22db-654b-457d-a7a4-722cfdb0e2c0" Description="" Name="CommentLink" DisplayName="Comment Link" Namespace="Microsoft.Example.Circuits" FixedTooltipText="Comment Link" Color="Gray" DashStyle="Dot" RoutingStyle="Straight" />
  </Connectors>
  <XmlSerializationBehavior Name="ComponentsSerializationBehavior" Namespace="Microsoft.Example.Circuits">
    <ClassData>
      <XmlClassData TypeName="NamedElement" MonikerAttributeName="" MonikerElementName="" ElementName="" MonikerTypeName="">
        <DomainClassMoniker Name="NamedElement" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="NamedElement/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ComponentModel" MonikerAttributeName="" MonikerElementName="componentModelMoniker" ElementName="componentModel" MonikerTypeName="ComponentModelMoniker">
        <DomainClassMoniker Name="ComponentModel" />
        <ElementData>
          <XmlRelationshipData RoleElementName="comments">
            <DomainRelationshipMoniker Name="ComponentModelHasComments" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="components">
            <DomainRelationshipMoniker Name="ComponentModelHasComponents" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="junctions">
            <DomainRelationshipMoniker Name="ComponentModelHasJunctions" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Component" MonikerAttributeName="" MonikerElementName="componentMoniker" ElementName="component" MonikerTypeName="ComponentMoniker">
        <DomainClassMoniker Name="Component" />
        <ElementData>
          <XmlRelationshipData RoleElementName="componentTerminals">
            <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="polarity">
            <DomainPropertyMoniker Name="Component/Polarity" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Connection" MonikerAttributeName="" MonikerElementName="connectionMoniker" ElementName="connection" MonikerTypeName="ConnectionMoniker">
        <DomainClassMoniker Name="Connection" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetConnections">
            <DomainRelationshipMoniker Name="Wire" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Comment" MonikerAttributeName="" SerializeId="true" MonikerElementName="commentMoniker" ElementName="comment" MonikerTypeName="CommentMoniker">
        <DomainClassMoniker Name="Comment" />
        <ElementData>
          <XmlPropertyData XmlName="text">
            <DomainPropertyMoniker Name="Comment/Text" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="subjects">
            <DomainRelationshipMoniker Name="CommentsReferenceComponents" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ComponentModelHasComments" MonikerAttributeName="" MonikerElementName="componentModelHasCommentsMoniker" ElementName="componentModelHasComments" MonikerTypeName="ComponentModelHasCommentsMoniker">
        <DomainRelationshipMoniker Name="ComponentModelHasComments" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentModelHasComponents" MonikerAttributeName="" MonikerElementName="componentModelHasComponentsMoniker" ElementName="componentModelHasComponents" MonikerTypeName="ComponentModelHasComponentsMoniker">
        <DomainRelationshipMoniker Name="ComponentModelHasComponents" />
      </XmlClassData>
      <XmlClassData TypeName="CommentsReferenceComponents" MonikerAttributeName="" MonikerElementName="commentsReferenceComponentsMoniker" ElementName="commentsReferenceComponents" MonikerTypeName="CommentsReferenceComponentsMoniker">
        <DomainRelationshipMoniker Name="CommentsReferenceComponents" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentTerminalShape" MonikerAttributeName="" MonikerElementName="componentTerminalShapeMoniker" ElementName="componentTerminalShape" MonikerTypeName="ComponentTerminalShapeMoniker">
        <PortMoniker Name="ComponentTerminalShape" />
      </XmlClassData>
      <XmlClassData TypeName="ResistorShape" MonikerAttributeName="" MonikerElementName="resistorShapeMoniker" ElementName="resistorShape" MonikerTypeName="ResistorShapeMoniker">
        <GeometryShapeMoniker Name="ResistorShape" />
      </XmlClassData>
      <XmlClassData TypeName="CommentBoxShape" MonikerAttributeName="" MonikerElementName="commentBoxShapeMoniker" ElementName="commentBoxShape" MonikerTypeName="CommentBoxShapeMoniker">
        <GeometryShapeMoniker Name="CommentBoxShape" />
      </XmlClassData>
      <XmlClassData TypeName="WireConnector" MonikerAttributeName="" MonikerElementName="wireConnectorMoniker" ElementName="wireConnector" MonikerTypeName="WireConnectorMoniker">
        <ConnectorMoniker Name="WireConnector" />
        <ElementData>
          <XmlPropertyData XmlName="color">
            <DomainPropertyMoniker Name="WireConnector/Color" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CommentLink" MonikerAttributeName="" MonikerElementName="commentLinkMoniker" ElementName="commentLink" MonikerTypeName="CommentLinkMoniker">
        <ConnectorMoniker Name="CommentLink" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentDiagram" MonikerAttributeName="" MonikerElementName="componentDiagramMoniker" ElementName="componentDiagram" MonikerTypeName="ComponentDiagramMoniker">
        <DiagramMoniker Name="ComponentDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Resistor" MonikerAttributeName="" MonikerElementName="resistorMoniker" ElementName="resistor" MonikerTypeName="ResistorMoniker">
        <DomainClassMoniker Name="Resistor" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="t1">
            <DomainRelationshipMoniker Name="ResistorHasT1" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="t2">
            <DomainRelationshipMoniker Name="ResistorHasT2" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="resistance">
            <DomainPropertyMoniker Name="Resistor/Resistance" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ComponentTerminal" MonikerAttributeName="" MonikerElementName="componentTerminalMoniker" ElementName="componentTerminal" MonikerTypeName="ComponentTerminalMoniker">
        <DomainClassMoniker Name="ComponentTerminal" />
      </XmlClassData>
      <XmlClassData TypeName="Junction" MonikerAttributeName="" MonikerElementName="junctionMoniker" ElementName="junction" MonikerTypeName="JunctionMoniker">
        <DomainClassMoniker Name="Junction" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentHasComponentTerminal" MonikerAttributeName="" MonikerElementName="componentHasComponentTerminalMoniker" ElementName="componentHasComponentTerminal" MonikerTypeName="ComponentHasComponentTerminalMoniker">
        <DomainRelationshipMoniker Name="ComponentHasComponentTerminal" />
      </XmlClassData>
      <XmlClassData TypeName="Wire" MonikerAttributeName="" MonikerElementName="wireMoniker" ElementName="wire" MonikerTypeName="WireMoniker">
        <DomainRelationshipMoniker Name="Wire" />
        <ElementData>
          <XmlPropertyData XmlName="isDirected">
            <DomainPropertyMoniker Name="Wire/IsDirected" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="JunctionShape" MonikerAttributeName="" MonikerElementName="junctionShapeMoniker" ElementName="junctionShape" MonikerTypeName="JunctionShapeMoniker">
        <GeometryShapeMoniker Name="JunctionShape" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentModelHasJunctions" MonikerAttributeName="" MonikerElementName="componentModelHasJunctionsMoniker" ElementName="componentModelHasJunctions" MonikerTypeName="ComponentModelHasJunctionsMoniker">
        <DomainRelationshipMoniker Name="ComponentModelHasJunctions" />
      </XmlClassData>
      <XmlClassData TypeName="ResistorHasT1" MonikerAttributeName="" MonikerElementName="resistorHasT1Moniker" ElementName="resistorHasT1" MonikerTypeName="ResistorHasT1Moniker">
        <DomainRelationshipMoniker Name="ResistorHasT1" />
      </XmlClassData>
      <XmlClassData TypeName="ResistorHasT2" MonikerAttributeName="" MonikerElementName="resistorHasT2Moniker" ElementName="resistorHasT2" MonikerTypeName="ResistorHasT2Moniker">
        <DomainRelationshipMoniker Name="ResistorHasT2" />
      </XmlClassData>
      <XmlClassData TypeName="Transistor" MonikerAttributeName="" MonikerElementName="transistorMoniker" ElementName="transistor" MonikerTypeName="TransistorMoniker">
        <DomainClassMoniker Name="Transistor" />
        <ElementData>
          <XmlRelationshipData RoleElementName="base">
            <DomainRelationshipMoniker Name="TransistorHasBase" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="collector">
            <DomainRelationshipMoniker Name="TransistorHasCollector" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="emitter">
            <DomainRelationshipMoniker Name="TransistorHasEmitter" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="gain">
            <DomainPropertyMoniker Name="Transistor/Gain" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TransistorHasBase" MonikerAttributeName="" MonikerElementName="transistorHasBaseMoniker" ElementName="transistorHasBase" MonikerTypeName="TransistorHasBaseMoniker">
        <DomainRelationshipMoniker Name="TransistorHasBase" />
      </XmlClassData>
      <XmlClassData TypeName="TransistorHasCollector" MonikerAttributeName="" MonikerElementName="transistorHasCollectorMoniker" ElementName="transistorHasCollector" MonikerTypeName="TransistorHasCollectorMoniker">
        <DomainRelationshipMoniker Name="TransistorHasCollector" />
      </XmlClassData>
      <XmlClassData TypeName="TransistorHasEmitter" MonikerAttributeName="" MonikerElementName="transistorHasEmitterMoniker" ElementName="transistorHasEmitter" MonikerTypeName="TransistorHasEmitterMoniker">
        <DomainRelationshipMoniker Name="TransistorHasEmitter" />
      </XmlClassData>
      <XmlClassData TypeName="ComponentShape" MonikerAttributeName="" MonikerElementName="componentShapeMoniker" ElementName="componentShape" MonikerTypeName="ComponentShapeMoniker">
        <GeometryShapeMoniker Name="ComponentShape" />
        <ElementData>
          <XmlPropertyData XmlName="rotate">
            <DomainPropertyMoniker Name="ComponentShape/rotate" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="flip">
            <DomainPropertyMoniker Name="ComponentShape/flip" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TransistorShape" MonikerAttributeName="" MonikerElementName="transistorShapeMoniker" ElementName="transistorShape" MonikerTypeName="TransistorShapeMoniker">
        <GeometryShapeMoniker Name="TransistorShape" />
      </XmlClassData>
      <XmlClassData TypeName="Capacitor" MonikerAttributeName="" MonikerElementName="capacitorMoniker" ElementName="capacitor" MonikerTypeName="CapacitorMoniker">
        <DomainClassMoniker Name="Capacitor" />
        <ElementData>
          <XmlPropertyData XmlName="isPolar">
            <DomainPropertyMoniker Name="Capacitor/IsPolar" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="t1">
            <DomainRelationshipMoniker Name="CapacitorHasT1" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="t2">
            <DomainRelationshipMoniker Name="CapacitorHasT2" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="capacitance">
            <DomainPropertyMoniker Name="Capacitor/Capacitance" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CapacitorShape" MonikerAttributeName="" MonikerElementName="capacitorShapeMoniker" ElementName="capacitorShape" MonikerTypeName="CapacitorShapeMoniker">
        <GeometryShapeMoniker Name="CapacitorShape" />
      </XmlClassData>
      <XmlClassData TypeName="CapacitorHasT1" MonikerAttributeName="" MonikerElementName="capacitorHasT1Moniker" ElementName="capacitorHasT1" MonikerTypeName="CapacitorHasT1Moniker">
        <DomainRelationshipMoniker Name="CapacitorHasT1" />
      </XmlClassData>
      <XmlClassData TypeName="CapacitorHasT2" MonikerAttributeName="" MonikerElementName="capacitorHasT2Moniker" ElementName="capacitorHasT2" MonikerTypeName="CapacitorHasT2Moniker">
        <DomainRelationshipMoniker Name="CapacitorHasT2" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ComponentExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="CommentsReferenceComponentsBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="CommentsReferenceComponents" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Comment" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Component" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="WireBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Wire" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Connection" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Connection" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="6d81a7a1-1943-48f8-8d31-f7ccd273b1c8" Description="" Name="ComponentDiagram" DisplayName="Component Diagram" Namespace="Microsoft.Example.Circuits" GeneratesDoubleDerived="true">
    <Class>
      <DomainClassMoniker Name="ComponentModel" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="ComponentTerminal" />
        <ParentElementPath>
          <DomainPath>ComponentHasComponentTerminal.Component/!Component</DomainPath>
        </ParentElementPath>
        <PortMoniker Name="ComponentTerminalShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Resistor" />
        <ParentElementPath>
          <DomainPath>ComponentModelHasComponents.ComponentModel/!ComponentModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ComponentShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="NamedElement/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="ResistorShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Comment" />
        <ParentElementPath>
          <DomainPath>ComponentModelHasComments.ComponentModel/!ComponentModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="CommentBoxShape/Comment" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Comment/Text" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CommentBoxShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Junction" />
        <ParentElementPath>
          <DomainPath>ComponentModelHasJunctions.ComponentModel/!ComponentModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ComponentShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="NamedElement/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="JunctionShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Transistor" />
        <ParentElementPath>
          <DomainPath>ComponentModelHasComponents.ComponentModel/!ComponentModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <IconDecoratorMoniker Name="TransistorShape/NPNImage" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="Component/Polarity" />
            <PropertyFilters>
              <PropertyFilter FilteringValue="False" />
            </PropertyFilters>
          </VisibilityPropertyPath>
        </DecoratorMap>
        <DecoratorMap>
          <IconDecoratorMoniker Name="TransistorShape/PNPImage" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="Component/Polarity" />
            <PropertyFilters>
              <PropertyFilter FilteringValue="True" />
            </PropertyFilters>
          </VisibilityPropertyPath>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ComponentShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="NamedElement/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="TransistorShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Capacitor" />
        <ParentElementPath>
          <DomainPath>ComponentModelHasComponents.ComponentModel/!ComponentModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <IconDecoratorMoniker Name="CapacitorShape/NonPolarImage" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="Capacitor/IsPolar" />
            <PropertyFilters>
              <PropertyFilter FilteringValue="False" />
            </PropertyFilters>
          </VisibilityPropertyPath>
        </DecoratorMap>
        <DecoratorMap>
          <IconDecoratorMoniker Name="CapacitorShape/PolarImage" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="Capacitor/IsPolar" />
            <PropertyFilters>
              <PropertyFilter FilteringValue="True" />
            </PropertyFilters>
          </VisibilityPropertyPath>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ComponentShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="NamedElement/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CapacitorShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="WireConnector" />
        <DomainRelationshipMoniker Name="Wire" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="CommentLink" />
        <DomainRelationshipMoniker Name="CommentsReferenceComponents" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="circuit" EditorGuid="06ef3ec2-067a-4b85-a041-03ed8158318f">
    <RootClass>
      <DomainClassMoniker Name="ComponentModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ComponentsSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Circuit Diagrams">
      <ElementTool Name="Resistor" ToolboxIcon="Resources\ResistorTool.bmp" Caption="Resistor" Tooltip="Create a Resistor" HelpKeyword="CreateComponentF1Keyword">
        <DomainClassMoniker Name="Resistor" />
      </ElementTool>
      <ConnectionTool Name="Wire" ToolboxIcon="Resources\WireTool.bmp" Caption="Wire" Tooltip="Connect connections" HelpKeyword="ConnectAssociationF1Keyword">
        <ConnectionBuilderMoniker Name="Circuits/WireBuilder" />
      </ConnectionTool>
      <ElementTool Name="Comment" ToolboxIcon="resources\CommentTool.bmp" Caption="Comment" Tooltip="Create a Comment" HelpKeyword="ConnectCommentF1Keyword">
        <DomainClassMoniker Name="Comment" />
      </ElementTool>
      <ConnectionTool Name="CommentConnector" ToolboxIcon="resources\CommentLinkTool.bmp" Caption="Comment Connector" Tooltip="Connect a Comment to its subject(s)." HelpKeyword="ConnectCommentsReferenceTypesF1Keyword">
        <ConnectionBuilderMoniker Name="Circuits/CommentsReferenceComponentsBuilder" />
      </ConnectionTool>
      <ElementTool Name="Junction" ToolboxIcon="Resources\JunctionTool.bmp" Caption="Junction" Tooltip="Junction" HelpKeyword="Junction">
        <DomainClassMoniker Name="Junction" />
      </ElementTool>
      <ElementTool Name="TransistorTool" ToolboxIcon="Resources\TransistorTool.bmp" Caption="Transistor" Tooltip="Transistor Tool" HelpKeyword="TransistorTool">
        <DomainClassMoniker Name="Transistor" />
      </ElementTool>
      <ElementTool Name="CapacitorTool" ToolboxIcon="Resources\CCapacitorTool.bmp" Caption="Capacitor" Tooltip="Capacitor Tool" HelpKeyword="CapacitorTool">
        <DomainClassMoniker Name="Capacitor" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesLoad="true" />
    <DiagramMoniker Name="ComponentDiagram" />
  </Designer>
  <Explorer ExplorerGuid="4ae27eb1-2e4f-4733-acd9-03ec119a9851" Title="">
    <ExplorerBehaviorMoniker Name="Circuits/ComponentExplorer" />
  </Explorer>
</Dsl>