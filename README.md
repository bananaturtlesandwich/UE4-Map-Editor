# UE4-Map-Editor
__A very WIP Universal Editor for UE4 map files - *expect major jank*__

# Building from source
- clone the repository
- run update submodules.bat to update the dependencies
- open the solution and migrate GL_EditorFramework's packages if there are issues
- build and it should work👍

# Libraries used
- [atenfyr's](https://github.com/atenfyr) [UAssetAPI](https://github.com/atenfyr/UAssetAPI) for the reading and writing of umap files. This includes parsing of exports + editing and adding of PropertyData in each export + even more! This API is extremely extensive so big thanks atenfyr😊
- [jupahe64's](https://github.com/jupahe64) [GL_EditorFramework](https://github.com/jupahe64/GL_EditorFramework) for the base of the editor. This includes the extensible and customisable 3D interface, scene list and property controls. Without this I would have to create these things from scratch which would likely be far less efficient and worse as I am not experienced so thank you jupahe64 😊
