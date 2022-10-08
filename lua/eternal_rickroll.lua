states = {}
states["goodbye"] = {
	["msg"] = "goodbye",
	["to"] = {"never"}
}
states["say"] = {
	["msg"] = "say",
	["to"] = {"goodbye"}
}
states["run"] = {
	["msg"] = "run",
	["to"] = {"around"}
}
states["around"] = {
	["msg"] = "around",
	["to"] = {"and"}
}
states["never"] = {
	["msg"] = "Never",
	["to"] = {"gonna"}
}
states["gonna"] = {
	["msg"] = "gonna",
	["to"] = {"say", "run", "tell", "let", "give", "make"}
}
states["tell"] = {
	["msg"] = "tell",
	["to"] = {"a_lie"}
}
states["a_lie"] = {
	["msg"] = "a lie",
	["to"] = {"and"}
}
states["down"] = {
	["msg"] = "down",
	["to"] = {"never"}
}
states["cry"] = {
	["msg"] = "cry",
	["to"] = {"never"}
}
states["up"] = {
	["msg"] = "up",
	["to"] = {"never"}
}
states["you"] = {
	["msg"] = "you",
	["to"] = {"never", "up", "cry", "down"}
}
states["let"] = {
	["msg"] = "let",
	["to"] = {"you"}
}
states["give"] = {
	["msg"] = "give",
	["to"] = {"you"}
}
states["make"] = {
	["msg"] = "make",
	["to"] = {"you"}
}
states["and"] = {
	["msg"] = "and",
	["to"] = {"desert", "hurt"}
}
states["desert"] = {
	["msg"] = "desert",
	["to"] = {"you"}
}
states["hurt"] = {
	["msg"] = "hurt",
	["to"] = {"you"}
}

function pick_random(to)
	return to[math.random(#to)]
end

is_first_line = true
function process_step(current)
	if current ~= "never" then
		line_buf = line_buf .. " "
	end
	
	line_buf = line_buf .. states[current]["msg"]
	if states[current]["counter"] == nil then
		states[current]["counter"] = 0
	end
	states[current]["counter"] = 1 + states[current]["counter"]
	
	next_step = pick_random(states[current]["to"])
	return next_step
end

---- Execution start ----

math.randomseed(os.time())

lines_to_generate = 69420
infinite = false

if #arg == 1 then
	num = tonumber(arg[1])
	if num < 0 then
		infinite = true
	else
		lines_to_generate = num
	end
elseif #arg > 1 then
	print("Bad argument count.")
	print("Expected:")
	print("No arguments (generate default amount of lines, 69420)")
	print("1 argument (generate this amount of lines OR negative number for infinity)")
	os.exit(1)
end

word_count = 0
stats_counters = {}

current_state = "never"

-- Line loop
line_count = 0
while infinite or line_count < lines_to_generate do
	line_buf = ""
	-- Word loop
	while true do
		current_state = process_step(current_state)
		word_count = word_count + 1
		
		if stats_counters[current_state] == nil then
			stats_counters[current_state] = 0
		end
		stats_counters[current_state] = 1 + stats_counters[current_state]
		
		if current_state == "never" then
			break
		end
	end
	print(line_buf)
	line_count = line_count + 1
end
print("---RICK SUCCESSFULLY ROLLED.---")
print("[STATS]")
print("Lines: " .. line_count)
print("Words: " .. word_count)
for k, v in pairs(stats_counters) do
	print(states[k]["msg"] .. ": " .. v)
end
