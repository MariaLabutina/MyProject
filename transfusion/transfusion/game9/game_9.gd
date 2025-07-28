extends Node2D

var current_cone: Cone = null
var colors = []

func _ready() -> void:
	var color1 = Color.BLUE
	var color2 = Color.CHARTREUSE
	var color3 = Color.CRIMSON
	var color4 = Color.FUCHSIA
	var color5 = Color.DARK_ORANGE
	var color6 = Color.YELLOW
	var color7 = Color.BLUE_VIOLET
	var color8 = Color.INDIAN_RED
	
	for i in 4:
		colors.append(color1)
		colors.append(color2)
		colors.append(color3)
		colors.append(color4)
		colors.append(color5)
		colors.append(color6)
		colors.append(color7)
		colors.append(color8)
	colors.shuffle()
	fill()

func fill():
	var c = 0
	for i in 4:
		get_child(0).push(colors[c])
		c+=1
		get_child(1).push(colors[c])
		c+=1
		get_child(2).push(colors[c])
		c+=1
		get_child(3).push(colors[c])
		c+=1
		get_child(4).push(colors[c])
		c+=1
		get_child(5).push(colors[c])
		c+=1
		get_child(6).push(colors[c])
		c+=1
		get_child(7).push(colors[c])
		c+=1
	


func finished():
	for i in 10:
		if !get_child(i).is_finish():
			return false
	return true


func _on_cone_on_click(node: Variant) -> void:
	if(current_cone==null):
		current_cone = node
		current_cone.selected()
	else:
		var color = current_cone.pop()
		if color != null:
			if (node.up_color() == color or node.up_color() == null) and node.level < 3:
				node.push(color)
			else:
				current_cone.push(color)
		current_cone.un_selected()
		current_cone = null
		if finished():
			$Label.show()
			$ButtonHint.hide()
			$ButtonMix.show()


func _on_button_undo_pressed() -> void:
	get_tree().change_scene_to_file("res://Menu/menu.tscn")


func _on_button_hint_pressed() -> void:
	for i in 10:
		get_child(i).clear()
	fill()
	
	$Cone10.hide()
	$Button3.show()


func _on_button_3_pressed() -> void:
	$Cone10.show()
	$Button3.hide()


func _on_button_mix_pressed() -> void:
	for i in 10:
		get_child(i).clear()
	colors.shuffle()
	fill()
	$Label.hide()
	$ButtonMix.hide()
	$Cone10.hide()
	$Button3.show()
	$ButtonHint.show()
