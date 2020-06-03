Adding New Puzzles: 

Open Scene "TestBench"
Drag "FrameBackground" Image from "Prefabs" onto screen
Build Image using shapes from "Resources"
- first placed shape/top in heirarchy will be the anchor shape which spawns automatically as a reference
- Set sorting layer from shape1 - shape5 (with shape1 most back to shape5 most forward)
- scale and rotate manually 
- colour using one of the swatches at the bottom of the colour picker
Open "Game" tab and screenshot image of final puzzle (only the white rectangle)
Remove background from image and save with appropriate name: 
PG# = playground
T# = triangle
MS# = mouseshaps
F# = farm
W# = wild
Drag image into "Resources"

Delete "FrameBackground"
run "Testbench"
wait for console to read "Done!"
stop "Testbench"

Open appropriate scene handler scripe i.e. MouseHandler for Mouse scene
copy and paste the latest Puzzle#() function
update puzzle number # in function name 
update number of shapes in the puzzle (highest number of the object name shape# - will be 1 less than number of function calls as exclude anchor shape0)
update commented description
update level and puzzle number (5 puzzles per level, levels start at 1)

open "Test.txt" in Assets > Textfiles
copy function calls at the bottom of file (each test writes underneath the previous) 
paste function calls into Puzzl#() function
update fixed image call to that of the image name e.g. MS#

add puzzle in createlist() at top of handler

test by commenting out CreateList() in start and calling Puzzle#(); 
run the appropriate scene e.g. Mouse