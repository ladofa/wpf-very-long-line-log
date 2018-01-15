# wpf-very-long-line-log

It is an implementation of FAST log window.

You can use it for other purposes - console window, or etc.

I could design it better, or add useful feathres, but I didn't. Becouse I wanted to shorten codes, so that you can understand it easily.

### Key of work
 - Use TextBox.AppendText(string)
 - Split TextBox into sutable sizes, and put them into StackPanel, and scroll it.
 - Equip a list of string and a StringBuilder to access strings in non-ui thread.
