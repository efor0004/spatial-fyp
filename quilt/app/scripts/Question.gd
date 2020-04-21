extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var questions_per_level = 10

func _on_Next_Button_pressed():
	print("button pressed")
	var children = get_children()
	
	if (current_question >= questions_per_level):
		current_question = 1
		current_level += 1
	else:
		current_question += 1
		
	var base_path = "res://assets/sprites/questions/level_%d/question_%d" % [current_level, current_question]
	
	set_holey_quilt_texture(base_path, children)
	set_options_textures(base_path, children)

func set_holey_quilt_texture(base_path, children):
	var holey_quilt = children[0]
	var holey_quilt_path = base_path + "/holey_quilt.png"
	var holey_quilt_texture = load(holey_quilt_path)
	holey_quilt.set_texture(holey_quilt_texture)

func set_options_textures(base_path, children):
	for i in range(1,4):
		var option = children[i]
		var option_path_suffix = "/option_%d.png" % i
		var option_path = base_path + option_path_suffix
		var option_texture = load(option_path)
		option.set_texture(option_texture)
		
