extends Node

var fabrics_path = "res://assets/sprites/fabrics"
var num_fabrics = 14
	
func get_random_fabric_path():
	randomize()
	var x = (randi() % (num_fabrics - 1)) + 1
	var file_name = "fabric_%d.jpg" % x
	var fabric_path = "%s/%s" % [fabrics_path, file_name]
	
	return fabric_path
