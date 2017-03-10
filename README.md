# a'la carte
IIS web sites and applicaitons catalog

A'la Carte displays web sites and applications hosted on an IIS server. It can be helpful in testing environments where Continuous Deployment is practiced for every VCS branch.

## Setup
Accessing IIS configuration requires elevated priviledges in Windows. A'la carte needs to be ran as administrator. Under the hood, the software uses Topshelf so it can run as either console app or a windows service.
In order to expose a'la carte outside of localhost it's best to configure a reverse proxy on IIS. Sample proxy config using URL rewriting can be fond in iis_config direcotry.
