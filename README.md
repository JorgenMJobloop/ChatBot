# ChatBot

## 04.12.2025 - 11.12.2025

## TODO
    * Create a simple Chatbot, that responds to certain phrases[x]
    * Create a Terminal-UI(TUI) using Spectre.Console
## Currently implemented
    * Random phrases
    * JSON response ruleset
    * Simple keyword response matching

## Alogrithm
    
### Psuedocode for algorithm
```sh
score = number of keywords that exists in input

Rules
    Rule 1 -> match "hello" -> score = 1
    Rule 2 -> match "learn" -> score = 2
    Rule 3 -> match "learn" AND "ex: c#" -> score = 3 (when it is an exact word)
    -> Rule 3 = score Rule 2 = 1 + Rule 3 = 3 == 4 
    Rule 4 -> no matches -> score = 0
```
