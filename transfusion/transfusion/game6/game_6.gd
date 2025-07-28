extends Node2D

var current_cone: Cone = null
var colors = []

func _ready() -> void:
	var color1 = Color.BLUE
	var color2 = Color.CHARTREUSE
	var color3 = Color.CRIMSON
	var color4 = Color.FUCHSIA
	var color5 = Color.DARK_ORANGE
	
	for i in 4:
		colors.append(color1)
		colors.append(color2)
		colors.append(color3)
		colors.append(color4)
		colors.append(color5)
	colors.shuffle()
	fill()
	


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
			$ButtonMix.show()
			$ButtonHint.hide()
			

func finished():
	for i in 7:
		if !get_child(i).is_finish():
			return false
	return true


func _on_button_undo_pressed() -> void:
	get_tree().change_scene_to_file("res://Menu/menu.tscn")


func _on_button_hint_pressed() -> void:
	for i in 7:
		get_child(i).clear()
	fill()
	$Cone7.hide()
	$Button3.show()

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
		


func _on_button_3_pressed() -> void:
	$Cone7.show()
	$Button3.hide()


func _on_button_mix_pressed() -> void:
	for i in 7:
		get_child(i).clear()
	colors.shuffle()
	fill()
	$Label.hide()
	$ButtonMix.hide()
	$Cone7.hide()
	$Button3.show()
	$ButtonHint.show()
	
