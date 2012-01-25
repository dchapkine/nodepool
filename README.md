
nodepool
===

### About

Nodepool is a lightweight and easy to use [nodejs + npm + nodeinspector] distribution for windows 7. Its goal is to speed up development of nodejs applications on windows.

Think of it as the [wamp](http://wampserver.com/en/) or [xampp](http://www.apachefriends.org/fr/xampp.html) distribution but for nodejs local development.

NodePool is NOT a text editor/ide but plays nice with any text editor/ide.





### Quick Access to running instances from systray

![Screenshot](https://github.com/dchapkine/nodepool/raw/master/doc/screen-systray.png "Screenshot")



### One click debug (using nodeinspector)

NOTE: NodeInspector requires Google Chrome to run.

![Screenshot](https://github.com/dchapkine/nodepool/raw/master/doc/screen-debug.png "Screenshot")



### NPM support

![Screenshot](https://github.com/dchapkine/nodepool/raw/master/doc/screen-npm.png "Screenshot")




### Monitor and auto restart on file change (wildcard patterns) or/and on node instance crash.

![Screenshot](https://github.com/dchapkine/nodepool/raw/master/doc/screen-auto-restart.png "Screenshot")



### Use the text editor of your choise

NodePool respects your text editor habits. Just use whatever you like.

![Screenshot](https://github.com/dchapkine/nodepool/raw/master/doc/screen-texteditor.png "Screenshot")



### Auto saving instances and its configuration

NodePool remebers node instances after restart




### Changelog


+ Version 0.1.1 - alpha - 2012.01.25
	+ nodejs updated to 0.6.8 (npm 1.1.0-2 included)
	+ .NET framework required version downgraded to 3.5
	+ automaticly loading available node versions from disk (to add support for new version simply add a folder)
	+ new logo
	+ restart on file change becomes better: you can now enter wildcard patterns of files to watch while creating new instance (ex: myapp/templates/*.mu.html)
	+ examples are now included in %NODEPOOL_DIR%/Examples: hello world, node chat(http://chat.nodejs.org/), ... to help newbees get started :)
	+ node instances are now saved in/loaded from config file
	
						
+ Version 0.1.0 - alpha - 2012.01.07
	+ Better output console ui: Run/Debug/Stop/Restart/ClearConsole/OpenInExplorer buttons
	+ Npm console: Npm commands are directly executed in main js script's folder
	+ One click debug feature with node inspector (experimental)
	+ nodejs updated to 0.6.6 (npm included)
	+ nodeinspector updated to 0.1.10
	+ tested on windows 7 only
	

+ Version 0.0.1 - alpha - 2011.02.17
	+ Initial release
	+ Can add node instances
	+ Node instances can be asked to restart automaticly when source code is updated
	+ Node instances can be asked to restart automatilcy in case of crash
	+ Start/Restart/Stop instances one by one or all in same time from windows systray
	+ Watch standart output od each instance in separate window
	+ nodejs0.4.0 is included

	
	
	
