extends ExitButton

const Constants = preload("../utilities/constants.gd")

func _init():
	var constants = Constants.new()
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		position = Vector2(841, 1050)
	else:
		position = Vector2(1044, 1050)
