# UnityMouseoverTooltip
Displays a tooltip on mouseover of select UI elements. 

Tooltip scales its size to provided contents, including word wrapping when above a threshold. It will also shift position around the mouse to remain fully on screen.

Uses its own canvas with max sort order to ensure it always renders on top of other elements.

# Usage
- Copy the MouseoverTooltip folder into the Unity Project.
- Add TooltipCanvas.prefab to the scene at the root level.
	- Adjusting the Preferred Width field on the Layout Element of the Background object will set the limit at which word wrapping is enabled. 
- Attach TooltipTrigger.cs to any UI elements that should display a tooltip.
	- Fill TooltipHeaderText and TooltipContentText with tooltip contents.
