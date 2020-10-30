extends AnimatedSprite

onready var branch = get_node("Branch")

var animation_frames = [
	{ "idle": 20, "correct": 10, "incorrect": 10 }, # 1 - owl
	{ "idle": 20, "correct": 10, "incorrect": 20 }, # 2 - chameleon
	{ "idle": 25, "correct": 25, "incorrect": 10 }, # 3 - goat
	{ "idle": 16, "correct": 16, "incorrect": 16 }, # 4 - frog
	{ "idle": 20, "correct": 12, "incorrect": 10 }, # 5 - monkey
	{ "idle": 25, "correct": 15, "incorrect": 15 }, # 6 - rabbit
]

var transformations = [
	{ "scale": Vector2(0.5, 0.5), "position": Vector2(1800, 1300) }, # 1 - owl
	{ "scale": Vector2(0.5, 0.5), "position": Vector2(1700, 1300) }, # 2 - chameleon
	{ "scale": Vector2(1, 1), "position": Vector2(1800, 1300) }, # 3 - goat
	{ "scale": Vector2(0.5, 0.5), "position": Vector2(1800, 1300) }, # 4 - frog
	{ "scale": Vector2(0.5, 0.5), "position": Vector2(1850, 1300) }, # 5 - monkey
	{ "scale": Vector2(0.75, 0.75), "position": Vector2(1700, 1300) }, # 6 - rabbit
]

func _ready():
	setup()

func setup():
	setup_transformation()
	setup_animations()
	on_ready()

func setup_transformation():
	var transformation = transformations[global.character_index - 1]
	self.scale = transformation.scale
	self.position = transformation.position

func setup_animations():
	add_animation("idle", true, 8)
	add_animation("correct", false, 8)
	add_animation("incorrect", false, 8)

func add_animation(animation_name, loop, speed):
	frames.add_animation(animation_name)
	frames.set_animation_loop(animation_name, loop)
	frames.set_animation_speed(animation_name, speed)
	
	var num_frames = animation_frames[global.character_index - 1][animation_name]
	
	for i in range(num_frames):
		var path = "res://assets/sprites/characters/%d/%s/%d.png" % [global.character_index, animation_name, i]
		var frame = load(path)
		frames.add_frame(animation_name, frame)

func on_ready():
	idle()
	
	if (global.character_index == 5):
		branch.visible = true
	else:
		branch.visible = false

func idle():
	play_animation("idle")

func on_option(is_correct):
	if (is_correct):
		on_correct_option()
	else:
		on_incorrect_option()

func on_correct_option():
	play_animation("correct")

func on_incorrect_option():
	play_animation("incorrect")

func play_animation(animation_name):
	if (animation != animation_name):
		play(animation_name)

func _on_Character_animation_finished():
	idle()
