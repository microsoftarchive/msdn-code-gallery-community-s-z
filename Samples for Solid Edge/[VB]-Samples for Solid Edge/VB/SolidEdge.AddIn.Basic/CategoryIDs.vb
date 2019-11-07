Namespace SolidEdge.AddIn.Basic
	''' <summary>
	''' Solid Edge category IDs imported from \sdk\include\secatids.h.
	''' </summary>
	Public NotInheritable Class CategoryIDs

		Private Sub New()
		End Sub

		Public Const CATID_SolidEdgeAddIn As String = "{26B1D2D1-2B03-11d2-B589-080036E8B802}"
		Public Const CATID_SEApplication As String = "{26618394-09D6-11d1-BA07-080036230602}"
		Public Const CATID_SEAssembly As String = "{26618395-09D6-11d1-BA07-080036230602}"
		Public Const CATID_SEMotion As String = "{67ED3F40-A351-11d3-A40B-0004AC969602}"
		Public Const CATID_SEPart As String = "{26618396-09D6-11d1-BA07-080036230602}"
		Public Const CATID_SEProfile As String = "{26618397-09D6-11d1-BA07-080036230602}"
		Public Const CATID_SEFeatureRecognition As String = "{E6F9C8DC-B256-11d3-A41E-0004AC969602}"
		Public Const CATID_SESheetMetal As String = "{26618398-09D6-11D1-BA07-080036230602}"
		Public Const CATID_SEDraft As String = "{08244193-B78D-11D2-9216-00C04F79BE98}"
		Public Const CATID_SEWeldment As String = "{7313526A-276F-11D4-B64E-00C04F79B2BF}"
		Public Const CATID_SEXpresRoute As String = "{1661432A-489C-4714-B1B2-61E85CFD0B71}"
		Public Const CATID_SEExplode As String = "{23BE4212-5810-478b-94FF-B4D682C1B538}"
		Public Const CATID_SESimplify As String = "{CE3DCEBF-E36E-4851-930A-ED892FE0772A}"
		Public Const CATID_SEStudio As String = "{D35550BF-0810-4f67-97D5-789EDBC23F4D}"
		Public Const CATID_SELayout As String = "{27B34941-FFCD-4768-9102-0B6698656CEA}"
		Public Const CATID_SESketch As String = "{0DDABC90-125E-4cfe-9CB7-DC97FB74CCF4}"
		Public Const CATID_SEProfileHole As String = "{0D5CC5F7-5BA3-4d2f-B6A9-31D9B401FE30}"
		Public Const CATID_SEProfilePattern As String = "{7BD57D4B-BA47-4a79-A4E2-DFFD43B97ADF}"
		Public Const CATID_SEProfileRevolved As String = "{FB73C683-1536-4073-B792-E28B8D31146E}"
		Public Const CATID_SEDrawingViewEdit As String = "{8DBC3B5F-02D6-4241-BE96-B12EAF83FAE6}"
		Public Const CATID_SERefAxis As String = "{B21CCFF8-1FDD-4f44-9417-F1EAE06888FA}"
		Public Const CATID_SECuttingPlaneLine As String = "{7C6F65F1-A02D-4c3c-8063-8F54B59B34E3}"
		Public Const CATID_SEBrokenOutSectionProfile As String = "{534CAB66-8089-4e18-8FC4-6FA5A957E445}"
		Public Const CATID_SEFrame As String = "{D84119E8-F844-4823-B3A0-D4F31793028A}"
		Public Const CATID_2dModel As String = "{F6031120-7D99-48a7-95FC-EEE8038D7996}"
		Public Const CATID_EditBlockView As String = "{892A1CDA-12AE-4619-BB69-C5156C929832}"
		Public Const CATID_SEComponentSketchInPart As String = "{FAB8DC23-00F4-4872-8662-18DD013F2095}"
		Public Const CATID_SEComponentSketchInAsm As String = "{86D925FB-66ED-40d2-AA3D-D04E74838141}"
		Public Const CATID_SEHarness As String = "{5337A0AB-23ED-4261-A238-00E2070406FC}"
		Public Const CATID_SEAll As String = "{C484ED57-DBB6-4a83-BEDB-C08600AF07BF}"
		Public Const CATID_SEAllDocumentEnvrionments As String = "{BAD41B8D-18FF-42c9-9611-8A00E6921AE8}"
		Public Const CATID_SEDMPart As String = "{D9B0BB85-3A6C-4086-A0BB-88A1AAD57A58}"
		Public Const CATID_SEDMSheetMetal As String = "{9CBF2809-FF80-4dbc-98F2-B82DABF3530F}"
		Public Const CATID_SEDMAssembly As String = "{2C3C2A72-3A4A-471d-98B5-E3A8CFA4A2BF}"

		Public Shared ReadOnly SolidEdgeAddIn As New Guid(CATID_SolidEdgeAddIn)
		Public Shared ReadOnly SEApplication As New Guid(CATID_SEApplication)
		Public Shared ReadOnly SEAssembly As New Guid(CATID_SEAssembly)
		Public Shared ReadOnly SEMotion As New Guid(CATID_SEMotion)
		Public Shared ReadOnly SEPart As New Guid(CATID_SEPart)
		Public Shared ReadOnly SEProfile As New Guid(CATID_SEProfile)
		Public Shared ReadOnly SEFeatureRecognition As New Guid(CATID_SEFeatureRecognition)
		Public Shared ReadOnly SESheetMetal As New Guid(CATID_SESheetMetal)
		Public Shared ReadOnly SEDraft As New Guid(CATID_SEDraft)
		Public Shared ReadOnly SEWeldment As New Guid(CATID_SEWeldment)
		Public Shared ReadOnly SEXpresRoute As New Guid(CATID_SEXpresRoute)
		Public Shared ReadOnly SEExplode As New Guid(CATID_SEExplode)
		Public Shared ReadOnly SESimplify As New Guid(CATID_SESimplify)
		Public Shared ReadOnly SEStudio As New Guid(CATID_SEStudio)
		Public Shared ReadOnly SELayout As New Guid(CATID_SELayout)
		Public Shared ReadOnly SESketch As New Guid(CATID_SESketch)
		Public Shared ReadOnly SEProfileHole As New Guid(CATID_SEProfileHole)
		Public Shared ReadOnly SEProfilePattern As New Guid(CATID_SEProfilePattern)
		Public Shared ReadOnly SEProfileRevolved As New Guid(CATID_SEProfileRevolved)
		Public Shared ReadOnly SEDrawingViewEdit As New Guid(CATID_SEDrawingViewEdit)
		Public Shared ReadOnly SERefAxis As New Guid(CATID_SERefAxis)
		Public Shared ReadOnly SECuttingPlaneLine As New Guid(CATID_SECuttingPlaneLine)
		Public Shared ReadOnly SEBrokenOutSectionProfile As New Guid(CATID_SEBrokenOutSectionProfile)
		Public Shared ReadOnly SEFrame As New Guid(CATID_SEFrame)
		Public Shared ReadOnly SE2dModel As New Guid(CATID_2dModel)
		Public Shared ReadOnly EditBlockView As New Guid(CATID_EditBlockView)
		Public Shared ReadOnly SEComponentSketchInPart As New Guid(CATID_SEComponentSketchInPart)
		Public Shared ReadOnly SEComponentSketchInAsm As New Guid(CATID_SEComponentSketchInAsm)
		Public Shared ReadOnly SEHarness As New Guid(CATID_SEHarness)
		Public Shared ReadOnly SEAll As New Guid(CATID_SEAll)
		Public Shared ReadOnly SEAllDocumentEnvrionments As New Guid(CATID_SEAllDocumentEnvrionments)
		Public Shared ReadOnly SEDMPart As New Guid(CATID_SEDMPart)
		Public Shared ReadOnly SEDMSheetMetal As New Guid(CATID_SEDMSheetMetal)
		Public Shared ReadOnly SEDMAssembly As New Guid(CATID_SEDMAssembly)
	End Class
End Namespace
