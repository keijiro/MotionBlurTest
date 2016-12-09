MotionBlurTest
==============

This is an example project that was made for testing the Motion Blur component in the
[Post-Processing Stack](https://github.com/Unity-Technologies/PostProcessing).

![gif](http://i.imgur.com/a7HHC8w.gif) ![gif](http://i.imgur.com/XQcHOAg.gif)

Difference From the Release Version
-----------------------------------

The Motion Blur component in this project is slightly different from the official
release version -- it has an extra property named *Window Shape* in the post-processing
profile. This property can be used to tweak the temporal window kernel from triangle
(0.0) to trapezoid (0.0~1.0) or rectangle (1.0).
