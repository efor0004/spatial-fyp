extends Node2D

const SaveUtils = preload("../utilities/save.gd")
var save_utils = SaveUtils.new()

func _ready():
	save_utils.set_state_for_player()
