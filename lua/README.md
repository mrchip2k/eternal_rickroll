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
- Errors
	- [x] Argument count bigger than 1
	- [ ] First argument can't be parsed as int
- [x] No extra newlines or spaces
- [x] Stats: lines and words
- [x] Stats: count each word
	- [x] only display words that have been used