extends AnimatedSprite

class_name AnimatedCharacter

const LOOPING_ANIMATIONS = ["idle", "move"]

const animation_info = [
	{ # 1 - Owl
		"idle": {
			"folder_name": "no_branch/idle_awake",
			"num_frames": 20
		},
		"react": {
			"folder_name": "no_branch/rotate_head",
			"num_frames": 10
		},
		"move": {
			"folder_name": "no_branch/flap_wings",
			"num_frames": 10
		}
	},
	{ # 2 - Chameleon
		"idle": {
			"folder_name": "idle",
			"num_frames": 20
		},
		"react": {
			"folder_name": "incorrect",
			"num_frames": 20
		},
		"move": {
			"folder_name": "walk",
			"num_frames": 16
		}
	},
	{ # 3 - Goat
		"idle": {
			"folder_name": "idle",
			"num_frames": 25
		},
		"react": {
			"folder_name": "incorrect",
			"num_frames": 10
		},
		"move": {
			"folder_name": "walk",
			"num_frames": 15
		}
	},
	{ # 4 - Frog
		"idle": {
			"folder_name": "idle",
			"num_frames": 16
		},
		"react": {
			"folder_name": "incorrect",
			"num_frames": 16
		},
		"move": {
			"folder_name": "walk",
			"num_frames": 16
		}
	},
	{ # 5 - Monkey
		"idle": {
			"folder_name": "crouched/idle",
			"num_frames": 20
		},
		"react": {
			"folder_name": "crouched/running",
			"num_frames": 16
		},
		"move": {
			"folder_name": "crouched/walk",
			"num_frames": 16
		}
	},
	{ # 6 - Rabbit
		"idle": {
			"folder_name": "idle",
			"num_frames": 25
		},
		"react": {
			"folder_name": "correct",
			"num_frames": 15
		},
		"move": {
			"folder_name": "walk",
			"num_frames": 15
		}
	}
]

onready var animation_player = get_parent()
onready var animal_index = animation_player.get_index()

signal setup_done

func enter():
	add_animation("move", true, 8)
	animation_player.play("enter")
	yield(animation_player, "animation_finished")
	add_animation("idle", true, 8)
	yield(get_tree().create_timer(0.5), "timeout")
	play("idle")
	emit_signal("setup_done")

func react():
	add_animation("react", false, 8)
	play("react")

func add_animation(animation_name, loop, speed):
	frames.add_animation(animation_name)
	frames.set_animation_loop(animation_name, loop)
	frames.set_animation_speed(animation_name, speed)
	
	var info = animation_info[animal_index][animation_name]
	
	for i in range(info.num_frames):
		var path = "res://assets/sprites/characters/%d/%s/%d.png" % [animal_index + 1, info.folder_name, i]
		var frame = load(path)
		frames.add_frame(animation_name, frame)

func _on_Character_animation_finished():
	if (!LOOPING_ANIMATIONS.has(animation) and frames.has_animation("idle")):
		play("idle")
