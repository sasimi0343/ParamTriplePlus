local a = "ParamTriplePlus.Params.MoreShapes3D.MS3D_";
return {
[a .. "Box"] = function(v)
	local pos = GetValue(v, "position")
	local rot = GetValue(v, "rotation")
	v.is3d = true
	obj.load("figure", "éläpå`", 0xffffff, 100, 4000)
	local size = GetValue(v, "size")
	local w = size.x / 2
	local h = size.y / 2
	local d = size.z / 2
	
	local p1 = { x = -w, y = -h, z = -d}
	local p2 = { x = w, y = -h, z = -d}
	local p3 = { x = w, y = h, z = -d}
	local p4 = { x = -w, y = h, z = -d}
	
	local p5 = { x = -w, y = -h, z = d}
	local p6 = { x = w, y = -h, z = d}
	local p7 = { x = w, y = h, z = d}
	local p8 = { x = -w, y = h, z = d}
	
	local s1 = {p1, p2, p3, p4, 75}
	local s2 = {p1, p2, p6, p5, 100}
	local s3 = {p5, p6, p7, p8, 75}
	local s4 = {p5, p1, p4, p8, 50}
	local s5 = {p8, p7, p3, p4, 25}
	local s6 = {p2, p6, p7, p3, 50}
	
	sur = {s1, s2, s3, s4, s5, s6}
	geo = {
	
	surface = sur,
	shading = {},
	ox = pos.x,
	oy = pos.y,
	oz = pos.z,
	rx = rot.x,
	ry = rot.y,
	rz = rot.z
	
	}
	
	geos = {geo}
	end
}