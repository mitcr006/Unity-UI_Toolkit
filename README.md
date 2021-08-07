# Unity-UI_Toolkit
This toolkit is very much a work in progress and will evolve over time.

**Modal Menus**
A modal window creates a mode that disables the main window but keeps it visible.

UI Toolkit -> Modal Window -> Create New Window - This option allows you to create a new scriptable object under Resources/UI_Toolkit/Modal_Windows. you can pass as much or as little information you feel the window needs and the menu will dynamically expand and adjust to the options given.
For example passing only the confirm button text will disable the other 2 buttons upon creation. not passing an image will disable that part of the window etc.

UI Toolkit -> Modal Window -> Create Custom Color Pallet - This options allow a custom color pallet to be used when creating modal menus if this scriptable object is not present in Resources/UI_Toolkit/Color_Pallets it will default to a pre-defined pallet.

Model_Creator.cs - This is an example implementation of how you can go about generation one of these menus. Place it on any object in your scene, refrencing the UI transform and the Modal Window scriptable object and passed in.

All 3 buttons on the modal window have Events you can subscribe to at any point, by passing them through the function ModalWindowObjectNode.CreateModalWindowObject()

Please feel free to create some feature requests.

This is a simple UI Toolkit that lets you create consistent UI quickly and easily.
