# wpf-very-long-line-log

It is an implementation of FAST log window.

You can use it for other purposes - console window, or etc.

### Key of work
 - Use TextBox.AppendText(string)
 - Split TextBox into sutable sizes, and put them into StackPanel, and scroll it.
 - Equip a list of string and a StringBuilder to access strings in non-ui thread.
