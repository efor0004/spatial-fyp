extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var current_shuffled_question = 1

onready var current_colour = Color(1,1,1,1)
onready var initial_quilt_piece_x = 1136
onready var quilt_piece_x = initial_quilt_piece_x
onready var quilt_piece_y = 0

onready var questions_per_level = 10
onready var max_levels = 1

onready var question_order = []
onready var option_file_text = "option_"
onready var all_textures_path = "res://assets/sprites/textures"

const FileUtils = preload("utilities/files.gd")
onready var file_utils = FileUtils.new()

const GeneralUtils = preload("utilities/general.gd")
onready var general_utils = GeneralUtils.new()

func _ready():
	randomise_question_texture()
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))
	set_shapes()

func next_question():
	add_quilt_piece()
	
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
	randomise_question_texture()

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

func get_holey_quilt_texture():
	var holey_quilt = get_child(0)
	var holey_quilt_texture = holey_quilt.get_child(1)
	return holey_quilt_texture

func get_holey_quilt_shape():
	var holey_quilt = get_child(0)
	var holey_quilt_shape = holey_quilt.get_child(0)
	return holey_quilt_shape

func set_holey_quilt_shape(level_path, question_path):
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var holey_quilt_path = get_holey_quilt_path()
	print(holey_quilt_path)
	
	var shape = load(holey_quilt_path)
	print(holey_quilt_shape)
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
	print("Option %d pressed" % sprite_index)
	var children = get_children()
	var option = children[sprite_index]
	var option_sprite = option.get_child(0)
	var option_texture = option_sprite.get_texture()
	var option_texture_path = option_texture.get_load_path()
	
	var option_index = option_texture_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_texture_path.substr(opt_no_index, 1))
	
	if (opt_no == 1):
		next_question()

func randomise_question_texture():
	var textures = file_utils.get_files_in_directory(all_textures_path)
	
	randomize()
	var x = randi() % textures.size()
	var file_name = textures[x]
	var texture_path = "%s/%s" % [all_textures_path, file_name]
	
	set_question_texture(texture_path)

func add_quilt_piece():
	var piece = Sprite.new()
	
	var piece_path = get_holey_quilt_path()
	var piece_texture = load(piece_path)
	piece.texture = piece_texture
	
	piece.self_modulate = current_colour
	var scale = 0.25
	piece.scale = Vector2(scale,scale)
	
	var piece_rect = piece.get_rect()
	var piece_size_x = piece_rect.size.x * scale
	
	quilt_piece_x = quilt_piece_x + piece_size_x
	
	if current_question == 2:
		quilt_piece_x = initial_quilt_piece_x
		var piece_size_y = piece_rect.size.y * scale
		if quilt_piece_y == 0:
			quilt_piece_y = quilt_piece_y + piece_size_y / 2
		else:
			quilt_piece_y = quilt_piece_y + piece_size_y
	
	var new_piece_pos = Vector2(quilt_piece_x, quilt_piece_y)
	print(new_piece_pos)
	piece.transform.origin = new_piece_pos
	
	add_child(piece)

func set_question_texture(texture_path):
	var texture = load(texture_path)
	var holey_quilt_texture = get_holey_quilt_texture()
	holey_quilt_texture.set_texture(texture)
	
	for i in range(1,4):
		var option = get_child(i)
		var option_texture = option.get_child(2)
		option_texture.set_texture(texture)

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
