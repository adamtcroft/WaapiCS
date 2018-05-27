# WaapiCS
*WaapiCS* is a C# abstraction layer (or "wrapper") for Audiokinetic Wwise's WAAPI.
It is intended to make WAAPI tremendously easier to use in C# by removing the difficulties of WAMP and JSON from the end user.

*WaapiCS* is made available to you under the MIT License.  This means it is free, open source, customizable, and available for commercial use/distribution.

The only legal requirement is that you provide attribution (give me credit) in your game.

## Prerequisites
To use WaapiCS, you must have at least a beginner's knowledge of C#.

WaapiCS was written using Visual Studio Community 2017.  You can use it with other programming environments, but it (and the example code) work best with Visual Studio 2017.

## "Installing" WaapiCS
To "install" and use WaapiCS, download the repository using the big green "Clone or Download" button in the upper right hand corner.

Once the repository is on your machine, create a new project using Visual Studio 2017.

On the menu bar, then go to *_Project > Add Reference..._* then click the *_Browse..._* button in the lower right corner of the window that pops up.

Navigate to the directory where you saved WaapiCS and go to *_WaapiCS\bin\Release_* and add *WaapiCS.dll*

Then you can begin using WaapiCS in your code!

## Using WaapiCS
The vast majority of WaapiCS's user-facing layer is made of "static calls" - meaning you don't create any objects like you normally would in C#.  A few commands stray from this convention, but not many.

I made a very large attempt to document the code (documentation comes with the respository download), and make the code itself mimic Wwise's Authoring API itself.

For example, in WAAPI a call exists for `ak.wwise.core.getInfo`, but you must write a lot of additional code to make it work.  In WaapiCS, this is simplified to `Dictionary<string,object> results = ak.wwise.core.GetInfo();`

Please refer to the included API documentation for how to use WaapiCS.  Where custom Wwise objects are referenced (such as object types or properties) you will need to refer to the original [Wwise Authoring API reference](https://www.audiokinetic.com/library/edge/?source=SDK&id=waapi__index.html).