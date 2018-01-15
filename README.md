# wpf-very-long-line-log

It is an implementation of FAST log window.

You can use it for other purposes - console window, or etc.

I could write it as a module shape or added useful feathres, but I didn't it. Becouse I want to shorten codes, make you understand easy.

### Key of work
 - Use TextBox.AppendText(string)
 - Split TextBox into sutable sizes, and put them into StackPanel, and scroll it.
 - Equip a list of string and a StringBuilder to access strings in non-ui thread.
