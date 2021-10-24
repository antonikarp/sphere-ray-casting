# sphere-ray-casting
This is a visualization of ray-casting in C# using WinForms.

This program utilizes ray-casting to render the scene. A ray is cast through each pixel of the frame.
Its coordinates on a frame (X and Y of a pixel) are transformed into coordinates in the 3D scene.
Each ray is tested for a possible intersection with the spheres. The color of resulting pixel comes from
the sphere which was first to intersect the ray. The color is calculated using Phong reflection model.
Each sphere has a different material coefficients and its resulting color and reflectivity are different.

<img src = "img/01.png">

The program intializes the scene with a few spheres, a point light and a camera.
The user can control both the location of the light source and the camera with keyboard.
Controls:
* `Right Arrow` <br/>
  Turn around Z axis clockwise.
* `Left Arrow` <br/>
  Turn around Z axis counterclockwise.
* `Up Arrow` <br/>
  Turn around Y axis clockwise.
* `Down Arrow` <br/>
  Turn around Y axis counterclockwise.
* `W` <br/>
  Move the light source along X axis forward.
* `S` <br/>
  Move the light source along X axis backward.
* `A` <br/>
  Move the light source along Z axis backward.
* `D` <br/>
  Move the light source along Z axis forward.
* `Z` <br/>
  Move the light source along Y axis forward.
* `X` <br/>
  Move the light source along Y axis backward.
* `Num Key 2` <br/>
  Decrease the distance from the center of the scene.
* `Num Key 8` <br/>
  Increase the distance from the center of the scene.

