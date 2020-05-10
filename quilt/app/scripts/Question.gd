extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var current_colour = Color(1,1,1,1)
onready var initial_quilt_piece_x = 1136
onready var quilt_piece_x = initial_quilt_piece_x
onready var quilt_piece_y = 0

onready var questions_per_level = 10
onready var max_levels = 1

onready var question_order = []
onready var option_file_text = "option_"

func _ready():
	randomise_question_colour()
	question_order = shuffle_list(range(1,questions_per_level + 1))
	set_textures()

func next_question():
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
		shuffle_question_order()
	
	if (current_level > max_levels):
		current_level = 1
		current_question = 1
		shuffle_question_order()
	
	add_quilt_piece()
	set_textures()
	randomise_question_colour()

func shuffle_question_order():
	question_order = shuffle_list(range(1,questions_per_level + 1))

func set_textures():
	var children = get_children()
	var shuffled_question = question_order[current_question - 1]
	var level_path = get_level_path()
	var question_path = get_question_path(shuffled_question)
	
	print("Level %d, Question %d" % [current_level, current_question])
	
	set_holey_quilt_texture(level_path, question_path, children)
	set_options_textures(question_path, children)

func get_level_path():
	return "res://assets/sprites/questions/level_%d/" % current_level

func get_question_path(question):
	var level_path = get_level_path()
	return str(level_path, "question_%d" % question)

func get_holey_quilt_path():
	var level_path = get_level_path()
	return level_path + "/holey_quilt.png"

func set_holey_quilt_texture(level_path, question_path, children):
	var holey_quilt = children[0]
	var hole = holey_quilt.get_child(0)
	
	var holey_quilt_path = get_holey_quilt_path()
	var hole_path = question_path + "/option_1.png"
	
	var holey_quilt_texture = load(holey_quilt_path)
	var hole_texture = load(hole_path)
	
	holey_quilt.set_texture(holey_quilt_texture)
	hole.set_texture(hole_texture)

func set_options_textures(base_path, children):
	var indices = range(1,4)
	var random_indices = shuffle_list(indices)
	for i in indices:
		var option = children[i]
		var option_sprite = option.get_child(0)
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_texture = load(option_path)
		option_sprite.set_texture(option_texture)
		
func shuffle_list(list):
	var list_copy = list.duplicate()
	var shuffled_list = []
	for i in range(list_copy.size()):
		var index_list = range(list_copy.size())
		randomize()
		var x = randi()%index_list.size()
		shuffled_list.append(list_copy[x])
		index_list.remove(x)
		list_copy.remove(x)
	return shuffled_list

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

func randomise_question_colour():
	var rng = RandomNumberGenerator.new()
	rng.randomize()
	var r = rng.randf_range(0,0.9)
	var g = rng.randf_range(0,0.9)
	var b = rng.randf_range(0,0.9)
	var colour = Color(r,g,b,1)
	current_colour = colour
	set_question_colour(colour)

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

func set_question_colour(colour):
	var children = get_children()
	for i in range(0,4):
		var child = children[i]
		var sprite
		if child.get_class() == "Sprite":
			sprite = child
		else:
			sprite = child.get_child(0)
		sprite.self_modulate = colour

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
