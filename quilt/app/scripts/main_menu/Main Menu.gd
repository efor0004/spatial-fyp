extends Node2D

var modal_pages = [
	'This is a spatial mobile game app for one player. By playing this game, children learn to recognise shapes, mentally rotate shapes and use spatial language. Mental rotation is an important spatial reasoning skill that helps with everyday tasks such as packing the car, navigating, assembling furniture and is critical in Science, Technology, Engineering, and Mathematics (STEM) occupations. Hearing and speaking spatial language, as well as thinking about spatial concepts, also help children further develop their spatial skills.',
	"""HOW TO PLAY
	
	1) Press the 'PLAY' button
	2) Select an animal from the 6 options
	3) Watch the story or press the fast-forward button to skip
	4) Select the correct shape to complete the quilt square
	5) Complete all the levels to make a quilt for your animal!""",
	"""NOTES TO PARENTS/CAREGIVERS
	Here are some ways you can help and encourage your child(ren) with this app:
	
	1) Sit with them when they are playing
	2) Listen to the story with them and ask how they feel about helping keep the creatures warm
	3) Let them know that the quilt gets made automatically as they are making the squares, but later on, they could choose to use the completed squares to make their own quilt if they wish
	4) When they get it right, congratulate them and ask them how they know the right answer. Encourage them to gesture as appropriate.
	5) If they get it wrong, ask them if they know why it is wrong and what the right answer should be and ask them to try again. Encourage them to gesture as appropriate.
	6) If you are able to, supplement their answers with spatial words such as flip, rotate, slide, smaller, bigger, triangle. Use gestures as you see appropriate.
	7) Encourage your child to arrange their own quilt when they have completed the puzzles
	
	If you and your child(ren) are keen, you could cut out some squares and make up your own “complete the square” puzzles.
	
	If it is safe to do so, let them help when you put together self-assemble furniture. Ask them to find the correct pieces and determine how to place them.
	
	You could try incorporating more spatial language into your everyday conversations with your child(ren). Please refer to the Spatial Reasoning Skills for Preschoolers leaflet for more ideas.
	
	Early and rich exposure to spatial concepts, such as using spatial language, mentally visualising and rotating things, and using gestures, are some of the first steps towards developing good spatial reasoning skills."""
]

var modal_button_path = "res://assets/sprites/modals/buttons/open_button/open_button.png"

func _ready():
	var modal = CustomModal.new(modal_pages, modal_button_path)
	
	add_child(modal)
