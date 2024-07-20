--[[

Function (obj, data)

obj - "obj" in Aviutl
time - Execute Duration
delay - Execute delay
data - data

]]

local E = require("easing")
local ft = {
	E.linear				,--  1
	E.inQuad				,--  2
	E.outQuad				,--  3
	E.inOutQuad				,--  4
	E.outInQuad				,--  5
	E.inCubic 				,--  6
	E.outCubic				,--  7
	E.inOutCubic			,--  8
	E.outInCubic			,--  9
	E.inQuart				,-- 10
	E.outQuart				,-- 11
	E.inOutQuart			,-- 12
	E.outInQuart			,-- 13
	E.inQuint				,-- 14
	E.outQuint				,-- 15
	E.inOutQuint			,-- 16
	E.outInQuint			,-- 17
	E.inSine				,-- 18
	E.outSine				,-- 19
	E.inOutSine				,-- 20
	E.outInSine				,-- 21
	E.inExpo				,-- 22
	E.outExpo				,-- 23
	E.inOutExpo				,-- 24
	E.outInExpo				,-- 25
	E.inCirc				,-- 26
	E.outCirc				,-- 27
	E.inOutCirc				,-- 28
	E.outInCirc				,-- 29
	E.inElastic				,-- 30
	E.outElastic			,-- 31
	E.inOutElastic			,-- 32
	E.outInElastic			,-- 33
	E.inBack				,-- 34
	E.outBack				,-- 35
	E.inOutBack				,-- 36
	E.outInBack				,-- 37
	E.inBounce				,-- 38
	E.outBounce				,-- 39
	E.inOutBounce			,-- 40
	E.outInBounce			,-- 41
}

function easing_a(et, t, b, c, d, s, a, p)
	local r
	if( et >= 30 and et <= 33 ) then
		if( a ~= nil ) then
			a = a + c
		end
		r = ft[et](t,b,c,d,a,p)
	else
		r = ft[et](t,b,c,d,s)
	end
	
	if( r~=r ) then
		return b
	else
		return r
	end
end

function easing_b(par, st, ed, ratio)
	local module_name = "curve_editor"
	if not package.loaded[module_name] then
		package.preload[module_name] = package.loadlib(module_name .. ".auf", "luaopen_" .. module_name)
		require(module_name)
		package.preload[module_name] = nil
	end
	return curve_editor.getcurve(1, par, ratio, st, ed)
end

return {
	easing_a = easing_a,
	easing_b = easing_b
}