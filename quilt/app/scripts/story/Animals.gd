extends Node2D

func _ready():
	for animal in get_children():
		animal.play("idle")
