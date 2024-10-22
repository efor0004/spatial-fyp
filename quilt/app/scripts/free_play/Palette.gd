extends Area2D

var display_state = "all_levels"
var level_to_display = 0

onready var back_button = get_node("Back Button")

const DraggableSquare = preload("./DraggableSquare.gd")

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

func _ready():
	render()

func on_option_down(index, event_position):
	if (display_state == "single_level"):
		var new_square = DraggableSquare.new(level_to_display, index, event_position)
		get_parent().add_child(new_square)

func on_option_up(index):
	if (display_state == "all_levels"):
		level_to_display = index
		display_state = "single_level"
		render()

func back():
	if (display_state == "single_level"):
		display_state = "all_levels"
		level_to_display = 0
	
	render()

func render():
	for i in range(1, constants.max_levels + 1):
		var option = get_node(str(i))
		var fabric = option.get_node("Fabric")
		
		var texture_path = "res://assets/sprites/fabrics/level_%d/fabric_1.jpg" % i
		var option_disabled = get_is_option_disabled(i)
		
		if (display_state == "single_level"):
			texture_path = "res://assets/sprites/fabrics/level_%d/fabric_%d.jpg" % [level_to_display, i]
		
		var fabric_texture = load(texture_path)
		fabric.set_texture(fabric_texture)
		
		if (option_disabled == true):
			fabric.self_modulate = Color(1, 1, 1, 0.3)
		else:
			fabric.self_modulate = Color(1, 1, 1, 1)
	
	if (display_state == "all_levels"):
		back_button.visible = false
	else:
		back_button.visible = true

func get_is_option_disabled(index):
	if (display_state == "all_levels"):
		if (global.current_question == 1):
			return index >= global.current_level
		else:
			return index > global.current_level
	else:
		if (level_to_display < global.current_level):
			return false
		else:
			return index >= global.current_question
