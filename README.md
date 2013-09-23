JQueryDataTableSerializer
=========================

C# library for the serialization of the popular JQuery DataTables Plugin

A while back I had to look at this problem while at work, and now I'd like to take a fresh look at how to handle this situtation. 

A while back I wrote about it here:

http://cubedelement.com/Media/News/jQuery-DataTables-and-WCF-REST-4-0

It was based off of the popular plug in:

http://datatables.net/release-datatables/examples/server_side/post.html

I've seen a lot of different approaches, and I thought I'd take the time to work on an updated one. The purpose here is to have these values translate into an object collection, that helps with things like wcf and long url query strings.
