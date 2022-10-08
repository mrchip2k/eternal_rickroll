# Lua version

## Running

```
$> lua main.lua [args]
```

## Status
- [x] No args default line count
- [x] Handle 0 or positive line count
- [x] Infinite mode
- [x] Bad argument count help message
- [ ] Error message
	- Could be added whenever accessing tables, in case of a bad index, but if i need these guarantees i should just be using a statically typed language. Won't implement, since the program does appear to work correctly and this would clutter the code.
- [x] No extra newlines or spaces
- [x] Stats: lines and words
- [x] Stats: count each word
	- [x] only display words that have been used