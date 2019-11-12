//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace WizardActivityPack.Activities
{
    using System;
    using System.Activities.Presentation.Metadata;
    using System.ComponentModel;
    using WizardActivityPack.Activities.Design;

    


    /// <summary>
    /// Contains metadata for the StateMachine related designers.
    /// </summary>
    public class DesignerMetadata : IRegisterMetadata
    {
        /// <summary>
        /// Registers metadata for the StateMachine related designers.
        /// </summary>
        public void Register()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();


            builder.AddCustomAttributes(typeof(WizardContainer), new DesignerAttribute(typeof(WizardContainerDesigner)));


            


            builder.AddCustomAttributes(typeof(Wizard), new DesignerAttribute(typeof(WizardDesigner)));


            builder.AddCustomAttributes(typeof(Step), new DesignerAttribute(typeof(StepDesigner)));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
