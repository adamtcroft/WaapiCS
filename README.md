# WaapiCS
**WaapiCS** is a C# abstraction layer (or "wrapper") for Audiokinetic Wwise's WAAPI.
It is intended to make WAAPI tremendously easier to use in C# by removing the difficulties of WAMP and JSON from the end user.

**WaapiCS** is made available to you under the MIT License.  This means it is free, open source, customizable, and available for commercial use/distribution.

The only legal requirement is that you provide attribution (give me credit) in your game.

**Please note that WaapiCS is still under active development.
Known issues (such as calls not working) can be found under the "Issues" tab.**

Code samples can be found within the solution under **Sample Project**

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

In some places you will need to use specific Wwise-related custom values.  These can be found under the `WwiseValues` class, if available, by including `using WaapiCS.CustomValues;` at the top of your code.

## For Programmers
WaapiCS is built in two layers - WaapiCS and WaapiCS.Communication.

WaapiCS.Communication is the "lower" layer code, intended to communicate directly with Wwise via a packet system.  WaapiCS.Communication houses a "packet" object, which is then passed to Wwise in JSON form, returned back, and deserialized back into C#.

WaapiCS is the "higher" user-facing layer intended to make code writing easier for audio implementers and technical sound designers.  In many cases, it will _not_ be ideal for your studio to use this layer in its current state.  Some of you will want to build custom objects to reflect the Wwwise hierarchy, for example.

I have intentionally separated WaapiCS.Communication and WaapiCS layers so that you can easily customize or completely re-write the user facing layer without causing issues with the layer which directly communicates with Wwise.

Please feel free to make this your own, and contact me with any requests, suggestions, or updates.

## If You Have Trouble
If you need additional assistance, please get in touch with me via email - me@adamtcroft.com
