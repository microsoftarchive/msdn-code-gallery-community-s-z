Imports System.Data.Entity
Imports MvcMovie


Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Movies", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        'System.Data.Entity.Database.SetInitializer(Of MovieDBContext)(New MvcMovie.Models.MovieInitializer())
        Database.SetInitializer(Of MovieDBContext)(New MvcMovie.Models.MovieInitializer())
        'Database.SetInitializer(Of MovieDBContext)(New MovieInitializer())
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
