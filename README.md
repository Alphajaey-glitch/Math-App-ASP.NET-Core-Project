# Math App
---

This app performs basic mathematical operations using HTTP GET method. 

# How it works
---
Run the application on your browser using the local path
Insert key/value pairs in the query in the search bar whether in your web browser or Postman. Parameters are:

+ firstNumber
+ secondNumber
+ operation


## Valid arithmetic operations are:

| # | operation | appropriate query input |
|---|---|---|
| 1 | addition | add |
| 2 | subtraction | subtract |
| 3 | multiplication | multiply |
| 4 | division | divide |
| 5 | modulo | mod |

Invalid operations and inputs return a 404 status code, while successful operations return the standard 200 success code.
