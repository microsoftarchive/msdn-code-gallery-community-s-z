rd /q /s TestResults
rd /q /s AspNetCachingDemo\bin
rd /q /s AspNetCachingDemo\obj
rd /q /s ConfigOnlyInjection\bin
rd /q /s EFCachingProvider\bin
rd /q /s EFCachingProvider.Web\bin
rd /q /s EFCachingProvider.Tests\bin
rd /q /s EFProviderWrapperDemo\bin
rd /q /s EFProviderWrapperToolkit\bin
rd /q /s EFTracingProvider\bin
rd /q /s ConfigOnlyInjection\obj
rd /q /s EFCachingProvider\obj
rd /q /s EFCachingProvider.Web\obj
rd /q /s EFCachingProvider.Tests\obj
rd /q /s EFProviderWrapperDemo\obj
rd /q /s EFProviderWrapperToolkit\obj
rd /q /s EFTracingProvider\obj
attrib -r -h EFProviderWrappers.suo
del EFProviderWrappers.suo
del EFProviderWrappers.sln.cache
del AspNetCachingDemo\sqllog.txt

