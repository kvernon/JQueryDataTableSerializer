JQueryDataTableSerializer
=========================

C# library for the serialization of the popular JQuery DataTables Plug-in

A while back I had to look at this problem while at work, and now I'd like to take a fresh look at how to handle this situation. 

A while back I wrote about it here:

http://www.cubedelement.com/Media/News/jQuery-DataTables-and-WCF-REST-4-0

It is based off of the popular plug in:

http://datatables.net/release-datatables/examples/server_side/post.html

I've seen a lot of different approaches on working with the datatables server variables (and battled a few), and I thought I'd take the time to work on an updated one. The purpose here is to have these values translate into an object collection, that helps with things like wcf and long url query strings.

Get it at Nuget:
----------------

https://www.nuget.org/packages/JQueryDataTableSerializer/

Example Wcf Rest Project:
-------------------------

There is a demo wcf project here too, WcfServiceDemo.

I'll look to where I can store compiled zips of the library. Currently it's set up for the configuration for Release to compile the Contracts and Models libraries.

To make this project and demo, I've used the following:

NUnit: http://nunit.org/

JSON-JS: https://github.com/douglascrockford/JSON-js

JQuery: http://jquery.com/

Rhino mocks: http://hibernatingrhinos.com/oss/rhino-mocks