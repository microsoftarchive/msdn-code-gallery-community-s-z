#include "StdAfx.h"
#include "JumpList.h"


// Creates a CLSID_ShellLink to insert into the Tasks section of the Jump List.  This type of Jump
// List item allows the specification of an explicit command line to execute the task.
HRESULT _CreateShellLink(PCWSTR pszArguments, PCWSTR pszTitle, IShellLink **ppsl)
{
    IShellLink *psl;
    HRESULT hr = CoCreateInstance(CLSID_ShellLink, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&psl));
    if (SUCCEEDED(hr))
    {
        // Determine our executable's file path so the task will execute this application
        WCHAR szAppPath[MAX_PATH];
        if (GetModuleFileName(NULL, szAppPath, ARRAYSIZE(szAppPath)))
        {
            hr = psl->SetPath(szAppPath);
            if (SUCCEEDED(hr))
            {
                hr = psl->SetArguments(pszArguments);
                if (SUCCEEDED(hr))
                {
                    // The title property is required on Jump List items provided as an IShellLink
                    // instance.  This value is used as the display name in the Jump List.
                    IPropertyStore *pps;
                    hr = psl->QueryInterface(IID_PPV_ARGS(&pps));
                    if (SUCCEEDED(hr))
                    {
                        PROPVARIANT propvar;
                        hr = InitPropVariantFromString(pszTitle, &propvar);
                        if (SUCCEEDED(hr))
                        {
                            hr = pps->SetValue(PKEY_Title, propvar);
                            if (SUCCEEDED(hr))
                            {
                                hr = pps->Commit();
                                if (SUCCEEDED(hr))
                                {
                                    hr = psl->QueryInterface(IID_PPV_ARGS(ppsl));
                                }
                            }
                            PropVariantClear(&propvar);
                        }
                        pps->Release();
                    }
                }
            }
        }
        else
        {
            hr = HRESULT_FROM_WIN32(GetLastError());
        }
        psl->Release();
    }
    return hr;
}

// The Tasks category of Jump Lists supports separator items.  These are simply IShellLink instances
// that have the PKEY_AppUserModel_IsDestListSeparator property set to TRUE.  All other values are
// ignored when this property is set.
HRESULT _CreateSeparatorLink(IShellLink **ppsl)
{
    IPropertyStore *pps;
    HRESULT hr = CoCreateInstance(CLSID_ShellLink, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pps));
    if (SUCCEEDED(hr))
    {
        PROPVARIANT propvar;
        hr = InitPropVariantFromBoolean(TRUE, &propvar);
        if (SUCCEEDED(hr))
        {
            hr = pps->SetValue(PKEY_AppUserModel_IsDestListSeparator, propvar);
            if (SUCCEEDED(hr))
            {
                hr = pps->Commit();
                if (SUCCEEDED(hr))
                {
                    hr = pps->QueryInterface(IID_PPV_ARGS(ppsl));
                }
            }
            PropVariantClear(&propvar);
        }
        pps->Release();
    }
    return hr;
}

// Adds a custom category to the Jump List.  Each item that should be in the category is added to
// an ordered collection, and then the category is appended to the Jump List as a whole.
HRESULT _AddCategoryToList(ICustomDestinationList *pcdl, IObjectArray *poaRemoved)
{
    IObjectCollection *poc;
    HRESULT hr = CoCreateInstance(CLSID_EnumerableObjectCollection, NULL, CLSCTX_INPROC, IID_PPV_ARGS(&poc));
    if (SUCCEEDED(hr))
    {
        IShellLink * psl;
        hr = _CreateShellLink(L"Online", L"Online", &psl);
        if (SUCCEEDED(hr))
        {
            hr = poc->AddObject(psl);
            psl->Release();
        }

        if (SUCCEEDED(hr))
        {
            hr = _CreateShellLink(L"Away", L"Away", &psl);
            if (SUCCEEDED(hr))
            {
                hr = poc->AddObject(psl);
                psl->Release();
            }
        }

		if (SUCCEEDED(hr))
        {
            hr = _CreateShellLink(L"Busy", L"Busy", &psl);
            if (SUCCEEDED(hr))
            {
                hr = poc->AddObject(psl);
                psl->Release();
            }
        }

        if (SUCCEEDED(hr))
        {
            IObjectArray * poa;
            hr = poc->QueryInterface(IID_PPV_ARGS(&poa));
            if (SUCCEEDED(hr))
            {
                // Add the category to the Jump List.  If there were more categories, they would appear
				// from top to bottom in the order they were appended.
				hr = pcdl->AppendCategory(L"Custom Category", poa);
                poa->Release();
            }
        }
        poc->Release();
    }
    return hr;
}

// Adds a custom category to the Jump List.  Each item that should be in the category is added to
// an ordered collection, and then the category is appended to the Jump List as a whole.

// Builds a new custom Jump List for this application.
void CreateJumpList()
{
    // Create the custom Jump List object.
    ICustomDestinationList *pcdl;
    HRESULT hr = CoCreateInstance(CLSID_DestinationList, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pcdl));
    if (SUCCEEDED(hr))
    {
        // Custom Jump Lists follow a push model - applications are responsible for providing an updated
        // list anytime the contents should be changed.  Lists are generated in a list-building
        // transaction that starts by calling BeginList.  Until the list is committed, Windows will
        // display the previous version of the list, if available.
        //
        // The cMinSlots out parameter indicates the minimum number of items that the Jump List UI is
        // guaranteed to display.  Applications can provide more items when building a custom Jump List,
        // but the extra items may not be displayed.  The number is dependant upon a number of factors,
        // such as screen resolution and the "Number of recent items to display in Jump Lists" user setting.
        // See the MSDN documentation on BeginList for more information.
        //
        // The IObjectArray returned from BeginList contains a list of items the user has chosen to remove
        // from their Jump List.  Applications must respect the user's removal of an item and not re-add any
        // item in the removed list during this list-building transaction.  Applications should also clear any
        // persited usage-tracking data for any item in the removed list.  If the user begins using a
        // previously removed item in the future, it may be re-added to the list.
        UINT cMinSlots;
		IObjectArray *poaRemoved;
        hr = pcdl->BeginList(&cMinSlots, IID_PPV_ARGS(&poaRemoved));
        if (SUCCEEDED(hr))
        {
            // Add content to the Jump List.
            hr = _AddCategoryToList(pcdl, poaRemoved);
            if (SUCCEEDED(hr))
            {
                // Commit the list-building transaction.
                hr = pcdl->CommitList();
            }
            poaRemoved->Release();
        }
        pcdl->Release();
    }
}

