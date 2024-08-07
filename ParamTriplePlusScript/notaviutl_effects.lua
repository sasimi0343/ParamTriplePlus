local a = "ParamTriplePlus.Params.NotAviUtl.EF";
if (rikky_module == nil) then require("rikky_module") end
return {
[a .. "FlatShadow"] = function(v, ef, ob)
	rikky_module.image("w", "na_effect_fs_original")
	local track0 = GetValue(ef, "length")
	local track1 = GetValue(ef, "angle")
	local color = ColorToNumber(GetValue(ef, "color"))
	
	local radang = math.rad(track1 + 90)
	local sin,cos = math.sin(radang),math.cos(radang)
	
	obj.effect("方向ブラー", "範囲", track0, "角度", track1)
	
	local pfunction = function(objr, objg, objb, obja, argr, argg, argb, arga, x, y)
		local r, g, b, a = objr, objg, objb, obja
		if (a > 0) then
			a = 255
		else
			a = 0
		end
		if (not (color == nil)) then
			r, g, b = RGB(color)
		end
		return r, g, b, a
	end
	
	rikky_module.pixelfunction(pfunction)
	
	obj.setoption("drawtarget", "tempbuffer", obj.w, obj.h)
	obj.draw()
	
	rikky_module.image("r", "na_effect_fs_original")
	obj.draw(-cos * track0, -sin * track0)
	
	obj.setoption("drawtarget", "framebuffer")
	obj.load("tempbuffer")
	
	if (GetValue(ef, "centerTo")) then
	cx = -cos * track0
	cy = -sin * track0
	end
	end,
[a .. "InnerShadow"] = function(v, ef, ob)
	rikky_module.image("w", "na_effect_is_original")
	local pos = GetValue(ef, "pos")
	local blur = GetValue(ef, "blur")
	local alpha = GetValue(ef, "alpha")/100
	local color = ColorToNumber(GetValue(ef, "color"))
	obj.effect("反転", "透明度反転", 1 )
	obj.effect("ぼかし", "範囲", blur)
	obj.effect("単色化", "輝度を保持する", 0, "color", color)
	rikky_module.image("w", "na_effect_is2")
	obj.setoption("drawtarget", "tempbuffer", obj.w, obj.h)
	rikky_module.image("r", "na_effect_is_original")
	obj.draw()
	
	rikky_module.image("r", "na_effect_is2")
	obj.draw(pos.x, pos.y, 0, 1.0, alpha, 0, 0, 0)
	
	rikky_module.image("r", "na_effect_is_original")
	obj.effect("反転", "透明度反転", 1 )
	obj.setoption("blend", "alpha_sub")
	obj.draw()
	obj.setoption("blend", 0)
	
	obj.setoption("drawtarget", "framebuffer")
	obj.load("tempbuffer")
	
	end,
[a .. "Outline"] = function(v, ef, ob)
	rikky_module.image("w", "na_effect_bc1")
	local width = GetValue(ef, "width")
	local blur = GetValue(ef, "blur")
	local alpha = GetValue(ef, "alpha")/100
	local color = ColorToNumber(GetValue(ef, "color"))
	obj.setoption("antialias", 0)
	
	obj.effect("縁取り", "サイズ", width, "ぼかし", blur, "color", color)
	
	obj.setoption("drawtarget", "tempbuffer", obj.w, obj.h)
	obj.draw(0, 0, 0, 1.0, alpha)
	
	rikky_module.image("r", "na_effect_bc1")
	obj.setoption("blend", "alpha_sub")
	obj.draw()
	obj.setoption("blend", 0)
	
	obj.setoption("drawtarget", "framebuffer")
	obj.load("tempbuffer")
	
	end,
[a .. "Worm"] = function(v, ef, ob)
	rikky_module.image("w", "na_effect_worm")
	local width = GetValue(ef, "width")
	local blur = GetValue(ef, "blur")
	local alpha = GetValue(ef, "alpha")/100
	obj.setoption("antialias", 0)
	obj.effect("領域拡張", "右", 1, "左", 1, "上", 1, "下", 1, "塗りつぶし", 0)
	obj.effect("反転", "透明度反転", 1 )
	rikky_module.image("w", "na_effect_worm2")
	
	obj.setoption("drawtarget", "tempbuffer", obj.w, obj.h)
	rikky_module.image("r", "na_effect_worm")
	obj.draw()
	
	rikky_module.image("r", "na_effect_worm2")
	obj.effect("縁取り", "サイズ", width, "ぼかし", blur)
	obj.setoption("blend", "alpha_sub")
	obj.draw(0, 0, 0, 1.0, alpha)
	
	obj.setoption("blend", 0)
	
	obj.setoption("drawtarget", "framebuffer")
	obj.load("tempbuffer")
	
	end,
}