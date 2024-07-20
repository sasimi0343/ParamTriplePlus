function toobj(st)
	if ((string.sub(st, 1, 1) == "\"") and (string.sub(st, -1, -1) == "\"")) then
		return string.sub(st, 2, -2)
	end
	local num = tonumber(st)
	if (not (num == nil)) then return num end
	if (string.lower(st) == "true") then return true end
	if (string.lower(st) == "false") then return false end
	if (string.lower(st) == "null") then return nil end
	if ((string.sub(st, 1, 1) == "[") and (string.sub(st, -1, -1) == "]")) then
		local kansei = {}
		local itizi = ""
		local iskakko = false
		local prev = ""
		local level = 0
		for i=2,#st-1 do
			local c = string.sub(st, i, i)
			
			if ((not iskakko) and (c == "\"")) then
				iskakko = true
				itizi = itizi .. c
			elseif ((iskakko) and (c == "\"") and (not (prev == "\\"))) then
				iskakko = false
				itizi = itizi .. c
			elseif ((not iskakko) and ((c == "{") or (c == "["))) then
				level = level + 1
				itizi = itizi .. c
			elseif ((not iskakko) and ((c == "}") or (c == "]"))) then
				level = level - 1
				itizi = itizi .. c
			elseif ((not iskakko) and (c == ",") and (level == 0)) then
				table.insert(kansei, toobj(itizi))
				itizi = ""
			else
				itizi = itizi .. c
			end
			
			prev = c
		end
		
		if (not (itizi == "")) then table.insert(kansei, toobj(itizi)) end
		
		return kansei
	end
	return perse(st)
end
function perse(st)
	local kansei = {}
	local itizi = ""
	local itizi2 = ""
	local isvalue = false
	local iskakko = false
	local prev = ""
	local level = 0
	for i=2,#st-1 do
		local c = string.sub(st, i, i)
		
		if ((not isvalue) and (not iskakko) and (c == ":")) then
			isvalue = true
			itizi2 = string.sub(itizi, 2, -2)
			itizi = ""
		elseif ((not iskakko) and (c == "\"")) then
			iskakko = true
			itizi = itizi .. c
		elseif ((iskakko) and (c == "\"") and (not (prev == "\\"))) then
			iskakko = false
			itizi = itizi .. c
		elseif (isvalue and (not iskakko) and ((c == "{") or (c == "["))) then
			level = level + 1
			itizi = itizi .. c
		elseif (isvalue and (not iskakko) and ((c == "}") or (c == "]"))) then
			level = level - 1
			itizi = itizi .. c
		elseif (isvalue and (not iskakko) and (c == ",") and (level == 0)) then
			isvalue = false
			if (itizi2 == "") then
				table.insert(kansei, toobj(itizi))
			else
				kansei[itizi2] = toobj(itizi)
			end
			
			itizi = ""
			itizi2 = ""
		else
			itizi = itizi .. c
		end
		
		prev = c
	end
	
	if (not (itizi == "")) then
		if (itizi2 == "") then
			table.insert(kansei, toobj(itizi))
		else
			kansei[itizi2] = toobj(itizi)
		end
	end
	
	return kansei
end


return {toobj = toobj, parse = perse}