using System;

namespace SolidEdge.AddIn.Basic
{
    /// <summary>
    /// Solid Edge category IDs imported from \sdk\include\secatids.h.
    /// </summary>
    public static class CategoryIDs
    {
        public const string CATID_SolidEdgeAddIn = "{26B1D2D1-2B03-11d2-B589-080036E8B802}";
        public const string CATID_SEApplication = "{26618394-09D6-11d1-BA07-080036230602}";
        public const string CATID_SEAssembly = "{26618395-09D6-11d1-BA07-080036230602}";
        public const string CATID_SEMotion = "{67ED3F40-A351-11d3-A40B-0004AC969602}";
        public const string CATID_SEPart = "{26618396-09D6-11d1-BA07-080036230602}";
        public const string CATID_SEProfile = "{26618397-09D6-11d1-BA07-080036230602}";
        public const string CATID_SEFeatureRecognition = "{E6F9C8DC-B256-11d3-A41E-0004AC969602}";
        public const string CATID_SESheetMetal = "{26618398-09D6-11D1-BA07-080036230602}";
        public const string CATID_SEDraft = "{08244193-B78D-11D2-9216-00C04F79BE98}";
        public const string CATID_SEWeldment = "{7313526A-276F-11D4-B64E-00C04F79B2BF}";
        public const string CATID_SEXpresRoute = "{1661432A-489C-4714-B1B2-61E85CFD0B71}";
        public const string CATID_SEExplode = "{23BE4212-5810-478b-94FF-B4D682C1B538}";
        public const string CATID_SESimplify = "{CE3DCEBF-E36E-4851-930A-ED892FE0772A}";
        public const string CATID_SEStudio = "{D35550BF-0810-4f67-97D5-789EDBC23F4D}";
        public const string CATID_SELayout = "{27B34941-FFCD-4768-9102-0B6698656CEA}";
        public const string CATID_SESketch = "{0DDABC90-125E-4cfe-9CB7-DC97FB74CCF4}";
        public const string CATID_SEProfileHole = "{0D5CC5F7-5BA3-4d2f-B6A9-31D9B401FE30}";
        public const string CATID_SEProfilePattern = "{7BD57D4B-BA47-4a79-A4E2-DFFD43B97ADF}";
        public const string CATID_SEProfileRevolved = "{FB73C683-1536-4073-B792-E28B8D31146E}";
        public const string CATID_SEDrawingViewEdit = "{8DBC3B5F-02D6-4241-BE96-B12EAF83FAE6}";
        public const string CATID_SERefAxis = "{B21CCFF8-1FDD-4f44-9417-F1EAE06888FA}";
        public const string CATID_SECuttingPlaneLine = "{7C6F65F1-A02D-4c3c-8063-8F54B59B34E3}";
        public const string CATID_SEBrokenOutSectionProfile = "{534CAB66-8089-4e18-8FC4-6FA5A957E445}";
        public const string CATID_SEFrame = "{D84119E8-F844-4823-B3A0-D4F31793028A}";
        public const string CATID_2dModel = "{F6031120-7D99-48a7-95FC-EEE8038D7996}";
        public const string CATID_EditBlockView = "{892A1CDA-12AE-4619-BB69-C5156C929832}";
        public const string CATID_SEComponentSketchInPart = "{FAB8DC23-00F4-4872-8662-18DD013F2095}";
        public const string CATID_SEComponentSketchInAsm = "{86D925FB-66ED-40d2-AA3D-D04E74838141}";
        public const string CATID_SEHarness = "{5337A0AB-23ED-4261-A238-00E2070406FC}";
        public const string CATID_SEAll = "{C484ED57-DBB6-4a83-BEDB-C08600AF07BF}";
        public const string CATID_SEAllDocumentEnvrionments = "{BAD41B8D-18FF-42c9-9611-8A00E6921AE8}";
        public const string CATID_SEDMPart = "{D9B0BB85-3A6C-4086-A0BB-88A1AAD57A58}";
        public const string CATID_SEDMSheetMetal = "{9CBF2809-FF80-4dbc-98F2-B82DABF3530F}";
        public const string CATID_SEDMAssembly = "{2C3C2A72-3A4A-471d-98B5-E3A8CFA4A2BF}";

        public static readonly Guid SolidEdgeAddIn = new Guid(CATID_SolidEdgeAddIn);
        public static readonly Guid SEApplication = new Guid(CATID_SEApplication);
        public static readonly Guid SEAssembly = new Guid(CATID_SEAssembly);
        public static readonly Guid SEMotion = new Guid(CATID_SEMotion);
        public static readonly Guid SEPart = new Guid(CATID_SEPart);
        public static readonly Guid SEProfile = new Guid(CATID_SEProfile);
        public static readonly Guid SEFeatureRecognition = new Guid(CATID_SEFeatureRecognition);
        public static readonly Guid SESheetMetal = new Guid(CATID_SESheetMetal);
        public static readonly Guid SEDraft = new Guid(CATID_SEDraft);
        public static readonly Guid SEWeldment = new Guid(CATID_SEWeldment);
        public static readonly Guid SEXpresRoute = new Guid(CATID_SEXpresRoute);
        public static readonly Guid SEExplode = new Guid(CATID_SEExplode);
        public static readonly Guid SESimplify = new Guid(CATID_SESimplify);
        public static readonly Guid SEStudio = new Guid(CATID_SEStudio);
        public static readonly Guid SELayout = new Guid(CATID_SELayout);
        public static readonly Guid SESketch = new Guid(CATID_SESketch);
        public static readonly Guid SEProfileHole = new Guid(CATID_SEProfileHole);
        public static readonly Guid SEProfilePattern = new Guid(CATID_SEProfilePattern);
        public static readonly Guid SEProfileRevolved = new Guid(CATID_SEProfileRevolved);
        public static readonly Guid SEDrawingViewEdit = new Guid(CATID_SEDrawingViewEdit);
        public static readonly Guid SERefAxis = new Guid(CATID_SERefAxis);
        public static readonly Guid SECuttingPlaneLine = new Guid(CATID_SECuttingPlaneLine);
        public static readonly Guid SEBrokenOutSectionProfile = new Guid(CATID_SEBrokenOutSectionProfile);
        public static readonly Guid SEFrame = new Guid(CATID_SEFrame);
        public static readonly Guid SE2dModel = new Guid(CATID_2dModel);
        public static readonly Guid EditBlockView = new Guid(CATID_EditBlockView);
        public static readonly Guid SEComponentSketchInPart = new Guid(CATID_SEComponentSketchInPart);
        public static readonly Guid SEComponentSketchInAsm = new Guid(CATID_SEComponentSketchInAsm);
        public static readonly Guid SEHarness = new Guid(CATID_SEHarness);
        public static readonly Guid SEAll = new Guid(CATID_SEAll);
        public static readonly Guid SEAllDocumentEnvrionments = new Guid(CATID_SEAllDocumentEnvrionments);
        public static readonly Guid SEDMPart = new Guid(CATID_SEDMPart);
        public static readonly Guid SEDMSheetMetal = new Guid(CATID_SEDMSheetMetal);
        public static readonly Guid SEDMAssembly = new Guid(CATID_SEDMAssembly);
    }
}
