extends Node2D

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

var loaded_scene

var timer

func _ready():
	timer = Timer.new()
	add_child(timer)
	timer.wait_time = 1
	timer.connect("timeout", self, "_timeout")
	timer.start()

func _timeout():
	timer.stop()
	remove_child(timer)
	loaded_scene = load(global.next_scene) as PackedScene
	get_tree().change_scene_to(loaded_scene)
