# City generator

## Introduction
This project aims to recreate a city layout similar to the city of Barcelona. Users can generate a randomised city model through a one-click functionality. From there, they can individually adjust the height of buildings, delete them, and replace their models with others (for now, they're just basic shapes).

## Code
The project comprises three scripts: CitySpawner, CameraMovement, and BuildingManager.

The CitySpawner script is responsible for creating and placing the blocks of buildings that make up the city. The script creates a grid of blocks, each consisting of several buildings of random height. The width and height of the grid, as well as the size of the individual buildings, can be set through public variables in the script. The script also includes a function to delete all the buildings in the grid and regenerate the grid.

The CameraMovement script allows the player to move the camera using the arrow keys and zoom in and out using the mouse wheel. The speed of movement and zooming can be set through public variables of the script.

The BuildingManager script is responsible for allowing the player to interact with the buildings in the city. This script includes various tools, such as increasing and decreasing the height of a building, replacing a building with a different shape, and destroying a building. The maximum and minimum sizes of the buildings and the tag used to identify them can be set through public variables in the script.

This project provides a simple but functional city-building tool. The usage of public variables and UI buttons make the game easy to customise and extend. This project could be expanded into a more robust city-building game with additional features, such as the ability to place roads and other city infrastructure.

## Known bugs
If you replace a building's default prefab with another primitive shape, this new shape will fail to scale up and down correctly. I added this feature last and needed more time to investigate it. In addition to that bug, clicking buttons misbehaves if buildings are beneath the mouse. The mouse click ray cast first checks the collision with a building before checking the collision with the UI button. These are the first things I'd focus on if I had more time. Also, I would thoroughly test the features developed so far to ensure I have a solid foundation before I continue to develop the project further.

## Future lines
I would add the ability to move and rotate objects around, considering the collisions between buildings this could cause.

I would also implement a feature that allows the addition of different city components, such as fountains, trees and roads. The user would have the choice to pick between these from a dropdown menu.

These two features alone help broaden this project's scope to allow the development of more intricate cities.