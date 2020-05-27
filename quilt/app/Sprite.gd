extends Sprite


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var path = "res://assets/sprites/questions/level_1/question_1/option_1"
	var mask = load(path)
	var alpha = self.self_modulate.a
	self.self_modulate.a = alpha * mask


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
