# FilterModule
Http Filter Module (IIS) - Allows easy filtering (security) of web requests for a specified domain/site/application

Implementation

1.Add the compiled DLL (FilterModule.dll) to the Web Service (site) bin Directory.


2.Add the following to module definition in the Web Service (or site) configuration file (web.config) 


in the <system.webServer> section under <modules>
 add the following:
<add name ="FilterModule" type="FilterModule.AuthorizeLocal" />
