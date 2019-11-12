//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controllers
{
    using System.Windows.Navigation;

    class NavigationControllerBase
    {
        protected NavigationService NavigationService
        {
            get;
            private set;
        }

        public void SetNavigationService(NavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public void GoBack()
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
