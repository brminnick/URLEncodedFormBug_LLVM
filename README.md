# URLEncodedFormBug_LLVM

## Reproduction Steps

### Failing/Non-Working Example

1. In the RefitLLVM solution folder, delete all `bin` folders and `obj` folders. I recommend using [this tool to clean the bin & obj folders](https://twitter.com/TheCodeTraveler/status/943920319919636481).
	  - Delete `RefitLLVM\bin`
	  - Delete `RefitLLVM\obj`
	  - Delete `RefitLLVM.iOS\bin`
	  - Delete `RefitLLVM.iOS\obj`  

2. Open the current [`Xamarin Preview` channel](https://user-images.githubusercontent.com/13558917/54733053-9f180b80-4b54-11e9-9768-9595742d34cc.png) of Visual Studio for Mac 2019 Preview as of 21 March 2019 @ 1530 UTC. 
  	- [Environment Information Below](#environment)

3. Open RefitLLVMRepro.sln 

4. Set the Build Confguration to ReleaseLLVM | iPhone

5. Build Deploy app to an iOS device 
  - Note: I am using an iPhone XS Max running iOS 12.1.4

6. Tap the `Submit with Refit` Button

7. Confirm `Failed` Popup 

8. Tap the `Submit without Refit` Button

9. Confirm `Failed` Popup


### Successful/Working Example

1. In the RefitLLVM solution folder, delete all `bin` folders and `obj` folders. I recommend using [this tool to clean the bin & obj folders](https://twitter.com/TheCodeTraveler/status/943920319919636481).
	  - Delete `RefitLLVM\bin`
	  - Delete `RefitLLVM\obj`
	  - Delete `RefitLLVM.iOS\bin`
	  - Delete `RefitLLVM.iOS\obj`  


2. Open the current [`Xamarin Preview` channel](https://user-images.githubusercontent.com/13558917/54733053-9f180b80-4b54-11e9-9768-9595742d34cc.png) of Visual Studio for Mac 2019 Preview as of 21 March 2019 @ 1530 UTC. 
  	- [Environment Information Below](#environment)

3. Open RefitLLVMRepro.sln 

4. Set the Build Confguration to Release | iPhone

5. Build Deploy app to an iOS device 
  - Note: I am using an iPhone XS Max running iOS 12.1.4

6. Tap the `Submit with Refit` Button

7. Confirm `Success` Popup 

8. Tap the `Submit without Refit` Button

9. Confirm `Success` Popup

## Environment

=== Visual Studio Enterprise 2019 Preview for Mac ===

Version 8.0 Preview (8.0 build 2931)
Installation UUID: 1bb450c4-ab99-4090-a394-376e50e3970f
	GTK+ 2.24.23 (Raleigh theme)
	Xamarin.Mac 5.6.0.2 (d16-0 / 040682909)

	Package version: 518010003

=== Mono Framework MDK ===

Runtime:
	Mono 5.18.1.3 (2018-08/fdb26b0a445) (64-bit)
	Package version: 518010003

=== NuGet ===

Version: 4.8.2.5835

=== .NET Core ===

Runtime: /usr/local/share/dotnet/dotnet
Runtime Versions:
	3.0.0-preview3-27503-5
	3.0.0-preview-27324-5
	3.0.0-preview-27122-01
	2.2.0
	2.2.0-preview3-27014-02
	2.1.9
	2.1.8
	2.1.6
	2.1.2
	2.1.1
	2.0.6
	2.0.5
	1.1.10
	1.0.13
SDK: /usr/local/share/dotnet/sdk/3.0.100-preview-010184/Sdks
SDK Versions:
	3.0.100-preview-010184
	3.0.100-preview-010177
	3.0.100-preview-009812
	2.2.100
	2.2.100-preview3-009430
	2.1.505
	2.1.504
	2.1.500
	2.1.302
	2.1.301
	2.1.101
	2.1.4
	1.1.11
MSBuild SDKs: /Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/msbuild/15.0/bin/Sdks

=== Xamarin.Profiler ===

Version: 1.6.9
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

=== Updater ===

Version: 11

=== Apple Developer Tools ===

Xcode 10.1 (14460.46)
Build 10B61

=== Xamarin.Mac ===

Version: 5.6.0.25 (Visual Studio Enterprise)
Hash: 50f75273
Branch: d16-0
Build date: 2019-03-05 11:50:33-0800

=== Xamarin.iOS ===

Version: 12.6.0.25 (Visual Studio Enterprise)
Hash: 50f75273
Branch: d16-0
Build date: 2019-03-05 11:50:33-0800

=== Xamarin Designer ===

Version: 4.17.4.407
Hash: 2897b5f8c
Branch: remotes/origin/d16-0
Build date: 2019-03-15 18:29:24 UTC

=== Xamarin.Android ===

Version: 9.2.0.5 (Visual Studio Enterprise)
Android SDK: /Users/bramin/Library/Android/sdk
	Supported Android versions:
		6.0 (API level 23)
		7.0 (API level 24)
		7.1 (API level 25)
		8.0 (API level 26)
		8.1 (API level 27)

SDK Tools Version: 26.1.1
SDK Platform Tools Version: 28.0.2
SDK Build Tools Version: 28.0.3

Build Information: 
Mono: mono/mono/2018-08-rc@5ad371dab1b
Java.Interop: xamarin/java.interop/d16-0@c987483
LibZipSharp: grendello/LibZipSharp/master@44de300
LibZip: nih-at/libzip/rel-1-5-1@b95cf3f
MXE: xamarin/mxe/xamarin@b9cbb535
ProGuard: xamarin/proguard/master@905836d
SQLite: xamarin/sqlite/3.26.0@325e91a
Xamarin.Android Tools: xamarin/xamarin-android-tools/d16-0@0a7edd6

=== Microsoft Mobile OpenJDK ===

Java SDK: /Users/bramin/Library/Developer/Xamarin/jdk/microsoft_dist_openjdk_8.0.25
1.8.0-25
Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

=== Android Device Manager ===

Version: 1.2.0.14
Hash: 86df26f
Branch: remotes/origin/d16-0
Build date: 2019-03-15 21:58:58 UTC

=== Xamarin Inspector ===

Version: 1.4.3
Hash: db27525
Branch: 1.4-release
Build date: Mon, 09 Jul 2018 21:20:18 GMT
Client compatibility: 1

=== Build Information ===

Release ID: 800002931
Git revision: 36acb974fd4576544398d2eba261d6416b309fa6
Build date: 2019-03-19 01:19:42+00
Build branch: master
Xamarin extensions: 4fb9d9fd52d8b071a61f6062d07b60c54e1c5af3

=== Operating System ===

Mac OS X 10.14.3
Darwin 18.2.0 Darwin Kernel Version 18.2.0
    Thu Dec 20 20:46:53 PST 2018
    root:xnu-4903.241.1~1/RELEASE_X86_64 x86_64

