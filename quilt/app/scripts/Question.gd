extends Sprite

var current_level = 1
var current_question = 1
var current_shuffled_question = 1
var current_fabric = ''

var questions_per_level = 10

var question_order = []
var option_file_text = "option_"

const FileUtils = preload("utilities/files.gd")
onready var file_utils = FileUtils.new()

onready var max_levels = file_utils.get_number_of_levels()

const GeneralUtils = preload("utilities/general.gd")
onready var general_utils = GeneralUtils.new()

onready var progress_quilt = get_parent().get_node("Progress Quilt")

func _ready():
	randomise_question_fabric()
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))
	set_shapes()

func next_question():
	progress_quilt.add_quilt_piece(current_question, current_fabric)
	
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
		shuffle_question_order()
	
	if (current_level > max_levels):
		current_level = 1
		current_question = 1
		shuffle_question_order()
	
	set_shapes()
	randomise_question_fabric()

func shuffle_question_order():
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))

func set_shapes():
	current_shuffled_question = question_order[current_question - 1]
	var level_path = get_level_path()
	var question_path = get_question_path()
	
	print("Level %d, Question %d" % [current_level, current_question])
	
	set_holey_quilt_shape(level_path, question_path)
	set_options_shapes(question_path)

func get_level_path():
	return "res://assets/sprites/questions/level_%d/" % current_level

func get_question_path():
	var level_path = get_level_path()
	return str(level_path, "question_%d" % current_shuffled_question)

func get_holey_quilt_path():
	var question_path = get_question_path()
	return question_path + "/holey_quilt.png"

func get_holey_quilt_fabric():
	var holey_quilt = get_child(0)
	var holey_quilt_fabric = holey_quilt.get_child(1)
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt = get_child(0)
	var holey_quilt_shape = holey_quilt.get_child(0)
	return holey_quilt_shape

func set_holey_quilt_shape(level_path, question_path):
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var holey_quilt_path = get_holey_quilt_path()
	
	var shape = load(holey_quilt_path)
	holey_quilt_shape.set_texture(shape)

func set_options_shapes(base_path):
	var indices = range(1,4)
	var random_indices = general_utils.shuffle_list(indices)
	for i in indices:
		var option = get_child(i)
		var option_mask = option.get_child(0)
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_shape = load(option_path)
		option_mask.set_texture(option_shape)

func on_option_pressed(sprite_index):
	var children = get_children()
	var option = children[sprite_index]
	var option_sprite = option.get_child(0)
	var option_shape = option_sprite.get_texture()
	var option_shape_path = option_shape.get_load_path()
	
	var option_index = option_shape_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_shape_path.substr(opt_no_index, 1))
	
	if (opt_no == 1):
		next_question()

func randomise_question_fabric():
	var fabric_path = file_utils.get_random_fabric_path()
	current_fabric = fabric_path
	
	set_question_fabric(fabric_path)

func set_question_fabric(fabric_path):
	var fabric = load(fabric_path)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var option = get_child(i)
		var option_fabric = option.get_child(2)
		option_fabric.set_texture(fabric)

func _on_Option_1_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(1)


func _on_Option_2_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(2)


func _on_Option_3_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(3)
