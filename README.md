# AWParentEditor
## Super Simple Armature Parent Editor I use to transfer meshes to other armatures during my model packaging process. Useful for creating prefabs for specific avatars, *without* shipping the original assets.

Credits to JLJac on [Unity Answer Forums](https://answers.unity.com/questions/1442963/how-to-re-apply-a-mesh-to-an-armature.html) for 90% of the original code, I just adapted it to work in an editor window, and be a bit more user-friendly. 

Current limitations:

- This only works to move a mesh to an armature of the exact same type/layout. If a mesh has vertex groups weighted to bones that do not exist, those verticies will stay in place.
- The script will attempt to move the object under the root of the prefab, but occasionally will put it under the armature if it can't find the right spot.
- Prefabs need to be unpacked on the mesh side.

For a more useful script take a look at [this one](https://github.com/artieficial/ApplyAccessories)
