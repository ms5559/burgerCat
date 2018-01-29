Spherical Grid Builder
**********************

HowTo
-----
1. Attach Scripts/SphereGridBuilder to your gameobject
You can use any Gameobject you want. Just keep in mind the grid will be spherical around the transform position of your gameobject.

2. Build a Grid-Prefab
This Prefab should represent one grid and should have a decent scale.

3. Supply the parameters for gridbuilder script
In the Inspector you can now refer your prefab and play around with the parameters to match desired result.

Parameters
----------
> Obj Prefab		Your Gameprefab (grid object)
> Points		Amount of gridobjects to be placed
> Size			Distance from the center to the grid, for spheric game objects it's half the scale + your desired offset.
> Sphere as Parent	Instantiated Grid objects become a child of your gameobject
> Rotations		Depending on your prefab you need to rotate it a bit to face either outwards, inwards or the way you want.

Spheregridbuilder will build the Grid at Start().
You can additionally call the public methods:
> rebuildGrid
> buildGrid
> destroyGrid

The demo scene contains a complete scene to showcase the script with a few preset variations.