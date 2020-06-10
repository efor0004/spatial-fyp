extends Sprite

var current_level = 1
var current_question = 1
var current_shuffled_question = 1
onready var current_fabric = get_current_fabric()

var quilt_size = 384
var initial_texture_y = 3650
var initial_quilt_texture_offset = Vector2(576, initial_texture_y)
var initial_options_texture_offset = [Vector2(192, initial_texture_y), Vector2(-192, initial_texture_y), Vector2(-576, initial_texture_y)]

var questions_per_level = 2
var questions_available_per_level = 20

var question_order = []
var option_positions = [Vector2(821, 768), Vector2(1256, 768), Vector2(1721, 768)]

var max_levels = 2

const GeneralUtils = preload("utilities/general.gd")
onready var general_utils = GeneralUtils.new()

onready var progress_quilt = get_parent().get_node("Progress Quilt")

signal piece_added
signal set_next_question

func _ready():
	shuffle_question_order()
	set_shapes()

func next_question():
	add_quilt_piece()
	yield(self, "piece_added")
	
	reset_option_positions()
	
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
		
		if (current_level > max_levels):
			current_level = 1
			current_question = 1
		
		set_textures_for_level()
		shuffle_question_order()
	
	set_shapes()
	set_question_fabric()
	emit_signal("set_next_question")

func shuffle_question_order():
	var shuffled_questions = general_utils.shuffle_list(range(1, questions_available_per_level + 1))
	question_order = shuffled_questions.slice(0, questions_per_level + 1)

func set_textures_for_level():
	var path = get_level_path()
	var level_texture = load(path)
	
	var holey_quilt = get_holey_quilt_shape()
	holey_quilt.set_texture(level_texture)
	
	for i in range(1,4):
		var option_shape = get_option_shape(i)
		option_shape.set_texture(level_texture)

func set_shapes():
	current_shuffled_question = question_order[current_question - 1]
	
	set_holey_quilt_shape()
	set_options_shapes()

func get_level_path():
	return "res://assets/sprites/questions/level_%d.png" % current_level

func get_holey_quilt():
	var holey_quilt = get_node("Layer1/HoleyQuilt")
	return holey_quilt

func get_holey_quilt_fabric():
	var holey_quilt_fabric = get_node("Layer1/HoleyQuilt/Fabric Texture")
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt_shape = get_node("Layer1/HoleyQuilt/Light2D")
	return holey_quilt_shape

func get_new_y_offset(y_offset):
	var new_y_offset = y_offset - (quilt_size * (current_shuffled_question - 1))
	return new_y_offset

func set_holey_quilt_shape():
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var x_offset = initial_quilt_texture_offset.x
	var y_offset = initial_quilt_texture_offset.y
	
	var new_y_offset = get_new_y_offset(y_offset)
	
	holey_quilt_shape.offset = Vector2(x_offset, new_y_offset)

func set_options_shapes():
	var indices = range(1,4)
	var random_indices = general_utils.shuffle_list(indices)
	for i in indices:
		var option_mask = get_option_shape(i)
		var shape_no = random_indices[i - 1]
		
		var offset = initial_options_texture_offset[shape_no - 1]
		var x_offset = offset.x
		var y_offset = offset.y
		
		var new_y_offset = get_new_y_offset(y_offset)
		option_mask.offset = Vector2(x_offset, new_y_offset)

func get_option_shape(i):
	var node_path = "AnimationPlayer%d/Layer%d/Option %d/Light2D" % [i, i+1, i]
	var option_mask = get_node(node_path)
	return option_mask

func set_question_fabric():
	current_fabric = get_current_fabric()
	var fabric = load(current_fabric)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d/Fabric Texture" % [i, i+1, i]
		var option_fabric = get_node(node_path)
		option_fabric.set_texture(fabric)

func get_current_fabric():
	var fabric_path = "res://assets/sprites/fabrics/level_%d/fabric_%d.jpg" % [current_level, current_question]
	return fabric_path

func reset_option_positions():
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = true
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = true
		option.transform.origin = option_positions[i - 1]

func add_quilt_piece():
	
	progress_quilt.add_quilt_piece(current_fabric)
	
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = false
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = false
	
	progress_quilt.animate_quilt_piece(current_question)
	yield(progress_quilt, "done_animating")
	emit_signal("piece_added")
