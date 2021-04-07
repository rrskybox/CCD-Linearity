# CCD-Linearity
Astro-Imaging CCD Linearity Analytic using TheSkyX

CCD Linearity is a camera characterization program that charts the variation of flux per exposure-second accumulated by a camera with respect to time of exposure.  This information is necessary to set optimal flat-field exposure times as they must be exposed within the linearity range of a CCD, but the closer to saturation, the bette

This tool provides two functions:  

1. “Pick Star”: Finding and slewing the mount to a target star of selected magnitude and near the zenith.  This command used in conjunction with the “Magnitude” value.  The program will assess the selected star’s brightness and recommend a new selection if appropriate.  “Pick Star” is optional if the telescope is already positioned on such a target star.  

2) “Run Test”:  Imaging the star and its immediate vicinity (i.e. subframe) at a series of exposure times while averaging the maximum ADU and overall ADU.  The number of values to be average is set by the “samples/exposure” value. The results are graphed sequentially. 

Starting at a value less than 10K, as the maximum pixel value increases, a CCD graph will show a gradual decrease of Total ADU per second of exposure when it is within the linear range of the CCD.  As anti-blooming activates, this flux per second of exposure will drop off and cease to increase much with the maximum ADU – inverted hockey stick.  Flat-field frames should be exposed such that pixel values are just below where the flux per second of exposure starts to diminish.  In the above picture, the my STXL 11002 CCD becomes nonlinear at about 36K ADU.  I should set my flat field images for around 34K, then – which I wasn’t.

In setting a star magnitude, the program is looking for a star that produces around 5-10K ADU’s at a one second exposure.  This gives a good starting baseline for the graph.

In setting the samples/exposure, the tradeoff is between the length of time that the linearity profile takes and it’s accuracy.  The greater the number of samples, the less seeing and other unpredictables will affect each the graphed value for each maximum ADU point.  The downside to this accuracy is that the test takes a lot longer.  My experience has been that extra accuracy is unnecessary because a very precise position of the hockey stick elbow is unnecessary.  One will probably set the target ADU for flat fields at a number several thousand ADU’s below the elbow anyway.

Requirements: 

 CCD Linearity is a Windows Forms executable, written in Visual Basic.  The app requires TheSkyX Pro (Build 10229 or later) with the TSX Camera Add On option. The application may also require installation of Microsoft Powerpack 3.0 for charting (can be found at https://www.microsoft.com/en-us/download/details.aspx?id=25169).   The application runs as an uncertified, standalone application under Windows 7, 8 and 10. 
 
Installation:  

CCD Linearity is a One-Click application.  Download the zip file in the "publish" directory, open and run "setup.exe".

Support:  

This application was written for the public domain and as such is unsupported. The developer wishes you his best and hopes everything works out, but recommends learning Visual Basic (it's really not hard and the tools are free from Microsoft) if you find a problem or want to add features.  The source is supplied as a Visual Studio project.

References:

Demystifying Flat Fields, Peter Kalajian, Sky & Telescope Magazine, March 2011
