//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controllers
{
    using Microsoft.Workflow.Explorer.ViewModels;
    using Microsoft.Workflow.Explorer.Views;

    class ActivitiesNavigationController : NavigationControllerBase
    {
        static ActivitiesNavigationController defaultInstance;

        // callers are expected to use the default static instance
        ActivitiesNavigationController()
        {
        }

        public static ActivitiesNavigationController Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ActivitiesNavigationController();
                }

                return defaultInstance;
            }
        }

        public void NavigateToActivityXamlPage(ActivityViewModel activityViewModel)
        {
            this.NavigationService.Navigate(new ActivityXamlPage());
        }
    }
}
